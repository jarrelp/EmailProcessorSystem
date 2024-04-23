namespace OracleFetchApi.Data;

public class OracleDCDataProvider : IOracleDCDataProvider
{
    private OracleConnection dbConnection;

    public OracleDCDataProvider(string connectionString)
    {
        CreateConnection(connectionString);
    }

    private void CreateConnection(string newConnectionString)
    {
        OracleConnection retVal = new OracleConnection(newConnectionString)
        {
            Unicode = true
        };
        retVal.Open();

        // Zorg dat de NLS settings van de connection juist zijn
        OracleGlobalization loSessionInfo = retVal.GetSessionInfo();
        loSessionInfo.Language = "AMERICAN";
        loSessionInfo.Territory = "AMERICA";
        loSessionInfo.Currency = "$";
        loSessionInfo.ISOCurrency = "AMERICA";
        loSessionInfo.NumericCharacters = ".,";
        //loSessionInfo.Calendar = "GREGORIAN";
        loSessionInfo.DateFormat = "DD-MON-RR";
        loSessionInfo.DateLanguage = "AMERICAN";
        //loSessionInfo.Sort = "BINARY";
        //loSessionInfo.timeformat = "";
        loSessionInfo.TimeStampFormat = "DD-MON-RR HH.MI.SSXFF AM";
        //loSessionInfo.timetzformat = "";
        loSessionInfo.TimeStampTZFormat = "DD-MON-RR HH.MI.SSXFF AM TZR";
        loSessionInfo.DualCurrency = "$";
        //loSessionInfo.Comparison = "BINARY";
        //loSessionInfo.LengthSemantics = "BYTE";
        loSessionInfo.NCharConversionException = false;
        retVal.SetSessionInfo(loSessionInfo);

        dbConnection = retVal;
    }

    public async Task<List<string>> GetColumnNamesAsync()
    {
        List<string> columnNames = new List<string>();

        using (dbConnection)
        {
            await dbConnection.OpenAsync();

            string sql = $@"
            SELECT column_name
            FROM all_tab_columns
            WHERE table_name = 'GNT_EMAILQUEUE'";

            using (var command = new OracleCommand(sql, dbConnection))
            {
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        string columnName = reader.GetString(0);
                        columnNames.Add(columnName);
                    }
                }
            }

