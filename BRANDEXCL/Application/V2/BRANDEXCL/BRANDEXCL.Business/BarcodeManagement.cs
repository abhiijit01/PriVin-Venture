using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRANDEXCL.Model;
using System.Data;

namespace BRANDEXCL.Business
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
            return BRANDEXCL.DataAccess.BarcodeDataAccess.GetInstance.BarcodeSelectAll();
        }
        public DataTable BarcodeSelectByBarcode(string barcode,int? sizeid)
        {
            return BRANDEXCL.DataAccess.BarcodeDataAccess.GetInstance.BarcodeSelectByBarcode(barcode, sizeid);
        }
    }
}
