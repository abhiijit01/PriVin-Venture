using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    [Serializable]
    public class UserRole
    {
        [Required]
        public int RoleID { get; set; }
        [Required]
        public string RoleDesc { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int AddBy { get; set; }
        public DateTime AddOn { get; set; }
        public int ModBy { get; set; }
        public DateTime ModOn { get; set; }

    }
}
