using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRANDEXCL.Model;
using System.Data;

namespace BRANDEXCL.Business
{
    public class ReceivedProductManagement
    {
        #region This code is for making it singleton application
        ///<summary>
        ///private static member to implement singleton design pattern
        ///</summary>
        private static ReceivedProductManagement instance = new ReceivedProductManagement();
        ///<summary>
        ///Static Property of the class which will provide the singleton instance of it 
        ///</summary>
        public static ReceivedProductManagement GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion
        #region Methods And Implementation
        public int InsertReceivedProduct(string data)
        {
            return BRANDEXCL.DataAccess.ReceivedProductDataAccess.GetInstance.InsertReceivedProduct(data);
        }
        public int UpdateReceivedProduct(ReceivedProduct theReceivedProduct)
        {
            return BRANDEXCL.DataAccess.ReceivedProductDataAccess.GetInstance.UpdateReceivedProduct(theReceivedProduct);
        }
        public int UpdateReceivedProductqty(string barcode,int sizeid, int qty)
        {
            return BRANDEXCL.DataAccess.ReceivedProductDataAccess.GetInstance.UpdateReceivedProductqty(barcode, sizeid,qty);
        }
        public DataTable GetAllInvoiceDetails()
        {
            return BRANDEXCL.DataAccess.ReceivedProductDataAccess.GetInstance.GetAllInvoiceDetails();
        }
        public DataTable DeleteReceivedProduct(string purchid)
        {
            return BRANDEXCL.DataAccess.ReceivedProductDataAccess.GetInstance.DeleteReceivedProduct(purchid);
        }
        public DataTable GetAllReceivedProductByInvoiceno(string invoiceno)
        {
            return BRANDEXCL.DataAccess.ReceivedProductDataAccess.GetInstance.GetAllReceivedProdByInvoiceno(invoiceno);
        }
        public DataTable ReceiveReportSelectByDate(DateTime fromdate, DateTime todate)
        {
            return BRANDEXCL.DataAccess.ReceivedProductDataAccess.GetInstance.ReceiveReportSelectByDate(fromdate, todate);
        }
        public DataTable GetAllReceivedProducts()
        {
            return BRANDEXCL.DataAccess.ReceivedProductDataAccess.GetInstance.GetAllReceivedProducts();
        }
        #endregion
    }
}
