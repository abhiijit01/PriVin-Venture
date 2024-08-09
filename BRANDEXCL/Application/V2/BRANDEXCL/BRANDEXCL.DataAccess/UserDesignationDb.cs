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
    public partial class UserDesignationDb : SqlDataAccess
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static UserDesignationDb instance = new UserDesignationDb();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static UserDesignationDb GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Methods & Implementation
        //Get All Designation Lists
        public DataTable GetUserDesignationList()
        {
            
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "DesignationAll" })
            {                
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        //Update The Selected Designation
        public int UpdateUserDesignation(UserDesignation theDesgn)
        {
            int ReturnValue = 0;
            using (SqlCommand UpdateCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "DesignationUpdate" })
            {


                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@Desg_ID", SqlDbType.Int, theDesgn.Desg_ID));
                UpdateCommand.Parameters.Add(GetParameter("@Designation_Name", SqlDbType.VarChar, theDesgn.Designation_Name));
                UpdateCommand.Parameters.Add(GetParameter("@Desg_Code", SqlDbType.VarChar, theDesgn.Desg_Code));
                UpdateCommand.Parameters.Add(GetParameter("@Modby", SqlDbType.Int, Common.LoggedInUser[0].Usr_Id));

                ExecuteStoredProcedure(UpdateCommand);

                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }
        //Create New Designation
        public int CreateUserDesignation(UserDesignation theDesgn)
        {
            int ReturnValue = 0;
            using (SqlCommand InsertCommand = new System.Data.SqlClient.SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "DesignationCreate" })
            {
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@Designation_Name", SqlDbType.VarChar, theDesgn.Designation_Name));
                InsertCommand.Parameters.Add(GetParameter("@Desg_Code", SqlDbType.VarChar, theDesgn.Desg_Code));
                InsertCommand.Parameters.Add(GetParameter("@AddBy", SqlDbType.Int, Common.LoggedInUser[0].Usr_Id));

                ExecuteStoredProcedure(InsertCommand);

                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }
        //Delete The Selected Designation
        public DataTable DeleteDesignation(string Desg_ID)
        {
            using (SqlCommand DeleteCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "DesignationDelete" })
            {
                DeleteCommand.Parameters.Add(GetParameter("@PXMLTABLE", SqlDbType.VarChar, Desg_ID));               
                return ExecuteGetDataTable(DeleteCommand);
            }
        }

        public DataTable GetDesgById(int Desg_ID)
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "DesignationSelectById" })
            {
                SelectCommand.Parameters.Add(GetParameter("@Desg_ID", SqlDbType.Int, Desg_ID));
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        #endregion
    }
}