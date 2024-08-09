using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    [Serializable]
    public class UserDesignation
    {
        [Required]
        public int Desg_ID { get; set; }
        [Required]
        public string Designation_Name { get; set; }
        public string Desg_Code { get; set; }
        public int AddBy { get; set; }

        public int ModBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

}
