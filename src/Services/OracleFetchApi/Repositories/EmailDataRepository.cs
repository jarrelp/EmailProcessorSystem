using System.Xml.Linq;
using AutoMapper;
using EventBus.Extensions;
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

  public async Task<List<EmailQueueItem>> GetXmlData(int count = 10)
  {
      var emailQueues = new List<EmailQueueItem>();

      OracleDataSet loDS = _oracleDCDataprovider.GetDataSet(new OracleCommand($"select * from (select * from gnt_emailqueue order by emailqueueid desc) where rownum < {count}"));
      DataTable loDT = loDS.Tables[0];

      foreach (DataRow loRow in loDT.Rows)
      {
            var emailQueue = new EmailQueueItem
            {
                // XmlData = _mapper.Map<XmlData>(loRow["xmldata"].ToString())

                XmlData = ConvertXmlData(loRow["xmldata"].ToString())
            };

            emailQueues.Add(emailQueue);
      }

      return emailQueues;
  }

  private XmlData ConvertXmlData(string xmlData)
  {
      if (string.IsNullOrEmpty(xmlData))
          return null;

      try
      {
          var doc = XDocument.Parse(xmlData);
          var root = doc.Root.Name.LocalName;

          switch (root)
          {
              case "login":
                  return XmlData.DeserializeXml<Login>(xmlData);
              case "overdue":
                  return XmlData.DeserializeXml<Overdue>(xmlData);
              case "report":
                  return XmlData.DeserializeXml<Report>(xmlData);
              case "user":
                  // Parse de XML-string naar een XElement
      XElement element = XElement.Parse(xmlData);

      // Maak een nieuw User-object en vul de eigenschappen in
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

  public async Task<List<EmailQueueItem>> GetTopEmailQueueItemsAsync(int count = 10)
  {
      var emailQueues = new List<EmailQueueItem>();

      OracleDataSet loDS = _oracleDCDataprovider.GetDataSet(new OracleCommand($"select * from (select * from gnt_emailqueue order by emailqueueid desc) where rownum < {count}"));
      DataTable loDT = loDS.Tables[0];

      foreach (DataRow loRow in loDT.Rows)
      {
            var emailQueue = new EmailQueueItem
            {
                EmailQueueId = Int32.Parse(loRow["emailqueueid"].ToString().Trim()),
                // XmlData = DeserializeXmlData(loRow["xmldata"].ToString()),
                // XmlData = loRow["xmldata"].ToString(),
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
                // Mapping XmlData to corresponding data model
                XmlData = _mapper.Map<XmlData>(loRow["xmldata"].ToString())
            };

            emailQueues.Add(emailQueue);
      }

      return emailQueues;
  }

//   private XmlData DeserializeXmlData(string xmlData)
// {
//     if (string.IsNullOrEmpty(xmlData))
//         return null;

//     try
//     {
//         var doc = XDocument.Parse(xmlData);
//         var root = doc.Root.Name.LocalName;

//         switch (root)
//         {
//             case "login":
//                 return DeserializeXml<Login>(xmlData);
//             case "overdue":
//                 return DeserializeXml<Overdue>(xmlData);
//             case "report":
//                 return DeserializeXml<Report>(xmlData);
//             case "user":
//                 return DeserializeXml<User>(xmlData);
//             default:
//                 throw new InvalidOperationException("Unknown XML data type.");
//         }
//     }
//     catch (Exception ex)
//     {
//         Console.WriteLine($"Error deserializing XML data: {ex.Message}");
//         return null;
//     }
// }

// private T DeserializeXml<T>(string xmlData) where T : XmlData
// {
//     var serializer = new XmlSerializer(typeof(T));
//     using (var reader = new StringReader(xmlData))
//     {
//         return (T)serializer.Deserialize(reader);
//     }
// }

  public void GetAll()
  {
    OracleDataSet loDS = _oracleDCDataprovider.GetDataSet(new OracleCommand($"select * from (select * from gnt_emailqueue order by emailqueueid desc) where rownum < 10"));
    DataTable loDT = loDS.Tables[0];

    foreach (DataRow loRow in loDT.Rows)
    {
      Console.WriteLine($"{loRow["emailqueueid"]}     {loRow["sent"]}   {loRow["sendat"]}    {loRow["xslname"]}   {loRow["email"]}   {loRow["modified_on"]}    {loRow["modified_by"]}    {loRow["attempts"]}");
    }

    Console.WriteLine("");
    Console.WriteLine("");

    foreach (DataRow loRow in loDT.Rows)
    {
      Console.WriteLine("");
      Console.WriteLine($"{loRow["xmldata"]}");
    }


  }

  public void GetAllNotPickedUp()
  {
    OracleDataSet loDS = _oracleDCDataprovider.GetDataSet(new OracleCommand($"select * from (select * from gnt_emailqueue order by emailqueueid desc) where sent  = 'N'"));
    DataTable loDT = loDS.Tables[0];

    foreach (DataRow loRow in loDT.Rows)
    {
      Console.WriteLine($"{loRow["emailqueueid"]}     {loRow["sent"]}   {loRow["sendat"]}    {loRow["xslname"]}   {loRow["email"]}   {loRow["modified_on"]}    {loRow["modified_by"]}    {loRow["attempts"]}");
    }
  }

  public void GetByEmailQueueId(int id)
  {
    OracleDataSet loDS = _oracleDCDataprovider.GetDataSet(new OracleCommand($"select * from gnt_emailqueue where emailqueueid = {id}"));
    DataTable loDT = loDS.Tables[0];

    if (loDT.Rows.Count == 0)
    {
      Console.WriteLine($"Geen item gevonden met emailqueueId: {id}");
      return;
    }

    DataRow loRow = loDT.Rows[0];

    Console.WriteLine($"{loRow["emailqueueid"]}     {loRow["sent"]}   {loRow["sendat"]}    {loRow["xslname"]}   {loRow["email"]}");
  }

  // public void SetSent(int id, string newSentValue)
  // {
  //   OracleCommand loCmd = new OracleCommand("UPDATE gnt_emailqueue SET sent = :sent, modified_on = :modifiedon, modified_by = 'EmailApi' WHERE emailqueueid = :emailqueueid");
  //   loCmd.Parameters.Add(new OracleParameter("sent", newSentValue));
  //   loCmd.Parameters.Add(new OracleParameter("modifiedon", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
  //   loCmd.Parameters.Add(new OracleParameter("emailqueueid", id));
  //   loCmd.Parameters.Add(new OracleParameter("emailqueueid", id));

  //   // OracleCommand loCmd = new OracleCommand($"UPDATE gnt_emailqueue SET sent = '{newSentValue}', modified_on = TO_DATE('{DateTime.Now:yyyy-MM-dd HH:mm:ss}', 'YYYY-MM-DD HH24:MI:SS'), modified_by = 'EmailApi' WHERE emailqueueid = {id}");
  //   _oracleDCDataprovider.ExecuteQuery(loCmd);
  // }

  public void SetSent(int id, string newSentValue)
  {
    // OracleCommand loCmd = new OracleCommand("UPDATE gnt_emailqueue SET sent = :sent, modified_on = :modifiedon, modified_by = 'EmailApi' WHERE emailqueueid = :emailqueueid");
    // loCmd.Parameters.Add(new OracleParameter("sent", newSentValue));
    // loCmd.Parameters.Add(new OracleParameter("modifiedon", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
    // loCmd.Parameters.Add(new OracleParameter("modifiedby", "email-api"));
    // loCmd.Parameters.Add(new OracleParameter("emailqueueid", id));
    OracleCommand loCmd = new OracleCommand($"UPDATE gnt_emailqueue SET sent = '{newSentValue}', modified_on = TO_DATE('{DateTime.Now:yyyy-MM-dd HH:mm:ss}', 'YYYY-MM-DD HH24:MI:SS'), modified_by = 'EmailApi' WHERE emailqueueid = {id}");

    _oracleDCDataprovider.ExecuteQuery(loCmd);
  }


  public async Task<List<string>> GetColumnNamesAsync()
  {
    var columnNames = await _oracleDCDataprovider.GetColumnNamesAsync();
    return columnNames;
  }
}