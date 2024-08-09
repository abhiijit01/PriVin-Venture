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
    public class PermissionDataAccess : SqlDataAccess
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static PermissionDataAccess instance = new PermissionDataAccess();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static PermissionDataAccess GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Methods & Implementation
        public DataTable GetPagePermissionList()
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "PagePermissionsSelectAll" })
            {
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetPagePermissionListByRoleID(int roleID)
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "PagePermissionsSelectByRoleID" })
            {
                SelectCommand.Parameters.Add(GetParameter("@RoleID", SqlDbType.Int, roleID));

                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable GetPagesListByRoleID(int roleID)
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "PagesSelectByRoleID" })
            {
                SelectCommand.Parameters.Add(GetParameter("@RoleID", SqlDbType.Int, roleID));

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public int InsertPagePermission(string strPermission)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "PagePermissionsInsert" })
            {
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@strPermission", SqlDbType.VarChar, strPermission));
                InsertCommand.Parameters.Add(GetParameter("@Addedby", SqlDbType.Int, Common.LoggedInUser[0].Usr_Id));

                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
            }

            return ReturnValue;
        }
        #endregion

    }
}
