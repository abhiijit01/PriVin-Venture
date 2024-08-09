using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRANDEXCL.Model;
using BRANDEXCL.DataAccess;
using System.Data;

namespace BRANDEXCL.Business
{
    public class SaleManagement
    {
        private static SaleManagement instance = new SaleManagement();
        public static SaleManagement GetInstance
        {
            get
            {
                return instance;
            }
        }
        public string InsertSalesDetails(string data, string mobile, string email, string name)
        {
            return BRANDEXCL.DataAccess.SaleDataAccess.GetInstance.InsertSalesDetails(data, mobile, email, name);
        }
        public DataTable latestbiinoselectproduct(string billno)
        {
            return BRANDEXCL.DataAccess.SaleDataAccess.GetInstance.latestbiinoselectproduct(billno);
        }
        public DataTable SelectRateSale()
        {
            return BRANDEXCL.DataAccess.SaleDataAccess.GetInstance.SelectRateSale();
        }
        public DataTable SaleReportSelectByDate(DateTime fromdate, DateTime todate)
        {
            return BRANDEXCL.DataAccess.SaleDataAccess.GetInstance.SaleReportSelectByDate(fromdate, todate);
        }
        public DataTable ProfitAndLossSelectByDate(DateTime fromdate, DateTime todate)
        {
            return BRANDEXCL.DataAccess.SaleDataAccess.GetInstance.ProfitAndLossSelectByDate(fromdate, todate);
        }
        public DataTable GetCustomerDetailsByMobNo(string mobileno)
        {
            return BRANDEXCL.DataAccess.SaleDataAccess.GetInstance.GetCustomerDetailsByMobNo(mobileno);
        }
        public DataTable GetAllSoldProducts()
        {
            return BRANDEXCL.DataAccess.SaleDataAccess.GetInstance.GetAllSoldProducts();
        }
        public DataTable GetProfitAndLossDetails() 
        {
            return BRANDEXCL.DataAccess.SaleDataAccess.GetInstance.GetProfitAndLossDetails();
        }
        
    }
}
