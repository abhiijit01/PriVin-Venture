using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRANDEXCL.Model;
using System.Data;
using System.Data.SqlClient;

namespace BRANDEXCL.DataAccess
{
    public partial class UserRoleDataAccess : SqlDataAccess
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static UserRoleDataAccess instance = new UserRoleDataAccess();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static UserRoleDataAccess GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Methods & Implementation       
        public DataTable GetUserRoleList()
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "RolesSelectAll" })
            {
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataRow GetUserRoleById(int RoleID)
        {

            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "RolesSelectByID" })
            {
                SelectCommand.Parameters.Add(GetParameter("@RoleID", SqlDbType.Int, RoleID));
                SelectCommand.Parameters.Add(GetParameter("@RoleDesc", SqlDbType.Int, RoleID));
                return ExecuteGetDataRow(SelectCommand);
            }
        }
        public int InsertUserRole(UserRole theRole)
        {
            int ReturnValue = 0;
            using (SqlCommand InsertCommand = new System.Data.SqlClient.SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "RolesInsert" })
            {
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@RoleDesc", SqlDbType.VarChar, theRole.RoleDesc));
                InsertCommand.Parameters.Add(GetParameter("@AddBy", SqlDbType.Int, Common.LoggedInUser[0].Usr_Id));


                ExecuteStoredProcedure(InsertCommand);

                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }

        public int UpdateUserRole(UserRole theRole)
        {
            int ReturnValue = 0;
            using (SqlCommand UpdateCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "RolesUpdate" })
            {


                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@RoleDesc", SqlDbType.VarChar, theRole.RoleDesc));
                UpdateCommand.Parameters.Add(GetParameter("@RoleID", SqlDbType.Int, theRole.RoleID));
                UpdateCommand.Parameters.Add(GetParameter("@Modby", SqlDbType.Int, Common.LoggedInUser[0].Usr_Id));
                ExecuteStoredProcedure(UpdateCommand);

                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }



        public DataTable DeleSelectedUser(string RoleID)
        {
            using (SqlCommand DeleteCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "RolesDelete" })
            {
                DeleteCommand.Parameters.Add(GetParameter("@PXMLTABLE", SqlDbType.VarChar, RoleID));
                // DeleteCommand.Parameters.Add(GetParameter("@RoleID", SqlDbType.Int, RoleID));
                return ExecuteGetDataTable(DeleteCommand);
            }
        }
        #endregion
    }
}
