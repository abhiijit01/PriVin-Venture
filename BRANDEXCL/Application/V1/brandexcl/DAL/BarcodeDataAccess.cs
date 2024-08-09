
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using BOL;

namespace DAL
{
   public partial class BarcodeDataAccess:SqlDataAccess
    {
        private static BarcodeDataAccess instance = new BarcodeDataAccess();
         public static BarcodeDataAccess GetInstance
        {
            get
            {
                return instance;
            }
        }
        public DataTable BarcodeSelectAll()
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "BarcodeSelectAll" })
            {
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable BarcodeSelectByBarcode(string barcode, int? sizeid)
        {
            using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "SelectRecievedProductByBarcode" })
            {
                SelectCommand.Parameters.Add(GetParameter("@barcode", SqlDbType.VarChar, barcode.Trim()));
                SelectCommand.Parameters.Add(GetParameter("@sizeid", SqlDbType.Int, sizeid));
                SelectCommand.Parameters.Add(GetParameter("@outcode", SqlDbType.VarChar, Common.LoggedInUser[0].outcode));
                return ExecuteGetDataTable(SelectCommand);
            }
        }
    }
}
