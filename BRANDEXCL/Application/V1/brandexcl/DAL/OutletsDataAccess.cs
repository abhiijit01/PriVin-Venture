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
   public partial class OutletsDataAccess : SqlDataAccess
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static OutletsDataAccess instance = new OutletsDataAccess();
        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static OutletsDataAccess GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Methods & Implementation

        public int InsertOutlet(Outlets theRole)
        {
            int ReturnValue = 0;
            using (SqlCommand InsertCommand = new System.Data.SqlClient.SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "OutletInsert" })
            {
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@oid", SqlDbType.VarChar, theRole.officename));
                InsertCommand.Parameters.Add(GetParameter("@outnm", SqlDbType.VarChar, theRole.outnm));
                InsertCommand.Parameters.Add(GetParameter("@sid", SqlDbType.Int, theRole.statename));
                InsertCommand.Parameters.Add(GetParameter("@distid", SqlDbType.VarChar, theRole.distname));
                InsertCommand.Parameters.Add(GetParameter("@outat", SqlDbType.VarChar, theRole.outat));
                InsertCommand.Parameters.Add(GetParameter("@outpin", SqlDbType.VarChar, theRole.outpin));
                InsertCommand.Parameters.Add(GetParameter("@cpnm", SqlDbType.VarChar, theRole.cpnm));
                InsertCommand.Parameters.Add(GetParameter("@cpemail", SqlDbType.VarChar, theRole.cpemail));
                InsertCommand.Parameters.Add(GetParameter("@contct", SqlDbType.VarChar, theRole.contct));
                InsertCommand.Parameters.Add(GetParameter("@AddBy", SqlDbType.Int, Common.LoggedInUser[0].Usr_Id));

                ExecuteStoredProcedure(InsertCommand);

                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }



        public int UpdateOutlet(Outlets theRole)
        {
            int ReturnValue = 0;
            using (SqlCommand UpdateCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "OutletUpdate" })
            {
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@oid", SqlDbType.VarChar, theRole.officename));
                UpdateCommand.Parameters.Add(GetParameter("@outid", SqlDbType.Int, theRole.outid));
                UpdateCommand.Parameters.Add(GetParameter("@outnm", SqlDbType.VarChar, theRole.outnm));
                UpdateCommand.Parameters.Add(GetParameter("@sid", SqlDbType.Int, theRole.statename));
                UpdateCommand.Parameters.Add(GetParameter("@distid", SqlDbType.VarChar, theRole.distname));
                UpdateCommand.Parameters.Add(GetParameter("@outat", SqlDbType.VarChar, theRole.outat));
                UpdateCommand.Parameters.Add(GetParameter("@outpin", SqlDbType.VarChar, theRole.outpin));
                UpdateCommand.Parameters.Add(GetParameter("@cpnm", SqlDbType.VarChar, theRole.cpnm));
                UpdateCommand.Parameters.Add(GetParameter("@cpemail", SqlDbType.VarChar, theRole.cpemail));
                UpdateCommand.Parameters.Add(GetParameter("@contct", SqlDbType.VarChar, theRole.contct));
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

        public DataTable GetOutletList()

        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "OutletSelectAll" })
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
        public DataRow GetOutletById(int outid)
        {

            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "OutletSelectByID" })
            {
                SelectCommand.Parameters.Add(GetParameter("@outid", SqlDbType.Int, outid));
                return ExecuteGetDataRow(SelectCommand);
            }
        }
        public DataTable DeleteOutlet(string outid)
        {
            using (SqlCommand DeleteCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "OutletDelete" })
            {
                DeleteCommand.Parameters.Add(GetParameter("@PXMLTABLE", SqlDbType.VarChar, outid));
                // DeleteCommand.Parameters.Add(GetParameter("@RoleID", SqlDbType.Int, RoleID));
                return ExecuteGetDataTable(DeleteCommand);
            }
        }



        #endregion
    }
}
