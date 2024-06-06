using System.Xml.Linq;
using AutoMapper;
using EventBus.Extensions;
using OracleFetchApi.Events;
using OracleFetchApi.Model.EmailTemplates;

namespace OracleFetchApi.Repositories;

public class EmailDataRepository : IEmailDataRepository
{
  private readonly IOracleDCDataProvider _oracleDCDataprovider;
  private readonly IMapper _mapper;

  public EmailDataRepository(IOracleDCDataProvider oracleDCDataProvider, IMapper mapper)
  {
    _oracleDCDataprovider = oracleDCDataProvider;
    _mapper = mapper;
  }

  public async Task<List<Events.IntegrationEvent>> GetIntegrationEvents(int count = 5)
  {
    var integrationEvents = new List<Events.IntegrationEvent>();

    // OracleDataSet loDS = _oracleDCDataprovider.GetDataSet(new OracleCommand($"select * from (select * from gnt_emailqueue order by emailqueueid desc) where rownum < {count}"));
    OracleDataSet loDS = _oracleDCDataprovider.GetDataSet(new OracleCommand($@"
    SELECT * 
    FROM (
        SELECT * 
        FROM gnt_emailqueue 
        WHERE sent = 'N' 
        ORDER BY emailqueueid DESC
    ) 
    WHERE ROWNUM < {count}"));

    DataTable loDT = loDS.Tables[0];

    foreach (DataRow loRow in loDT.Rows)
    {
      var emailQueueItem = new EmailQueueItem
      {
        EmailQueueId = Int32.Parse(loRow["emailqueueid"].ToString().Trim()),
        XslName = loRow["xslname"].ToString().Trim(),
        IsoLanguage = loRow["isolanguage"].ToString().Trim(),
        Email = loRow["email"].ToString().Trim(),
        SendAt = loRow["sendat"].ToString().Trim(),
        CompanyId = Int32.Parse(loRow["companyid"].ToString().Trim()),
        Sent = loRow["sent"].ToString().Trim()[0],
        Attempts = Int32.Parse(loRow["attempts"].ToString().Trim()),
        Subject = loRow["subject"].ToString().Trim(),
        Message = loRow["message"].ToString().Trim(),
        Created_On = loRow["created_on"].ToString().Trim(),
        Created_By = loRow["created_by"].ToString().Trim(),
        Modified_On = loRow["modified_on"].ToString().Trim(),
        Modified_By = loRow["modified_by"].ToString().Trim(),
      };

      var xmlData = ConvertXmlData(loRow["xmldata"].ToString());

      var integrationEvent = new Events.IntegrationEvent();

      if (xmlData is Login login)
      {
        Console.WriteLine($"Login: {login.FullName}, {login.Environment}");
        emailQueueItem.XmlData = login;
        integrationEvent = _mapper.Map<LoginIntegrationEvent>(emailQueueItem);
        _mapper.Map(login, integrationEvent);
      }
      else if (xmlData is User user)
      {
        Console.WriteLine($"User: {user.FullName}, {user.Email}");
        emailQueueItem.XmlData = user;
        integrationEvent = _mapper.Map<UserIntegrationEvent>(emailQueueItem);
        _mapper.Map(user, integrationEvent);
      }
      else if (xmlData is Report report)
      {
        Console.WriteLine($"Report: {report.ReportName}, {report.Url}");
        emailQueueItem.XmlData = report;
        integrationEvent = _mapper.Map<ReportIntegrationEvent>(emailQueueItem);
        _mapper.Map(report, integrationEvent);
      }
      else if (xmlData is Overdue overdue)
      {
        Console.WriteLine($"Overdue: {overdue.ProductName}, {overdue.OrderCode}");
        emailQueueItem.XmlData = overdue;
        integrationEvent = _mapper.Map<OverdueIntegrationEvent>(emailQueueItem);
        _mapper.Map(overdue, integrationEvent);
      }
      else
      {
        Console.WriteLine("Unknown type of XmlData");
      }

      integrationEvents.Add(integrationEvent);
    }

    return integrationEvents;
  }

  private XmlData ConvertXmlData(string xmlData)
  {
    if (string.IsNullOrEmpty(xmlData))
      return null;

    try
    {
      var doc = XDocument.Parse(xmlData);
      var root = doc.Root.Name.LocalName;
      XElement element = XElement.Parse(xmlData);

      switch (root)
      {
        case "login":
          Login login = new Login
          {
            FullName = element.Element("fullname")?.Value,
            Environment = element.Element("environment")?.Value,
            IPAddress = element.Element("ipaddress")?.Value,
            Date = DateTime.Parse(element.Element("date")?.Value),
            Time = TimeSpan.Parse(element.Element("time")?.Value)
          };
          return login;
        case "overdue":
          Overdue overdue = new Overdue
          {
            FullName = element.Element("fullname")?.Value,
            Email = element.Element("email")?.Value,
            ProductNumber = element.Element("productnr")?.Value,
            ProductName = element.Element("productname")?.Value,
            OrderCode = element.Element("ordercode")?.Value,
            OrderDate = DateTime.Parse(element.Element("orderdate")?.Value),
            OverdueDate = DateTime.Parse(element.Element("overduedate")?.Value)
          };
          return overdue;
        case "report":
          Report report = new Report
          {
            PortalName = element.Element("portalname")?.Value,
            ReportName = element.Element("reportname")?.Value,
            Url = element.Element("url")?.Value
          };
          return report;
        case "user":
          User user = new User
          {
            Url = element.Element("url")?.Value,
            UserName = element.Element("username")?.Value,
            Password = element.Element("password")?.Value,
            Email = element.Element("email")?.Value,
            CompanyName = element.Element("companyname")?.Value,
            PersonIdExtern = element.Element("personid_extern")?.Value,
            FullName = element.Element("fullname")?.Value,
            Street = element.Element("street")?.Value,
            PrimaryNumber = element.Element("primarynumber")?.Value,
            AdditionalNumber = element.Element("additionalnumber")?.Value,
            ZipCode = element.Element("zipcode")?.Value,
            City = element.Element("city")?.Value,
            Country = element.Element("country")?.Value
          };
          return user;
        default:
          throw new InvalidOperationException("Unknown XML data type.");
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error deserializing XML data: {ex.Message}");
      return null;
    }
  }

  public void GetAllProcessed()
  {
    OracleDataSet loDS = _oracleDCDataprovider.GetDataSet(new OracleCommand($"select * from (select * from gnt_emailqueue order by emailqueueid desc) where sent  = 'N'"));
    DataTable loDT = loDS.Tables[0];

    foreach (DataRow loRow in loDT.Rows)
    {
      Console.WriteLine($"{loRow["emailqueueid"]}     {loRow["sent"]}   {loRow["sendat"]}    {loRow["xslname"]}   {loRow["email"]}   {loRow["modified_on"]}    {loRow["modified_by"]}    {loRow["attempts"]}");
    }
  }

  public void GetAllNotPickedUp()
  {
    OracleDataSet loDS = _oracleDCDataprovider.GetDataSet(new OracleCommand($"select * from (select * from gnt_emailqueue order by emailqueueid desc) where sent  = 'Y'"));
    DataTable loDT = loDS.Tables[0];

    foreach (DataRow loRow in loDT.Rows)
    {
      Console.WriteLine($"{loRow["emailqueueid"]}     {loRow["sent"]}   {loRow["sendat"]}    {loRow["xslname"]}   {loRow["email"]}   {loRow["modified_on"]}    {loRow["modified_by"]}    {loRow["attempts"]}");
    }
  }

  public void SetSentToNotPickedUp(int id)
  {
    OracleCommand loCmd = new OracleCommand($"UPDATE gnt_emailqueue SET sent = 'N', modified_on = TO_DATE('{DateTime.Now:yyyy-MM-dd HH:mm:ss}', 'YYYY-MM-DD HH24:MI:SS'), modified_by = 'EmailApi' WHERE emailqueueid = {id}");

    _oracleDCDataprovider.ExecuteQuery(loCmd);
  }

  public void SetSentToProcessed(int id)
  {
    OracleCommand loCmd = new OracleCommand($"UPDATE gnt_emailqueue SET sent = 'Y', sendat = TO_DATE('{DateTime.Now:yyyy-MM-dd HH:mm:ss}', 'YYYY-MM-DD HH24:MI:SS'), modified_on = TO_DATE('{DateTime.Now:yyyy-MM-dd HH:mm:ss}', 'YYYY-MM-DD HH24:MI:SS'), modified_by = 'EmailApi' WHERE emailqueueid = {id}");

    _oracleDCDataprovider.ExecuteQuery(loCmd);
  }

  public void SetAllSentToNotPickedUp()
  {
    OracleCommand loCmd = new OracleCommand($"UPDATE gnt_emailqueue SET sent = 'N', modified_on = TO_DATE('{DateTime.Now:yyyy-MM-dd HH:mm:ss}', 'YYYY-MM-DD HH24:MI:SS'), modified_by = 'EmailApi'");

    _oracleDCDataprovider.ExecuteQuery(loCmd);
  }

  public void SetSentToIsBusy(int id)
  {
    OracleCommand loCmd = new OracleCommand($"UPDATE gnt_emailqueue SET sent = 'B', modified_on = TO_DATE('{DateTime.Now:yyyy-MM-dd HH:mm:ss}', 'YYYY-MM-DD HH24:MI:SS'), modified_by = 'EmailApi' WHERE emailqueueid = {id}");
    _oracleDCDataprovider.ExecuteQuery(loCmd);
  }

  public void SetSentToError(int id)
  {
    OracleCommand loCmd = new OracleCommand($"UPDATE gnt_emailqueue SET sent = 'E', modified_on = TO_DATE('{DateTime.Now:yyyy-MM-dd HH:mm:ss}', 'YYYY-MM-DD HH24:MI:SS'), modified_by = 'EmailApi' WHERE emailqueueid = {id}");
    _oracleDCDataprovider.ExecuteQuery(loCmd);
  }

  public void DeleteAllEmailQueueItems()
  {
    OracleCommand loCmd = new OracleCommand("DELETE FROM gnt_emailqueue");
    _oracleDCDataprovider.ExecuteQuery(loCmd);
  }

  public void GenerateEmails(int amount)
  {
    var commandText = @$"
            BEGIN
               POM_MAILER.GenerateEmailsLogin({amount});
               POM_MAILER.GenerateEmailsOverdue({amount});
               POM_MAILER.GenerateEmailsReportDownload({amount});
               POM_MAILER.GenerateEmailsUserRegistered({amount});
            END;
        ";

    _oracleDCDataprovider.ExecuteQuery(new OracleCommand(commandText));
  }

  public async Task<List<string>> GetColumnNamesAsync()
  {
    var columnNames = await _oracleDCDataprovider.GetColumnNamesAsync();
    return columnNames;
  }
}

// OracleCommand loCmd = new OracleCommand("UPDATE gnt_emailqueue SET sent = :sent, modified_on = :modifiedon, modified_by = 'EmailApi' WHERE emailqueueid = :emailqueueid");
// loCmd.Parameters.Add(new OracleParameter("sent", newSentValue));
// loCmd.Parameters.Add(new OracleParameter("modifiedon", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
// loCmd.Parameters.Add(new OracleParameter("modifiedby", "email-api"));
// loCmd.Parameters.Add(new OracleParameter("emailqueueid", id));