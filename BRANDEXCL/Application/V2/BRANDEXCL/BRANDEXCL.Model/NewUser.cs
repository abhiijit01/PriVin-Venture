using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRANDEXCL.Model
{
    public class NewUser
    {
        public string outcode { get; set; }
        public string image { get; set; }
        public int Usr_Id { get; set; }
        public int RoleID { get; set; }
        public string RoleDesc { get; set; }
        public int Dept_ID { get; set; }
        public string Dept_Name { get; set; }
        public string Designation_Name { get; set; }
        public int Desg_ID { get; set; }
        public int Unit_Id { get; set; }
        public string Unit_Name { get; set; }
        public string Unit_Code { get; set; }
        
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Usr_Nm { get; set; }
        public string Pwd { get; set; }        
        public string ConfmPwd { get; set; }
        public DateTime AddOn { get; set; }
        public int AddBy { get; set; }
        public DateTime ModOn { get; set; }
        public int ModBy { get; set; }
        public string EmpCode { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public bool Active { get; set; }
        public int outid { get; set; }
        public string outletname { get; set; }
        public int countid { get; set; }
        public string countername { get; set; }

    }   
}
