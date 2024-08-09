using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace BRANDEXCL.Areas.Outlet.Controllers
{
    public class UserRoleController : Controller
    {

        // GET: Admin/UserRole
        public ActionResult Index()
        {
            return View();
        }
      

        public ActionResult CreateUserRole()
        {

            return View();
        }
        [HttpPost]
        public JsonResult CreateUserRole(UserRole theRole)

        {
            try
            {

               
                int returnvf =BLL.UserRoleBusiness.GetInstance.InsertContractor(theRole);
                if (returnvf > 1) { return Json("Records added Successfully."); }
                else if (returnvf == -1)
                {
                    return Json("Records Already Exists.");
                }
                else if (returnvf == -2)
                {
                    return Json("Failed to add Record.");
                }
                else { return Json(""); }

            }
            catch
            {
                return Json("Records not added,");
            }
        }

        
        public ActionResult UpdateUser()
        {          
            return View();          
        }
        [HttpPost]
        public JsonResult UpdateUser(UserRole theRole)
        {
            try
            { 
            int returnvf = BLL.UserRoleBusiness.GetInstance.UpdateUserRole(theRole);
            if (returnvf > 1) { return Json("Records Updated Successfully."); }
            else if (returnvf == -1)
            {
                return Json("Records Already Exists.");
            }
            else if (returnvf == -2)
            {
                return Json("Failed to add Record.");
            }
            else { return Json(""); }

             }
            catch { return Json("Upadte Failed"); }
        }

        //[HttpPost]
        //public ActionResult DeleteUser(int RoleID)
        //{
        //    try
        //    {
        //        int id = RoleID;
        //        int returndata = BLL.UserRoleBusiness.GetInstance.DeleteUserRole(RoleID);
        //        if (returndata > 1) { 
        //        return Json("Records deleted successfully.", JsonRequestBehavior.AllowGet);
        //        }
        //        else { return Json(""); }
        //    }

        //    catch { return Json("Failed To Delete"); }
        //}
        public ActionResult ViewUserRole()
        {
            return View();
        }
        [HttpGet]
        public JsonResult ViewUserRole1()
        {

            DataTable dt = UserRoleBusiness.GetInstance.GetUserRoleList();
            try
            {
                UserRole EmpRepo = new UserRole();

               
                List<UserRole> userrolelist = new List<UserRole>();
                userrolelist = (from DataRow dr in dt.Rows
                                select new UserRole()
                                {
                                    RoleID = Convert.ToInt32(dr["RoleID"]),
                                    RoleDesc = dr["RoleDesc"].ToString()

                                }).ToList();
                return Json(userrolelist, JsonRequestBehavior.AllowGet);
                //    return Json(userrolelist, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("Could not find any user");
            }
        }
        public ActionResult DeleteSelectedUser(string[] RoleID1)
        {
            DataTable datta = new DataTable();
            datta.Columns.Add("RoleID");
            foreach(string s in RoleID1)
            {
                datta.Rows.Add(s);
            }
           
            string RoleID = Common.GetSTRXMLResult(datta);
            try
            {
                DataTable dt = UserRoleBusiness.GetInstance.DeleSelectedUser(RoleID);            
                return Json("Updated Successfully");
            }
            catch
            {
                return Json("Could not find any user");
            }
        }
        [HttpPost]
        public JsonResult ViewRoleDDL()
        {
            DataTable dt = UserRoleBusiness.GetInstance.GetUserRoleList();

            List<UserRole> rolelist = new List<UserRole>();
            rolelist = (from DataRow dr in dt.Rows
                        select new UserRole()
                        {
                            RoleID = Convert.ToInt32(dr["RoleID"]),
                            RoleDesc = dr["RoleDesc"].ToString()
                        }).ToList();
            return Json(rolelist, JsonRequestBehavior.AllowGet);

        }
    }
}