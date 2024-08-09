using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using BOL;
namespace DAL
{
    public partial  class CustmerDataAccess:SqlDataAccess
    {
        int ReturnValue = 0;
        private static CustmerDataAccess instance = new CustmerDataAccess();
        public static CustmerDataAccess GetInstance
        {
            get
            {
                return instance;
            }
        }
        public DataTable SelectCustmerByMobileNo(string mobileno)
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "SelectCustmerByMobileNo" })
            {
                SelectCommand.Parameters.Add(GetParameter("@mobileno", SqlDbType.VarChar, mobileno));
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public int SaveCustmerDetail(Custmer theCustmer)
        {
            using (SqlCommand InsertCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "CreateCustmer" })
            {
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@mobileno", SqlDbType.VarChar, theCustmer.mobileno));
                InsertCommand.Parameters.Add(GetParameter("@custname", SqlDbType.VarChar, theCustmer.custname));
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }
    }
}
