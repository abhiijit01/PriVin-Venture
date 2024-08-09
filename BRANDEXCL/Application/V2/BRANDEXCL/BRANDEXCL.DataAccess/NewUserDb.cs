using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRANDEXCL.Model;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace BRANDEXCL.DataAccess
{
    public partial class NewUserDb : SqlDataAccess
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static NewUserDb instance = new NewUserDb();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static NewUserDb GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion
        int ReturnValue = 0;
        #region Methods & Implementation
        //Create New User
        public int CreateUser(NewUser theUser)
        {

            int ReturnValue = 0;
            using (SqlCommand InsertCommand = new System.Data.SqlClient.SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "User_Create" })
            {
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@RoleID", SqlDbType.VarChar, theUser.RoleDesc));
                InsertCommand.Parameters.Add(GetParameter("@Desg_ID", SqlDbType.VarChar, theUser.Designation_Name));
                InsertCommand.Parameters.Add(GetParameter("@Name", SqlDbType.VarChar, theUser.Name));
                InsertCommand.Parameters.Add(GetParameter("@Email", SqlDbType.VarChar, theUser.Email));
                InsertCommand.Parameters.Add(GetParameter("@Phone", SqlDbType.VarChar, theUser.Phone));
                InsertCommand.Parameters.Add(GetParameter("@Usr_Nm", SqlDbType.VarChar, theUser.Usr_Nm));
                InsertCommand.Parameters.Add(GetParameter("@EmpCode", SqlDbType.VarChar, theUser.EmpCode));
                InsertCommand.Parameters.Add(GetParameter("@outid", SqlDbType.VarChar, theUser.outletname));
                InsertCommand.Parameters.Add(GetParameter("@countid", SqlDbType.VarChar, theUser.countername));
                InsertCommand.Parameters.Add(GetParameter("@AddBy", SqlDbType.Int, Common.LoggedInUser[0].Usr_Id));

                ExecuteStoredProcedure(InsertCommand);

                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }
        public int UpdateUser(NewUser theUser)
        {
            int ReturnValue = 0;
            using (SqlCommand UpdateCommand = new System.Data.SqlClient.SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "User_Update" })
            {
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@RoleID", SqlDbType.VarChar, theUser.RoleDesc));
                UpdateCommand.Parameters.Add(GetParameter("@Desg_ID", SqlDbType.VarChar, theUser.Designation_Name));
                UpdateCommand.Parameters.Add(GetParameter("@Name", SqlDbType.VarChar, theUser.Name));
                UpdateCommand.Parameters.Add(GetParameter("@Email", SqlDbType.VarChar, theUser.Email));
                UpdateCommand.Parameters.Add(GetParameter("@Phone", SqlDbType.VarChar, theUser.Phone));
                UpdateCommand.Parameters.Add(GetParameter("@Usr_Nm", SqlDbType.VarChar, theUser.Usr_Nm));
                UpdateCommand.Parameters.Add(GetParameter("@EmpCode", SqlDbType.VarChar, theUser.EmpCode));
                UpdateCommand.Parameters.Add(GetParameter("@Usr_Id", SqlDbType.Int, theUser.Usr_Id));
                UpdateCommand.Parameters.Add(GetParameter("@outid", SqlDbType.VarChar, theUser.outletname));
                UpdateCommand.Parameters.Add(GetParameter("@countid", SqlDbType.VarChar, theUser.countername));
                UpdateCommand.Parameters.Add(GetParameter("@Modby", SqlDbType.Int, Common.LoggedInUser[0].Usr_Id));
                ExecuteStoredProcedure(UpdateCommand);

                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }

        public DataTable GetUserList()
        {

            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "User_SelectAll" })
            {
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetUserById(int Usr_Id)
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "User_SelectById" })
            {
                SelectCommand.Parameters.Add(GetParameter("@Usr_Id", SqlDbType.Int, Usr_Id));
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public int ProfilepicUpdate(string image)
        {

            using (SqlCommand UpdateCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "ProfilepicUpdate" })
            {
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@Usr_Id", SqlDbType.Int, Common.LoggedInUser[0].Usr_Id));
                UpdateCommand.Parameters.Add(GetParameter("@modby", SqlDbType.Int, Common.LoggedInUser[0].Usr_Id));
                UpdateCommand.Parameters.Add(GetParameter("@image", SqlDbType.VarChar, image));

                ExecuteStoredProcedure(UpdateCommand);
                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }
        public DataTable getUserDetailsByLoggedInUser()
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "getUserDetailsByLoggedInUser" })
            {
                SelectCommand.Parameters.Add(GetParameter("@Usr_Id", SqlDbType.Int, Common.LoggedInUser[0].Usr_Id));
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable DeleteUser(string Usr_Id)
        {
            using (SqlCommand DeleteCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "User_Delete" })
            {
                DeleteCommand.Parameters.Add(GetParameter("@PXMLTABLE", SqlDbType.VarChar, Usr_Id));
                return ExecuteGetDataTable(DeleteCommand);
            }
        }
        public int ChangePwd(NewUser theUser)
        {
            int ReturnValue = 0;
            using (SqlCommand UpdateCommand = new System.Data.SqlClient.SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "User_Chng_Pwd" })
            {
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@Usr_Id", SqlDbType.Int, Common.LoggedInUser[0].Usr_Id));
                UpdateCommand.Parameters.Add(GetParameter("@Pwd", SqlDbType.VarChar, theUser.Pwd));
                UpdateCommand.Parameters.Add(GetParameter("@ConfmPwd", SqlDbType.VarChar, theUser.ConfmPwd));
                ExecuteStoredProcedure(UpdateCommand);

                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }
        public int ResetPwd(NewUser theUser)
        {
            int ReturnValue = 0;
            using (SqlCommand UpdateCommand = new System.Data.SqlClient.SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "User_Reset_Pwd" })
            {
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@Usr_Id", SqlDbType.Int, Common.LoggedInUser[0].Usr_Id));
                UpdateCommand.Parameters.Add(GetParameter("@Usr_Nm", SqlDbType.VarChar, theUser.Usr_Nm));
                UpdateCommand.Parameters.Add(GetParameter("@ConfmPwd", SqlDbType.VarChar, theUser.ConfmPwd));
                ExecuteStoredProcedure(UpdateCommand);

                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }

        public int CheckExist(NewUser theUser)
        {
            int ReturnValue = 0;
            using (SqlCommand SelectCommand = new System.Data.SqlClient.SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "User_Check_Exist" })
            {
                SelectCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                SelectCommand.Parameters.Add(GetParameter("@Usr_Nm", SqlDbType.VarChar, theUser.Usr_Nm));
                SelectCommand.Parameters.Add(GetParameter("@Email", SqlDbType.VarChar, theUser.Email));
                ExecuteStoredProcedure(SelectCommand);

                ReturnValue = int.Parse(SelectCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }
        public DataTable CheckUserExist(NewUser theUser)
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com"))
                {

                    using (SqlCommand SelectCommand = new System.Data.SqlClient.SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "User_SelectByLogInId" })
                    {

                        SelectCommand.Parameters.Add(GetParameter("@Usr_Nm", SqlDbType.VarChar, theUser.Usr_Nm));
                        SelectCommand.Parameters.Add(GetParameter("@pwd", SqlDbType.VarChar, theUser.Pwd));



                        return ExecuteGetDataTable(SelectCommand);
                    }
                }
            }
            catch (Exception ex)
            {
                using (SqlCommand SelectCommand = new System.Data.SqlClient.SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "User_SelectByLogInId" })
                {

                    SelectCommand.Parameters.Add(GetParameter("@Usr_Nm", SqlDbType.VarChar, theUser.Usr_Nm));
                    SelectCommand.Parameters.Add(GetParameter("@pwd", SqlDbType.VarChar, theUser.Pwd));



                    return ExecuteGetDataTable(SelectCommand);
                }
            }
        }
        public DataTable OutletSelectByUserId(int Usr_Id)
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "OutletSelectByUserId" })
            {
                SelectCommand.Parameters.Add(GetParameter("@Usr_Id", SqlDbType.Int, Usr_Id));
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable GetQueryData(string strQuery)
        {
            SqlCommand cmd = new SqlCommand(strQuery);
            DataTable dt = new DataTable();
            return ExecuteGetDataTable(cmd);
        }

        public DataTable GetAuthorityInfo(string strQuery)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(strQuery);
            return ExecuteGetDataTable(cmd);
        }
        #endregion

    }
}
