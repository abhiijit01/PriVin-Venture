using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;
using BRANDEXCL.Model;

namespace BRANDEXCL.DataAccess
{
    public partial class  SizeDataAccess : SqlDataAccess
    {
        #region This code is for making it singleton application
        /// <summary>
        /// private static member to implement singleton design pattern
        /// </summary>
        private static SizeDataAccess instance = new SizeDataAccess();
        ///<summary>
        ///static property of the class which will provide the sinleton instance of it
        ///</summary>
        public static SizeDataAccess GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion
        #region Methods nad implementation
        public int InsertSize(Size TheSize)
        {
            int ReturnValue = 0;
            using (SqlCommand InsertCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "SizeInsert" })
            {
                InsertCommand.Parameters.Add(GetParameter("@Returnvalue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@descr", SqlDbType.VarChar, TheSize.descr));
                InsertCommand.Parameters.Add(GetParameter("@addby", SqlDbType.Int, Common.LoggedInUser[0].Usr_Id));
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                return ReturnValue;

            }
        }
        public int UpdateSize(Size TheSize)
        {
            int ReturnValue = 0;
            using (SqlCommand UpdateCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "SizeUpdate" })
            {
                UpdateCommand.Parameters.Add(GetParameter("@Returnvalue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@sizeid", SqlDbType.Int, TheSize.sizeid));
                UpdateCommand.Parameters.Add(GetParameter("@descr", SqlDbType.VarChar, TheSize.descr));
                UpdateCommand.Parameters.Add(GetParameter("@modby", SqlDbType.Int, Common.LoggedInUser[0].Usr_Id));
                ExecuteStoredProcedure(UpdateCommand);
                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
                return ReturnValue;

            }
        }
        public DataTable GetSizeList()
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "SizeSelectAll" })
            {
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataRow GetSizeById(int sizeid)
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "SizeSelectById" })
            {
                SelectCommand.Parameters.Add(GetParameter("@sizeid", SqlDbType.Int, sizeid));
                return ExecuteGetDataRow(SelectCommand);
            }
        }
        public DataTable DeleteSize(string sizeid)
        {
            using (SqlCommand DeleteCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "SizeDelete" })
            {
                DeleteCommand.Parameters.Add(GetParameter("@PXMLTABLE", SqlDbType.VarChar, sizeid));
                return ExecuteGetDataTable(DeleteCommand);
            }
        }
        #endregion

    }
}
