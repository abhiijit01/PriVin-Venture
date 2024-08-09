using System;
using System.Data;
using System.Data.SqlClient;
using BOL;
using DataAccessLayer;
using System.Net;
using System.Collections.Generic;

namespace DAL
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

        public string InsertSalesDetails(string data, string mobile, string email, string name,int couponid)
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
                    InsertCommand.Parameters.Add(GetParameter("@outcode", SqlDbType.VarChar, Common.LoggedInUser[0].outcode));
                    InsertCommand.Parameters.Add(GetParameter("@AddBy", SqlDbType.Int, Common.LoggedInUser[0].Usr_Id));
                    InsertCommand.Parameters.Add(GetParameter("@couponid", SqlDbType.Int, couponid));
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
        public DataTable latestbiinoselectproduct(string invoice,string mobileno)
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "latestbiinoselectproduct" })
            {
                SelectCommand.Parameters.Add(GetParameter("@outcode", SqlDbType.VarChar, Common.LoggedInUser[0].outcode));
                SelectCommand.Parameters.Add(GetParameter("@invoice", SqlDbType.VarChar, invoice));
                SelectCommand.Parameters.Add(GetParameter("@mobileno", SqlDbType.VarChar, mobileno));
                return ExecuteGetDataTable(SelectCommand);
            }
        } 
        public DataTable latestexchbiinoselectproduct(string invoice, string mobileno)
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "latestbiinoselectproduct" })
            {
                SelectCommand.Parameters.Add(GetParameter("@outcode", SqlDbType.VarChar, Common.LoggedInUser[0].outcode));
                SelectCommand.Parameters.Add(GetParameter("@invoice", SqlDbType.VarChar, invoice));
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable GetInvoicesByMobileOrInvoice(string invoice, string mobileno)
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "SaleActions" })
            {
                SelectCommand.Parameters.Add(GetParameter("@action", SqlDbType.VarChar, "invoices"));
                SelectCommand.Parameters.Add(GetParameter("@outcode", SqlDbType.VarChar, Common.LoggedInUser[0].outcode));
                SelectCommand.Parameters.Add(GetParameter("@invoices", SqlDbType.VarChar, invoice));
                SelectCommand.Parameters.Add(GetParameter("@mobileno", SqlDbType.VarChar, mobileno));
                SelectCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
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
            string outcode = string.Empty;
            try
            {
                outcode = Common.LoggedInUser[0].outcode;
            }
            catch
            {
                outcode = "O0002";
            }
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "GetAllSoldProducts" })
            {
                SelectCommand.Parameters.Add(GetParameter("@outcode", SqlDbType.VarChar, outcode));
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable GetProfitAndLossDetails() 
        {
            string outcode = string.Empty;
            try
            {
                outcode = Common.LoggedInUser[0].outcode;
            }
            catch
            {
                outcode = "O0002";
            }
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "GetProfitAndLossDetails" })
            {
                SelectCommand.Parameters.Add(GetParameter("@outcode", SqlDbType.VarChar, outcode));
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable GetAllSaleByInvoiceno(string invoice)
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "SaleActions" })
            {
                SelectCommand.Parameters.Add(GetParameter("@action", SqlDbType.VarChar, "sales"));
                SelectCommand.Parameters.Add(GetParameter("@invoices", SqlDbType.VarChar, invoice));
                SelectCommand.Parameters.Add(GetParameter("@outcode", SqlDbType.VarChar, Common.LoggedInUser[0].outcode));
                SelectCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable GetOfferDetailsByCouponCode(string couponcode)
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "CouponCodeSelectAll" })
            {
                SelectCommand.Parameters.Add(GetParameter("@action", SqlDbType.VarChar, "ODC"));
                SelectCommand.Parameters.Add(GetParameter("@outcode", SqlDbType.VarChar, Common.LoggedInUser[0].outcode));
                SelectCommand.Parameters.Add(GetParameter("@couponcode", SqlDbType.VarChar, couponcode));
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public string InsertExchangeData(string data)
        {
            string ReturnValue = string.Empty;
            try
            {
                using (SqlCommand InsertCommand = new System.Data.SqlClient.SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "ExchangeInsert" })
                {
                    InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                    InsertCommand.Parameters.Add(GetParameter("@BillNo", SqlDbType.VarChar, ReturnValue, 1000)).Direction = ParameterDirection.Output;
                    InsertCommand.Parameters.Add(GetParameter("@productsaledata", SqlDbType.VarChar, data));
                    InsertCommand.Parameters.Add(GetParameter("@outcode", SqlDbType.VarChar, Common.LoggedInUser[0].outcode));
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
    }
}

