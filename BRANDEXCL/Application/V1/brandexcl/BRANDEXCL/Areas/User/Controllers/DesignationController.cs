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

namespace BRANDEXCL.Areas.User.Controllers
{
    public class DesignationController : Controller
    {
        #region Decalration
        int ReturnValue = 0;
        #endregion
        // GET: User/Designation
        public ActionResult IndexDesignation()
        {
            return View();
        }
        //View All Designations
        public ActionResult ViewDesignation()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ViewDesignation1(string sidx, string sord, int page, int rows,
            bool _search, string searchField, string searchOper, string searchString
            )
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            sord = (sord == null) ? "" : sord;

            DataTable dt = UserDesignationBS.GetInstance.GetUserDesignationList();
            try
            {

                UserDesignation EmpRepo = new UserDesignation();
                List<UserDesignation> userdesglist = new List<UserDesignation>();
                userdesglist = (from DataRow dr in dt.Rows
                                select new UserDesignation()
                                {
                                    Desg_ID = Convert.ToInt32(dr["Desg_ID"]),
                                    Designation_Name = dr["Designation_Name"].ToString(),
                                    Desg_Code=dr["Desg_Code"].ToString()

                                }).ToList();
                int totalRecords = userdesglist.Count();
                var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
                var jsonData = new
                {
                    total = totalPages,
                    page,
                    records = totalRecords,
                    rows = userdesglist
                };
                return Json(jsonData, JsonRequestBehavior.AllowGet);               
            }
            catch
            {
                return Json("Could not find any Designation");
            }
        }
        //Create New Designation
        public ActionResult CreateDesignation()
        {
            return View();
        }
        [HttpPost]
        public JsonResult CreateDesignation(UserDesignation theDesgn)
        {
            try
            {
                if(theDesgn.Desg_ID >= 1)
                {
                    ReturnValue = BLL.UserDesignationBS.GetInstance.UpdateUserDesignation(theDesgn);
                }
              else
                {
                    ReturnValue = BLL.UserDesignationBS.GetInstance.CreateUserDesignation(theDesgn);
                }
                if (ReturnValue > 1) { return Json("Records Updated Successfully."); }
                else if (ReturnValue == -1)
                {
                    return Json("Records Already Exists.");
                }
                else if (ReturnValue == -2)
                {
                    return Json("Failed to add Record.");
                }
                else { return Json(""); }

            }
            catch { return Json("Upadte Failed"); }

        }
       
     
        //Delete The Desination
        [HttpPost]
        public JsonResult DeleteDesignation(string id)
        {
            int[] nums = Array.ConvertAll(id.Split(','), int.Parse);
            DataTable datta = new DataTable();
            datta.Columns.Add("Desg_ID");
            foreach(int s in nums)
            {
                datta.Rows.Add(s);
            }

            string Desg_ID = Common.GetSTRXMLResult(datta);
            try
            {
                DataTable dt = UserDesignationBS.GetInstance.DeleteDesignation(Desg_ID);
                return Json("Deleted Successfully");
            }
            catch
            {
                return Json("Could not find any Designation");
            }
        }
        [HttpPost]
        public JsonResult ViewDesgDDL()
        {
            DataTable dt = UserDesignationBS.GetInstance.GetUserDesignationList();

            List<UserDesignation> desglist = new List<UserDesignation>();
            desglist = (from DataRow dr in dt.Rows
                        select new UserDesignation()
                        {
                            Desg_ID = Convert.ToInt32(dr["Desg_ID"]),
                            Designation_Name = dr["Designation_Name"].ToString()
                        }).ToList();
            return Json(desglist, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult PopulateFormField(int Desg_ID)
        {
            DataTable dt = UserDesignationBS.GetInstance.GetDesgById(Desg_ID);
            try
            {
                List<UserDesignation> desglist = new List<UserDesignation>();
                desglist = (from DataRow dr in dt.Rows
                            select new UserDesignation()
                            { 
                                Desg_ID=Convert.ToInt32(dr["Desg_ID"]),                           
                                Desg_Code = dr["Desg_Code"].ToString(),
                                Designation_Name = dr["Designation_Name"].ToString()
                               
                            }).ToList();
                return Json(desglist, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("Cannot Get Value");
            }
        }

    }
}