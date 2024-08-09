using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class SaleReport
    {
        public int saleid { get; set; }
        public DateTime invoicedate { get; set; }
        public string invoiceno { get; set; }
        public string barcode { get; set; }
        public string prodname { get; set; }
        public string descr { get; set; }
        public string catname { get; set; }
        public string brandname { get; set; }
        public string sizename { get; set; }
        public int qty { get; set; }
        public decimal priceexgst { get; set; }
        public decimal gst { get; set; }
        public decimal unitprice { get; set; }
        public decimal discount { get; set; }
        public decimal finalprice { get; set; }
        public string paymentmode { get; set; }
    }
}
