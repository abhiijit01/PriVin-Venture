﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRANDEXCL.Model
{
    public class Counter
    {
        public int countid { get; set; }
        public string countnm { get; set; }
        public string countcode { get; set; }
        public DateTime addon { get; set; }
        public int addby { get; set; }
        public DateTime modon { get; set; }
        public int modby { get; set; }
        public bool isactive { get; set; }
        public bool isdelete { get; set; }
    }
}