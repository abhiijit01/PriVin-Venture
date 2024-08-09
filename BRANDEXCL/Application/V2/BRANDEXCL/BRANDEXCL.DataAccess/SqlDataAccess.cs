
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace DataAccessLayer
{
    public abstract class SqlDataAccess
    {
        #region Declaration
        private sealed class ConnectionFactory
        {
            private readonly static ConnectionFactory _instance = new ConnectionFactory();

            public static ConnectionFactory GetInstance
            {
                get
                {
                    return _instance;
                }
            }
            //SqlConnection GetConnection()
            public SqlConnection GetConnection()
            {
                SqlConnection TheLocalConnection = new SqlConnection("data source=A2NWPLSK14SQL-v02.shr.prod.iad2.secureserver.net; Initial Catalog=BRANDEXCL;User ID=smartme;password=smartme@Ap;Connect Timeout=15;Encrypt=False;Packet Size=4096;");
                return TheLocalConnection;
            }
            public Tuple<SqlConnection> GetConnectiononline()
            {

                SqlConnection TheConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["dpconnection"].ConnectionString);
                //SqlConnection TheLocalConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Localconnection"].ConnectionString);
                // return TheConnection;
                var result = Tuple.Create(TheConnection);
                return result;


            }

            public void CloseConnection(SqlConnection connection)
            {
                if (connection != null)
                {
                    if (connection.State.Equals(ConnectionState.Open))
                    {
                        connection.Close();
                    }
                    connection.Dispose();
                }
            }
        }
        private sealed class ConnectionFactoryOnline
        {
            private readonly static ConnectionFactoryOnline _instance = new ConnectionFactoryOnline();

            public static ConnectionFactoryOnline GetInstance
            {
                get
                {
                    return _instance;
                }
            }
            //SqlConnection GetConnection()
            public Tuple<SqlConnection, SqlConnection> GetConnection()
            {

                SqlConnection TheConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["dpconnection"].ConnectionString);
                SqlConnection TheLocalConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Localconnection"].ConnectionString);
                // return TheConnection;
                var result = Tuple.Create(TheConnection, TheLocalConnection);
                return result;


            }


            public SqlConnection GetConnectiononline()
            {
                SqlConnection TheConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["dpconnection"].ConnectionString);

                return TheConnection;
            }


            public void CloseConnection(SqlConnection connection)
            {
                if (connection != null)
                {
                    if (connection.State.Equals(ConnectionState.Open))
                    {
                        connection.Close();
                    }
                    connection.Dispose();
                }
            }
        }
        #endregion

        #region Methods & Implementation
        protected DataTable ExecuteGetDataTable(SqlCommand command)
        {
            DataTable TheDataTable = new DataTable();

            using (DataSet TheDataSet = new DataSet())
            {
                using (SqlDataAdapter TheDataAdapter = new SqlDataAdapter())
                {
                    try
                    {
                        SqlConnection result = ConnectionFactory.GetInstance.GetConnection();
                        command.Connection = result;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 5000;
                        command.Connection.Open();
                        TheDataAdapter.SelectCommand = command;
                        TheDataAdapter.Fill(TheDataSet);


                        if (TheDataSet.Tables.Count > 0)
                            TheDataTable = TheDataSet.Tables[0];
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        ConnectionFactory.GetInstance.CloseConnection(command.Connection);
                    }
                }
            }

            return TheDataTable;
        }

        protected DataRow ExecuteGetDataRow(SqlCommand command)
        {
            DataRow TheDataRow = null;

            using (DataSet TheDataSet = new DataSet())
            {
                using (SqlDataAdapter TheDataAdapter = new SqlDataAdapter())
                {
                    try
                    {
                        SqlConnection result = ConnectionFactory.GetInstance.GetConnection();
                        command.Connection = result;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 300;
                        command.Connection.Open();

                        TheDataAdapter.SelectCommand = command;
                        TheDataAdapter.Fill(TheDataSet);

                        if (TheDataSet.Tables.Count != 0
                            && TheDataSet.Tables[0].Rows.Count != 0)
                            TheDataRow = TheDataSet.Tables[0].Rows[0];
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        ConnectionFactory.GetInstance.CloseConnection(command.Connection);
                    }
                }
            }

            return TheDataRow;
        }

        protected void ExecuteStoredProcedure(SqlCommand command)
        {
            try
            {
                SqlConnection result = ConnectionFactory.GetInstance.GetConnection();
                command.Connection = result;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 300;
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionFactory.GetInstance.CloseConnection(command.Connection);
            }
        }


        //excute connection for online
        protected void ExecuteStoredProcedureonlyoneline(SqlCommand command)
        {
            try
            {
                command.Connection = ConnectionFactoryOnline.GetInstance.GetConnectiononline();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 300;
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionFactory.GetInstance.CloseConnection(command.Connection);
            }
        }
        protected void ExecuteLocalStoredProcedure(SqlCommand command)
        {
            try
            {
                SqlConnection result = ConnectionFactory.GetInstance.GetConnection();
                command.Connection = result;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 300;
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionFactory.GetInstance.CloseConnection(command.Connection);
            }
        }
        protected void ExecuteStoredProcedure(SqlCommand[] commandList)
        {
            SqlConnection result = ConnectionFactory.GetInstance.GetConnection();
            SqlConnection TheConnection = result;
            SqlTransaction TheTransaction = null;

            try
            {
                TheConnection.Open();
                TheTransaction = TheConnection.BeginTransaction();

                foreach (SqlCommand TheCommand in commandList)
                {
                    TheCommand.CommandType = CommandType.StoredProcedure;
                    TheCommand.Transaction = TheTransaction;
                    TheCommand.Connection = TheConnection;
                    TheCommand.CommandTimeout = 300;
                    TheCommand.Connection.Open();
                    TheCommand.ExecuteNonQuery();
                }

                TheTransaction.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionFactory.GetInstance.CloseConnection(TheConnection);
            }
        }
        protected void ExecuteLocalStoredProcedure(SqlCommand[] commandList)
        {
            SqlConnection result = ConnectionFactory.GetInstance.GetConnection();
            SqlConnection TheConnection = result;
            SqlTransaction TheTransaction = null;

            try
            {
                TheConnection.Open();
                TheTransaction = TheConnection.BeginTransaction();

                foreach (SqlCommand TheCommand in commandList)
                {
                    TheCommand.CommandType = CommandType.StoredProcedure;
                    TheCommand.Transaction = TheTransaction;
                    TheCommand.Connection = TheConnection;
                    TheCommand.CommandTimeout = 300;
                    TheCommand.Connection.Open();
                    TheCommand.ExecuteNonQuery();
                }

                TheTransaction.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionFactory.GetInstance.CloseConnection(TheConnection);
            }
        }

        protected SqlParameter GetParameter(String parameterName, SqlDbType parameterDataType, object parameterValue)
        {
            return GetParameter(parameterName, parameterDataType, parameterValue, 0);
        }

        protected SqlParameter GetParameter(string parameterName, SqlDbType parameterDataType, object parameterValue, int parameterSize)
        {
            SqlParameter TheParameter = new SqlParameter
            {
                ParameterName = parameterName,
                SqlDbType = parameterDataType
            };

            if (parameterDataType.Equals(SqlDbType.VarChar))
                TheParameter.Value = (parameterValue == null) ? "" : (string)parameterValue;
            else
                TheParameter.Value = parameterValue;

            if (parameterDataType.Equals(SqlDbType.Int))
                if (parameterSize != 0)
                    TheParameter.Size = parameterSize;

            if (parameterDataType.Equals(SqlDbType.VarChar))
                if (parameterSize != 0)
                    TheParameter.Size = parameterSize;

            TheParameter.Direction = ParameterDirection.Input;

            return TheParameter;
        }
        #endregion
    }
}
