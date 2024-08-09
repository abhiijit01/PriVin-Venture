using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRANDEXCL.Model
{
    [Serializable]
    public class Permission
    {
        public int permid
        {
            get;
            set;
        }
        public int roleid
        {
            get;
            set;
        }

        public string roleDesc
        {
            get;
            set;
        }
        public int pageid
        {
            get;
            set;
        }
        public string distext
        {
            get;
            set;
        }
        public string targeturl
        {
            get;
            set;
        }
        public int parentid
        { get; set; }
        public bool canview
        {
            get;
            set;
        }
        public bool canadd
        {
            get;
            set;
        }
        public bool canedit
        {
            get;
            set;
        }
        public bool candelete
        {
            get;
            set;
        }
        public int AddBy { get; set; }
        public DateTime AddOn { get; set; }
        public int ModBy { get; set; }
        public DateTime ModOn { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsDelete { get; set; }
    }
}
