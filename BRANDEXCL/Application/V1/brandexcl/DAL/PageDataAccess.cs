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
    public partial class PageDataAccess : SqlDataAccess
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static PageDataAccess instance = new PageDataAccess();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static PageDataAccess GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Methods & Implementation
        public int InsertPage(Page thePage)
        {
            int ReturnValue = 0;
            using (SqlCommand InsertCommand = new System.Data.SqlClient.SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "PageInsert" })
            {
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@distext", SqlDbType.VarChar, thePage.distext));
                InsertCommand.Parameters.Add(GetParameter("@tooltip", SqlDbType.VarChar, thePage.tooltip));
                InsertCommand.Parameters.Add(GetParameter("@targeturl", SqlDbType.VarChar, thePage.targeturl));
                InsertCommand.Parameters.Add(GetParameter("@parentid", SqlDbType.Int,Convert.ToInt32( thePage.parentid)));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Convert.ToInt32(Common.LoggedInUser[0].Usr_Id)));

                ExecuteStoredProcedure(InsertCommand);

                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }

        public int UpdatePage(Page thePage)
        {
            int ReturnValue = 0;
            using (SqlCommand UpdateCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "PageUpdate" })
            {
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@PageID", SqlDbType.Int, thePage.pageid));
                UpdateCommand.Parameters.Add(GetParameter("@distext", SqlDbType.VarChar, thePage.distext));
                UpdateCommand.Parameters.Add(GetParameter("@tooltip", SqlDbType.VarChar, thePage.tooltip));
                UpdateCommand.Parameters.Add(GetParameter("@targeturl", SqlDbType.VarChar, thePage.targeturl));
                UpdateCommand.Parameters.Add(GetParameter("@parentid", SqlDbType.Int, thePage.parentid));
                UpdateCommand.Parameters.Add(GetParameter("@ModBy", SqlDbType.Int, Common.LoggedInUser[0].Usr_Id));

                ExecuteStoredProcedure(UpdateCommand);

                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }


        public DataTable GetPageList()
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "PageSelectAll" })
            {
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetPageById(int pageid)
        {

            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "PageById" })
            {
                SelectCommand.Parameters.Add(GetParameter("@pageid", SqlDbType.Int, pageid));
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable DeletePage(string IDs)
        {
            using (SqlCommand DeleteCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "PageDelete" })
            {
                DeleteCommand.Parameters.Add(GetParameter("@PXMLTABLE", SqlDbType.VarChar, IDs));
                return ExecuteGetDataTable(DeleteCommand);
            }
        }
        #endregion
    }
}
