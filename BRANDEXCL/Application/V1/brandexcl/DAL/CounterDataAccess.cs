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
    public partial class CounterDataAccess:SqlDataAccess
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static CounterDataAccess instance = new CounterDataAccess();
        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static CounterDataAccess GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Methods & Implementation

        public int InsertCounter(Counter theCounter)
        {
            int ReturnValue = 0;
            using (SqlCommand InsertCommand = new System.Data.SqlClient.SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "CounterInsert" })
            {
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@countnm", SqlDbType.VarChar, theCounter.countnm));
                InsertCommand.Parameters.Add(GetParameter("@AddBy", SqlDbType.Int, Common.LoggedInUser[0].Usr_Id));

                ExecuteStoredProcedure(InsertCommand);

                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }



        public int UpdateCounter(Counter theCounter)
        {
            int ReturnValue = 0;
            using (SqlCommand UpdateCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "CounterUpdate" })
            {
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@countid", SqlDbType.Int, theCounter.countid));
                UpdateCommand.Parameters.Add(GetParameter("@countnm", SqlDbType.VarChar, theCounter.countnm));
                UpdateCommand.Parameters.Add(GetParameter("@Modby", SqlDbType.Int, Common.LoggedInUser[0].Usr_Id));
                ExecuteStoredProcedure(UpdateCommand);

                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }
        //public DataTable GetOfficeList()
        //{

        //    using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "OfficeSelect" })
        //    {
        //        return ExecuteGetDataTable(SelectCommand);
        //    }
        //}

        public DataTable GetCounterList()

        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "CounterSelectAll" })
            {
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        //public int DeleteUserRole(int RoleID)
        //{
        //    int ReturnValue = 0;
        //    using (SqlCommand DeleteCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "RolesDelete" })
        //    {
        //        DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
        //        DeleteCommand.Parameters.Add(GetParameter("@RoleID", SqlDbType.Int,RoleID));
        //        //DeleteCommand.Parameters.Add(GetParameter("@IsDelete", SqlDbType.VarChar, theRole.IsDelete));

        //        ExecuteStoredProcedure(DeleteCommand);

        //        ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());

        //        return ReturnValue;
        //    }
        //}
        public DataRow GetCounterById(int countid)
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "CounterSelectByID" })
            {
                SelectCommand.Parameters.Add(GetParameter("@countid", SqlDbType.Int, countid));
                return ExecuteGetDataRow(SelectCommand);
            }
        }
        public DataTable DeleteCounter(string countid)
        {
            using (SqlCommand DeleteCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "CounterDelete" })
            {
                DeleteCommand.Parameters.Add(GetParameter("@PXMLTABLE", SqlDbType.VarChar, countid));
                // DeleteCommand.Parameters.Add(GetParameter("@RoleID", SqlDbType.Int, RoleID));
                return ExecuteGetDataTable(DeleteCommand);
            }
        }



        #endregion
    }
}
