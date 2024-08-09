using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;
using System.Data;

namespace BLL
{
   public class DiscountManagement
    {
        int ReturnValue = 0;
        private static DiscountManagement instance = new DiscountManagement();
        public static DiscountManagement GetInstance
        {
            get
            {
                return instance;
            }
        }
        public int InsertDiscount(Discount theDiscount)
        {
            return DAL.DiscountDataAccess.GetInstance.InsertDiscount(theDiscount);
        }
        public int UpdateDiscount(Discount theDiscount)
        {
            return DAL.DiscountDataAccess.GetInstance.UpdateDiscount(theDiscount);
        }
        public DataTable DeleteDiscount(string data)
        {
            return DAL.DiscountDataAccess.GetInstance.DeleteDiscount(data);
        }
        public DataTable GetDiscountList()
        {
            return DAL.DiscountDataAccess.GetInstance.GetDiscountList();
        }
        public DataRow GetDiscountById(int disid)
        {
            return DAL.DiscountDataAccess.GetInstance.GetDiscountById(disid);
        }
    }
}
