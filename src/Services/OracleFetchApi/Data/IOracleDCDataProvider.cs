namespace OracleFetchApi.Data;

public interface IOracleDCDataProvider
{
    void Close();
    OracleTransaction BeginTransaction();
    IDataReader GetReader(OracleCommand qry);
    OracleDataSet GetDataSet(OracleCommand qry);
    object ExecuteScalar(OracleCommand poQuery);
    public int ExecuteQuery(OracleCommand poQuery);
    Task<List<string>> GetColumnNamesAsync();
}
