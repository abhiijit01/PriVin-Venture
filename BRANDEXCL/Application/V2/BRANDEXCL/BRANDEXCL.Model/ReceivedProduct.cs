using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRANDEXCL.Model
{
    public class ReceivedProduct
    {
        /*purchid, outid, outcode, countcode, invoiceno, purcdate, barcode, prodcode, prodname, catid, 
         * brandid, colourid, sizeid, qty, unitprice, totalprice, gst, descr, refundstatus, 
         * addon, addby, modon, modby, isactive, isdelete*/
        public int purchid { get; set; }
        public int outid { get; set; }
        public string outcode { get; set; }
        public string countcode { get; set; }
        public string invoiceno { get; set; }
        public DateTime purcdate { get; set; }
        public string barcode { get; set; }
        public string prodcode { get; set; }
        public string prodname { get; set; }
        public int catid { get; set; }
        public string catname { get; set; }
        public int brandid { get; set; }
        public string brandname { get; set; }
        public int colourid { get; set; }
        public string colourname { get; set; }
        public int sizeid { get; set; }
        public string sizename { get; set; }
        public int qty { get; set; }
        public int qtysold { get; set; }
        public int qtyavailable { get; set; }
        public decimal unitprice { get; set; }
        public decimal priceexgst { get; set; }
        public decimal purchprice { get; set; }
        public decimal gst { get; set; }
        public string proddescr { get; set; }
        public bool refundstatus { get; set; }

        public DateTime addon { get; set; }
        public int addby { get; set; }
        public DateTime modon { get; set; }
        public int modby { get; set; }
        public bool isactive { get; set; }
        public bool isdelete { get; set; }

        public decimal discountper { get; set; }
        public decimal discountamount { get; set; }
        public decimal gstprice { get; set; }
        public decimal finalprice { get; set; }
        public string paymentmode { get; set; }
        public DateTime saledate { get; set; }
        public decimal saleprice { get; set; }
        public decimal profitprice { get; set; }
        public decimal lossprice { get; set; }
    } 
}
