using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace DAL
{
    public class CategoryDataAccess : SqlDataAccess
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static CategoryDataAccess instance = new CategoryDataAccess();
        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static CategoryDataAccess GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Methods & Implementation

        public int InsertCategory(Category theRole)
        {
            int ReturnValue = 0;
            using (SqlCommand InsertCommand = new System.Data.SqlClient.SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "CategoryInsert" })
            {
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@catname", SqlDbType.VarChar, theRole.catname));
                InsertCommand.Parameters.Add(GetParameter("@AddBy", SqlDbType.Int, Common.LoggedInUser[0].Usr_Id));

                ExecuteStoredProcedure(InsertCommand);

                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }



        public int UpdateCategory(Category theRole)
        {
            int ReturnValue = 0;
            using (SqlCommand UpdateCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "CategoryUpdate" })
            {
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@catid", SqlDbType.Int, theRole.catid));
                UpdateCommand.Parameters.Add(GetParameter("@catname", SqlDbType.VarChar, theRole.catname));
                UpdateCommand.Parameters.Add(GetParameter("@Modby", SqlDbType.Int, Common.LoggedInUser[0].Usr_Id));
                ExecuteStoredProcedure(UpdateCommand);

                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }

        public DataTable GetCategoryList()

        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "CategoryselectAll" })
            {
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataRow GetCategoryById(int outid)
        {

            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "CategorySelectByID" })
            {
                SelectCommand.Parameters.Add(GetParameter("@catid", SqlDbType.Int, outid));
                return ExecuteGetDataRow(SelectCommand);
            }
        }
        public DataTable DeleteCategory(string outid)
        {
            using (SqlCommand DeleteCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "CategoryDelete" })
            {
                DeleteCommand.Parameters.Add(GetParameter("@PXMLTABLE", SqlDbType.VarChar, outid));
                // DeleteCommand.Parameters.Add(GetParameter("@RoleID", SqlDbType.Int, RoleID));
                return ExecuteGetDataTable(DeleteCommand);
            }
        }



        #endregion
    }
}
