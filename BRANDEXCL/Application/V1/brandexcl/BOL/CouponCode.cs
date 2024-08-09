using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class CouponCode
    {
        public int couponid { get; set; }
        public string couponcode { get; set; } 
        public decimal uptobillprice { get; set; }
        public decimal offerinper { get; set; }
        public decimal offerprice { get; set; }
        public DateTime validfrom { get; set; }
        public DateTime validto { get; set; }
        public bool isredeemed { get; set; }
        public int totalcoupons { get; set; }
        public int redeemedcoupons { get; set; }
        public string coupondesc { get; set; }
    }
}
