using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRANDEXCL.Model
{
    public class Custmer
    {//custid, custcode, custname, dateofbirth, gender, bloodgroup, religion, nationality, address, pincode, mobileno, emailid, addon, addby, modon, modby, isactive, isdelete
        public int custid { get; set; }
        public string custcode { get; set; }
        public string custname { get; set; }
        public string exchinvoice { get; set; }

        public string custmmob { get; set; }
        public string mobileno { get; set; }
        public DateTime addon { get; set; }
        public int addby { get; set; }
        public DateTime modon { get; set; }
        public int modby { get; set; }
        public bool isactive { get; set; }
        public bool isdelete { get; set; }
    }
}
