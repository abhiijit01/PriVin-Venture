using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BOL;
namespace BLL
{
   public class CustmerManagement
    {
        private static CustmerManagement instance = new CustmerManagement();
       public static CustmerManagement GetInstance
        {
            get
            {
                return instance;
            }
        }
        public DataTable SelectCustmerByMobileNo(string custmmob)
        {
            return DAL.CustmerDataAccess.GetInstance.SelectCustmerByMobileNo(custmmob);
        }
        public int SaveCustmerDetail(Custmer theCustomer)
        {
            return DAL.CustmerDataAccess.GetInstance.SaveCustmerDetail(theCustomer);
        }
    }
}
