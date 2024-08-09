using System;
using System.Data;
using System.Data.SqlClient;
using BRANDEXCL.Model;
using DataAccessLayer;
using System.Net;

namespace BRANDEXCL.DataAccess
{
    public partial class SaleDataAccess : SqlDataAccess
    {
        int ReturnValue = 0;
        private static SaleDataAccess instance = new SaleDataAccess();
        public static SaleDataAccess GetInstance
        {
            get
            {
                return instance;
            }
        }

        public string InsertSalesDetails(string data, string mobile, string email, string name)
        {
            string ReturnValue = string.Empty;
            try
            {
                using (SqlCommand InsertCommand = new System.Data.SqlClient.SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "SaleInsert" })
                {
                    InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                    InsertCommand.Parameters.Add(GetParameter("@BillNo", SqlDbType.VarChar, ReturnValue, 1000)).Direction = ParameterDirection.Output;
                    InsertCommand.Parameters.Add(GetParameter("@mobile", SqlDbType.VarChar, mobile));
                    InsertCommand.Parameters.Add(GetParameter("@email", SqlDbType.VarChar, email));
                    InsertCommand.Parameters.Add(GetParameter("@name", SqlDbType.VarChar, name));
                    InsertCommand.Parameters.Add(GetParameter("@productsaledata", SqlDbType.VarChar, data));

                    InsertCommand.Parameters.Add(GetParameter("@AddBy", SqlDbType.Int, Common.LoggedInUser[0].Usr_Id));
                    ExecuteStoredProcedure(InsertCommand);
                    ReturnValue = InsertCommand.Parameters[0].Value.ToString();
                    if (ReturnValue == "-1" || ReturnValue == "-2")
                    {
                        return ReturnValue;
                    }
                    else
                    {
                        ReturnValue = InsertCommand.Parameters[1].Value.ToString();
                        return ReturnValue;
                    }
                }
            }
            catch (Exception ex)
            {
                return ReturnValue;
            }
        }
        public DataTable latestbiinoselectproduct(string invoice)
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "latestbiinoselectproduct" })
            {
                SelectCommand.Parameters.Add(GetParameter("@outcode", SqlDbType.VarChar, Common.LoggedInUser[0].outcode));
                SelectCommand.Parameters.Add(GetParameter("@invoice", SqlDbType.VarChar, invoice));
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable SelectRateSale()
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "SelectRateSale" })
            {
                SelectCommand.Parameters.Add(GetParameter("@outcode", SqlDbType.VarChar, Common.LoggedInUser[0].outcode));
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable SaleReportSelectByDate(DateTime fromdate, DateTime todate)
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "ReportProductSale" })
            {
                SelectCommand.Parameters.Add(GetParameter("@outcode", SqlDbType.VarChar, Common.LoggedInUser[0].outcode));
                SelectCommand.Parameters.Add(GetParameter("@fromdate", SqlDbType.DateTime, fromdate));
                SelectCommand.Parameters.Add(GetParameter("@todate", SqlDbType.DateTime, todate));
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable ProfitAndLossSelectByDate(DateTime fromdate, DateTime todate)
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "ReportProfitAndLoss" })
            {
                SelectCommand.Parameters.Add(GetParameter("@outcode", SqlDbType.VarChar, Common.LoggedInUser[0].outcode));
                SelectCommand.Parameters.Add(GetParameter("@fromdate", SqlDbType.DateTime, fromdate));
                SelectCommand.Parameters.Add(GetParameter("@todate", SqlDbType.DateTime, todate));
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable GetCustomerDetailsByMobNo(string mobileno)
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "CustomerDetailsByMobNo" })
            {
                SelectCommand.Parameters.Add(GetParameter("@outcode", SqlDbType.VarChar, Common.LoggedInUser[0].outcode));
                SelectCommand.Parameters.Add(GetParameter("@mobileno", SqlDbType.VarChar, mobileno));
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable GetAllSoldProducts()
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "GetAllSoldProducts" })
            {
                SelectCommand.Parameters.Add(GetParameter("@outcode", SqlDbType.VarChar, Common.LoggedInUser[0].outcode));
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable GetProfitAndLossDetails() 
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "GetProfitAndLossDetails" })
            {
                SelectCommand.Parameters.Add(GetParameter("@outcode", SqlDbType.VarChar, Common.LoggedInUser[0].outcode));
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        
    }
}

