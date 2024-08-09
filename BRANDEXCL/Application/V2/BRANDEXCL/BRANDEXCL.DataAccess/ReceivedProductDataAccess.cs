using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;
using BRANDEXCL.Model;
using System.Net;

namespace BRANDEXCL.DataAccess
{
    public partial class ReceivedProductDataAccess : SqlDataAccess
    {
        int ReturnValue = 0;
        #region This code is for making it singleton application
        /// <summary>
        /// private static member to implement singleton design pattern
        /// </summary>
        private static ReceivedProductDataAccess instance = new ReceivedProductDataAccess();
        ///<summary>
        ///static property of the class which will provide the sinleton instance of it
        ///</summary>
        public static ReceivedProductDataAccess GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion
        #region Methods nad implementation
        public int InsertReceivedProduct(string data)
        {
            try
            {
                int ReturnValue = 0;
                using (SqlCommand InsertCommand = new System.Data.SqlClient.SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "ProductRecieveInsertNEW" })
                {
                    InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                    InsertCommand.Parameters.Add(GetParameter("@productrecievedata", SqlDbType.VarChar, data));
                    InsertCommand.Parameters.Add(GetParameter("@AddBy", SqlDbType.Int, Common.LoggedInUser[0].Usr_Id));
                    ExecuteStoredProcedure(InsertCommand);
                    ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                    return ReturnValue;
                }
            }
            catch (Exception ex)
            {
                return ReturnValue;
            }
        }
        public int UpdateReceivedProduct(ReceivedProduct TheReceivedProduct)
        {
            int ReturnValue = 0;
            using (SqlCommand UpdateCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "ReceivedProductUpdate" })
            {
                UpdateCommand.Parameters.Add(GetParameter("@Returnvalue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@purchid", SqlDbType.Int, TheReceivedProduct.purchid));
                UpdateCommand.Parameters.Add(GetParameter("@prodname", SqlDbType.VarChar, TheReceivedProduct.prodname));
                UpdateCommand.Parameters.Add(GetParameter("@descr", SqlDbType.VarChar, TheReceivedProduct.proddescr));
                UpdateCommand.Parameters.Add(GetParameter("@qty", SqlDbType.Int, TheReceivedProduct.qty));
                UpdateCommand.Parameters.Add(GetParameter("@unitprice", SqlDbType.Decimal, TheReceivedProduct.unitprice));
                UpdateCommand.Parameters.Add(GetParameter("@purchprice", SqlDbType.Decimal, TheReceivedProduct.purchprice));
                UpdateCommand.Parameters.Add(GetParameter("@modby", SqlDbType.Int, Common.LoggedInUser[0].Usr_Id));
                ExecuteStoredProcedure(UpdateCommand);
                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
                return ReturnValue;

            }
        }
        public int UpdateReceivedProductqty(string barcode,int sizeid, int qty)
        {
            int ReturnValue = 0;
            using (SqlCommand UpdateCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "ReceivedProductqtyUpdate" })
            {
                UpdateCommand.Parameters.Add(GetParameter("@Returnvalue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@barcode", SqlDbType.VarChar, barcode));
                UpdateCommand.Parameters.Add(GetParameter("@sizeid", SqlDbType.Int, sizeid));
                UpdateCommand.Parameters.Add(GetParameter("@qty", SqlDbType.Int, qty));
                UpdateCommand.Parameters.Add(GetParameter("@modby", SqlDbType.Int, Common.LoggedInUser[0].Usr_Id));
                ExecuteStoredProcedure(UpdateCommand);
                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
                return ReturnValue;

            }
        }

        public DataTable DeleteReceivedProduct(string purchid)
        {
            using (SqlCommand DeleteCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "ReceivedProductDelete" })
            {
                DeleteCommand.Parameters.Add(GetParameter("@PXMLTABLE", SqlDbType.VarChar, purchid));
                return ExecuteGetDataTable(DeleteCommand);
            }
        }
        public DataTable GetAllReceivedProdByInvoiceno(string invoiceno)
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "GetAllReceivedProductByInvoiceno" })
            {
                SelectCommand.Parameters.Add(GetParameter("@invoiceno", SqlDbType.VarChar, invoiceno));
                SelectCommand.Parameters.Add(GetParameter("@outcode", SqlDbType.VarChar, Common.LoggedInUser[0].outcode));
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable GetAllInvoiceDetails()
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "GetReceiveAllInvoiceDetails" })
            {
                SelectCommand.Parameters.Add(GetParameter("@outcode", SqlDbType.VarChar, Common.LoggedInUser[0].outcode));
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable ReceiveReportSelectByDate(DateTime fromdate, DateTime todate)
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "ReportProductRecieve" })
            {
                SelectCommand.Parameters.Add(GetParameter("@outcode", SqlDbType.VarChar, Common.LoggedInUser[0].outcode));
                SelectCommand.Parameters.Add(GetParameter("@fromdate", SqlDbType.DateTime, fromdate));
                SelectCommand.Parameters.Add(GetParameter("@todate", SqlDbType.DateTime, todate));
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable GetAllReceivedProducts()
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "GetAllReceivedProducts" })
            {
                SelectCommand.Parameters.Add(GetParameter("@outcode", SqlDbType.VarChar,Common.LoggedInUser[0].outcode));
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        #endregion

    }
}
