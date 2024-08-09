using BOL;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BrandDataAccess : SqlDataAccess
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static BrandDataAccess instance = new BrandDataAccess();
        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static BrandDataAccess GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Methods & Implementation

        public int InsertBrand(Brand theRole)
        {
            int ReturnValue = 0;
            using (SqlCommand InsertCommand = new System.Data.SqlClient.SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "BrandInsert" })
            {
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@brandname", SqlDbType.VarChar, theRole.brandname));
                InsertCommand.Parameters.Add(GetParameter("@AddBy", SqlDbType.Int, Common.LoggedInUser[0].Usr_Id));

                ExecuteStoredProcedure(InsertCommand);

                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }



        public int UpdateBrand(Brand theRole)
        {
            int ReturnValue = 0;
            using (SqlCommand UpdateCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "BrandUpdate" })
            {
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@brandid", SqlDbType.Int, theRole.brandid));
                UpdateCommand.Parameters.Add(GetParameter("@brandname", SqlDbType.VarChar, theRole.brandname));
                UpdateCommand.Parameters.Add(GetParameter("@Modby", SqlDbType.Int, Common.LoggedInUser[0].Usr_Id));
                ExecuteStoredProcedure(UpdateCommand);

                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }

        public DataTable GetBrandList()

        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "BrandselectAll" })
            {
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataRow GetBrandById(int outid)
        {

            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "BrandselectByID" })
            {
                SelectCommand.Parameters.Add(GetParameter("@brandid", SqlDbType.Int, outid));
                return ExecuteGetDataRow(SelectCommand);
            }
        }
        public DataTable DeleteBrand(string outid)
        {
            using (SqlCommand DeleteCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "BrandDelete" })
            {
                DeleteCommand.Parameters.Add(GetParameter("@PXMLTABLE", SqlDbType.VarChar, outid));
                // DeleteCommand.Parameters.Add(GetParameter("@RoleID", SqlDbType.Int, RoleID));
                return ExecuteGetDataTable(DeleteCommand);
            }
        }



        #endregion
    }
}
