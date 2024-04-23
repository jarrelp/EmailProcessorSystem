namespace OracleFetchApi.Repositories;

public class EmailDataRepository : IEmailDataRepository
{
  private readonly IOracleDCDataProvider _oracleDCDataprovider;

  public EmailDataRepository(IOracleDCDataProvider oracleDCDataProvider)
  {
    _oracleDCDataprovider = oracleDCDataProvider;
  }

  public void GetAll()
  {
    OracleDataSet loDS = _oracleDCDataprovider.GetDataSet(new OracleCommand($"select * from (select * from gnt_emailqueue order by emailqueueid desc) where rownum < 10"));
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
    OracleCommand loCmd = new OracleCommand("UPDATE gnt_emailqueue SET sent = :sent, modified_on = :modifiedon, modified_by = 'EmailApi' WHERE emailqueueid = :emailqueueid");
    loCmd.Parameters.Add(new OracleParameter("sent", newSentValue));
    loCmd.Parameters.Add(new OracleParameter("modifiedon", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
    loCmd.Parameters.Add(new OracleParameter("modifiedby", "email-api"));
    loCmd.Parameters.Add(new OracleParameter("emailqueueid", id));

    _oracleDCDataprovider.ExecuteQuery(loCmd);
  }


  public async Task<List<string>> GetColumnNamesAsync()
  {
    var columnNames = await _oracleDCDataprovider.GetColumnNamesAsync();
    return columnNames;
  }
}