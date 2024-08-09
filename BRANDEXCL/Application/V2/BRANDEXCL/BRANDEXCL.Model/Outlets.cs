using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRANDEXCL.Model
{
   public class Outlets
    {
        public int outid { get; set; }
        public string outnm { get; set; }
        public string oid { get; set; }
        public string outcode { get; set; }
        public string officename { get; set; }
        public int sid { get; set; }
        public string statename { get; set; }
        public string distid { get; set; }
        public string distname { get; set; }
        public string outat { get; set; }
        public string outpin { get; set; }
        public string cpnm { get; set; }
        public string cpemail { get; set; }
        public string contct { get; set; }
        public DateTime addon { get; set; }
        public int addby { get; set; }
        public DateTime modon { get; set; }
        public int modby { get; set; }
        public bool isactive { get; set; }
        public bool isdelete { get; set; }
    }
}
