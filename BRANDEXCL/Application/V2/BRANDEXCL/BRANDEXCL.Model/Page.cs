using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRANDEXCL.Model
{
    [Serializable]
    public class Page
    {
        public int pageid { get; set; }
        public string distext { get; set; }
        public string tooltip { get; set; }
        public string targeturl { get; set; }
        public int parentid { get; set; }
        public int orderby { get; set; }
        public int addby { get; set; }
        public DateTime addon { get; set; }
        public int modby { get; set; }
        public DateTime modon { get; set; }
        public bool isactive { get; set; }
        public bool isdelete { get; set; }

    }
}
