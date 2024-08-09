using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Category
    {
        public int catid { get; set; }
        public string catname { get; set; }
        public DateTime addon { get; set; }
        public int addby { get; set; }
        public DateTime modon { get; set; }
        public int modby { get; set; }
        public bool isactive { get; set; }
        public bool isdelete { get; set; }
    }
}
