using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BRANDEXCL.Model;
namespace BRANDEXCL.Business
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
            return BRANDEXCL.DataAccess.CustmerDataAccess.GetInstance.SelectCustmerByMobileNo(custmmob);
        }
        public int SaveCustmerDetail(Custmer theCustomer)
        {
            return BRANDEXCL.DataAccess.CustmerDataAccess.GetInstance.SaveCustmerDetail(theCustomer);
        }
    }
}
