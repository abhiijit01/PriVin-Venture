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
    public class CouponCodeDataAccess:SqlDataAccess
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static CouponCodeDataAccess instance = new CouponCodeDataAccess();
        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static CouponCodeDataAccess GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Methods & Implementation

        public int InsertCouponCode(CouponCode theRole)
        {
            int ReturnValue = 0;
            using (SqlCommand InsertCommand = new System.Data.SqlClient.SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "CouponCodeInsert" })
            {
                InsertCommand.Parameters.Add(GetParameter("@rtv", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@couponcode", SqlDbType.VarChar, theRole.couponcode));
                InsertCommand.Parameters.Add(GetParameter("@coupondesc", SqlDbType.VarChar, theRole.coupondesc));
                //InsertCommand.Parameters.Add(GetParameter("@offerprice", SqlDbType.Decimal, theRole.offerprice));
                InsertCommand.Parameters.Add(GetParameter("@validfrom", SqlDbType.Date, theRole.validfrom));
                InsertCommand.Parameters.Add(GetParameter("@validto", SqlDbType.Date, theRole.validto));
                InsertCommand.Parameters.Add(GetParameter("@outcode", SqlDbType.VarChar, Common.LoggedInUser[0].outcode));
                InsertCommand.Parameters.Add(GetParameter("@addby", SqlDbType.Int, Common.LoggedInUser[0].Usr_Id));

                ExecuteStoredProcedure(InsertCommand);

                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }
        public DataTable GetCouponCodeList(string action)

        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "CouponCodeSelectAll" })
            {
                SelectCommand.Parameters.Add(GetParameter("@outcode", SqlDbType.VarChar, Common.LoggedInUser[0].outcode));
                SelectCommand.Parameters.Add(GetParameter("@action", SqlDbType.VarChar, action));
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        #endregion
    }
}
