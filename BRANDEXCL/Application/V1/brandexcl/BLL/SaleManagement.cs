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
        public string InsertSalesDetails(string data, string mobile, string email, string name,int couponid)
        {
            return DAL.SaleDataAccess.GetInstance.InsertSalesDetails(data, mobile, email, name, couponid);
        }
        public DataTable latestbiinoselectproduct(string billno,string mobileno)
        {
            return DAL.SaleDataAccess.GetInstance.latestbiinoselectproduct(billno, mobileno);
        }
        public DataTable latestexchbiinoselectproduct(string billno, string mobileno)
        {
            return DAL.SaleDataAccess.GetInstance.latestexchbiinoselectproduct(billno, mobileno);
        }
        public DataTable GetInvoicesByMobileOrInvoice(string billno, string mobileno)
        {
            return DAL.SaleDataAccess.GetInstance.GetInvoicesByMobileOrInvoice(billno, mobileno);
        }
        public DataTable SelectRateSale()
        {
            return DAL.SaleDataAccess.GetInstance.SelectRateSale();
        }
        public DataTable SaleReportSelectByDate(DateTime fromdate, DateTime todate)
        {
            return DAL.SaleDataAccess.GetInstance.SaleReportSelectByDate(fromdate, todate);
        }
        public DataTable ProfitAndLossSelectByDate(DateTime fromdate, DateTime todate)
        {
            return DAL.SaleDataAccess.GetInstance.ProfitAndLossSelectByDate(fromdate, todate);
        }
        public DataTable GetCustomerDetailsByMobNo(string mobileno)
        {
            return DAL.SaleDataAccess.GetInstance.GetCustomerDetailsByMobNo(mobileno);
        }
        public DataTable GetAllSoldProducts()
        {
            return DAL.SaleDataAccess.GetInstance.GetAllSoldProducts();
        }
        public DataTable GetProfitAndLossDetails() 
        {
            return DAL.SaleDataAccess.GetInstance.GetProfitAndLossDetails();
        }
        public DataTable GetAllSaleByInvoiceno(string invoice)
        {
            return DAL.SaleDataAccess.GetInstance.GetAllSaleByInvoiceno(invoice);
        }
        public DataTable GetOfferDetailsByCouponCode(string couponcode)
        {
            return DAL.SaleDataAccess.GetInstance.GetOfferDetailsByCouponCode(couponcode);
        }
        public string InsertExchangeData(string data)
        {
            return DAL.SaleDataAccess.GetInstance.InsertExchangeData(data);
        }
    }
}