            // IDataReader reader = GetReader(new OracleCommand(sql, dbConnection));
        }

        return columnNames;
    }

    // using (OracleConnection conn = new OracleConnection(connectionString))
    // {
    //     conn.Open();
    //     string tableName = "GNT_EMAILQUEUE";
    //     string sql = $@"
    //     SELECT column_name
    //     FROM all_tab_columns
    //     WHERE table_name = '{tableName}'";

    //     using (OracleCommand cmd = new OracleCommand(sql, conn))
    //     {
    //         using (OracleDataReader reader = cmd.ExecuteReader())
    //         {
    //             while (reader.Read())
    //             {
    //                 string columnName = reader["column_name"].ToString();
    //                 Console.WriteLine(columnName);
    //             }
    //         }
    //     }
    // }

    public void Close()
    {
        dbConnection.Close();
    }

    public OracleTransaction BeginTransaction()
    {
        return dbConnection.BeginTransaction();
    }

    static void AddParams(OracleCommand cmd, OracleCommand qry)
    {
        if (qry.Parameters != null)
        {
            foreach (OracleParameter param in qry.Parameters)
            {
                OracleParameter sqlParam = new OracleParameter
                {
                    Direction = param.Direction,
                    DbType = param.DbType
                };

                if (sqlParam.Direction == ParameterDirection.Output || sqlParam.Direction == ParameterDirection.InputOutput)
                {
                    sqlParam.Size = param.Size;
                }

                // Evert, zie https://forums.oracle.com/thread/408872
                // sqlParam.OracleDbType = GetOracleType(param.DataType);
                if (param.DbType == DbType.Object)
                {
                    sqlParam.OracleDbType = param.OracleDbType;
                }

                sqlParam.ParameterName = param.ParameterName;
                sqlParam.Value = param.Value;
                cmd.Parameters.Add(sqlParam);
            }
        }
    }

    protected string LogVerbose(string method, OracleCommand qry, long duration = -1)
    {
        string lsDuration = "";
        if (duration > -1)
        {
            lsDuration = " Duration (ms): " + duration + (duration > 1000 ? " ***" : "");
        }
        string lsParams = "";
        if (qry.Parameters.Count > 0)
        {
            lsParams += " Params: ";
            foreach (OracleParameter param in qry.Parameters)
            {
                lsParams += "[" + param.ParameterName + "," + param.Value + "] ";
            }
        }
        return method + " " + lsDuration + " " + qry.CommandText + lsParams;
    }

    public IDataReader GetReader(OracleCommand qry)
    {
        System.Diagnostics.Stopwatch loSW = null;
        loSW = new System.Diagnostics.Stopwatch();
        loSW.Start();

        IDataReader rdr;

        using (OracleCommand cmd = new OracleCommand(qry.CommandText))
        {
            //cmd.BindByName = true;
            cmd.CommandType = qry.CommandType;

            AddParams(cmd, qry);
            cmd.Connection = dbConnection;

            try
            {
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (OracleException Ex)
            {
                throw Ex;
            }
            finally
            {
                loSW.Stop();
            }
        }

        return rdr;
    }

    public OracleDataSet GetDataSet(OracleCommand qry)
    {
        System.Diagnostics.Stopwatch loSW = null;
        loSW = new System.Diagnostics.Stopwatch();
        loSW.Start();

        OracleDataSet ds = new OracleDataSet();
        OracleCommand cmd = new OracleCommand(qry.CommandText)
        {
            //cmd.BindByName = true;
            CommandType = qry.CommandType
        };
        OracleDataAdapter da = new OracleDataAdapter(cmd);
        using (dbConnection)
        {
            cmd.Connection = dbConnection;
            AddParams(cmd, qry);
            try
            {
                da.Fill(ds);
            }
            catch (Exception e)
            {
                if (e.Message.Contains("ORA-04068") || e.Message.Contains("ORA-04061") || e.Message.Contains("ORA-04065"))
                {
                    da.Fill(ds);
                }
            }

            cmd.Dispose();
            da.Dispose();

            loSW.Stop();

            return ds;
        }
    }

    public object ExecuteScalar(OracleCommand poQuery)
    {
        return ExecuteScalar(poQuery, null);
    }

    public object ExecuteScalar(OracleCommand poQuery, OracleTransaction poTransaction)
    {
        System.Diagnostics.Stopwatch loSW = null;
        loSW = new System.Diagnostics.Stopwatch();
        loSW.Start();

        using (dbConnection)
        {
            object loResult = null;
            poQuery.Connection = dbConnection;
            if (poTransaction != null)
            {
                poQuery.Transaction = poTransaction;
            }
            loResult = poQuery.ExecuteScalar();

            // Marc added: 
            // The SQLServer version of ExcuteScalar ...Executes the query, and returns the first column
            // of the first row of the resultset returned. Additional colums or rows are
            // ignored...
            // The following simulates the same behaviour (getting the primary key)
            //
            foreach (OracleParameter param in poQuery.Parameters)
            {
                if (param.Direction == ParameterDirection.Output)
                {
                    loResult = param.Value;
                    break;
                }
            }
            loSW.Stop();

            return loResult;
        }
    }

    public int ExecuteQuery(OracleCommand poQuery)
    {
        return ExecuteQuery(poQuery, null);
    }

    public int ExecuteQuery(OracleCommand poQuery, OracleTransaction poTransaction)
    {
        System.Diagnostics.Stopwatch loSW = null;
        loSW = new System.Diagnostics.Stopwatch();
        loSW.Start();

        using (dbConnection)
        {
            if (poTransaction != null)
            {
                poQuery.Transaction = poTransaction;
            }

            poQuery.Connection = dbConnection;
            // Modified Marc: 6-12-2007
            // CheckoutOutputParams added
            //
            int result = -1;
            try
            {
                result = poQuery.ExecuteNonQuery();
            }
            catch (Exception)
            {
                // Catch to be able to debug-log the query, otherwise we have no clue what values caused the exception
                loSW.Stop();

                throw;
            }
            loSW.Stop();

            return result;
        }
    }
}