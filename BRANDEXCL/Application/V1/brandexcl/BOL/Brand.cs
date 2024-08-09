using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Brand
    {
        public int brandid { get; set; }
        public string brandname { get; set; }
        public DateTime addon { get; set; }
        public int addby { get; set; }
        public DateTime modon { get; set; }
        public int modby { get; set; }
        public bool isactive { get; set; }
        public bool isdelete { get; set; }
    }
}
