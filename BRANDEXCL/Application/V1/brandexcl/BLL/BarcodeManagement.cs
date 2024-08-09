using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using System.Data;

namespace BLL
{
   public class BarcodeManagement
    {
        private static BarcodeManagement instance = new BarcodeManagement();
        public static BarcodeManagement GetInstance
        {
            get
            {
                return instance;
            }
        }

        public DataTable BarcodeSelectAll()
        {
            return DAL.BarcodeDataAccess.GetInstance.BarcodeSelectAll();
        }
        public DataTable BarcodeSelectByBarcode(string barcode,int? sizeid)
        {
            return DAL.BarcodeDataAccess.GetInstance.BarcodeSelectByBarcode(barcode, sizeid);
        }
    }
}
