using System;


namespace BRANDEXCL.Model
{
   public class Sale
    {
        
        public int saleid { get; set; }
        
        public int purchid { get; set; }
        
        public string barcode { get; set; }
        
        public decimal priceexcludgst { get; set; }
        
        public decimal gst { get; set; }
        
        public decimal gstprice { get; set; }
        
        public decimal unitprice { get; set; }
        
        public decimal quanity { get; set; }
        
        public decimal discountper { get; set; }
        
        public decimal discountamount { get; set; }
        
        public string paymentmode { get; set; }
        
        public decimal finalprice { get; set; }
        public string billno { get; set; }

        public bool isactive { get; set; }
        
        public bool isdelete { get; set; }
        
        public string addon { get; set; }
        
        public int addby { get; set; }
        
        public string modon { get; set; }
        
        public int modby { get; set; }
        //====================
        public string prodname { get; set; }
        public string sizename { get; set; }
        public string emailid { get; set; }
        public string custname { get; set; } 
    }
}
