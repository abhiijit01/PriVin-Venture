using BRANDEXCL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace BRANDEXCL.Areas.Outlet.Controllers
{
    [Area("Admin")]
    public class PageController : Controller
    {
        #region Decalration
        int ReturnValue = 0;
        #endregion
        // GET: Admin/Page

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InsertPage()
        {
            return View();
        }

        public ActionResult InsertUpdate()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(Page thepg)
        {
            try
            {
                if (thepg.pageid >= 1)
                {
                    ReturnValue = BRANDEXCL.Business.PageManagement.GetInstance.UpdatePage(thepg);
                }
                else
                {
                    ReturnValue = BRANDEXCL.Business.PageManagement.GetInstance.InsertPage(thepg);
                }

                if (ReturnValue >= 1)
                {
                    return Json("Record Added successfully.");
                }
                else if (ReturnValue == -1)
                {
                    return Json("Record alraedy Exist.");
                }
                else if (ReturnValue == -2)
                {
                    return Json("Please add Valid value.");
                }
                else
                {
                    return Json("Invalid values to add.");
                }
            }
            catch (Exception Ex)
            {
                return Json("Failed to add Record.");
            }
        }

        [HttpPost]
        public JsonResult DeletePage(string[] Finid)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("pageid");
            foreach (string s in Finid)
            {
                dt.Rows.Add(s);
            }
            string Fin_Id = Common.GetSTRXMLResult(dt);
            try
            {
                DataTable data = BRANDEXCL.Business.PageManagement.GetInstance.DeletePage(Fin_Id);
                return Json("Deleted Successfully");
            }
            catch
            {
                return Json("Could not find any Data to Delete");
            }
        }
        [HttpGet]
        public JsonResult PopulateFormField(int x)
        {
            DataTable dt = new DataTable();
            dt = BRANDEXCL.Business.PageManagement.GetInstance.GetPageById(x);
            try
            {
                List<Page> Pagelist = new List<Page>();
                Pagelist = (from DataRow dr in dt.Rows
                            select new Page()
                            {
                                pageid = x,
                                distext = dr["distext"].ToString(),
                                tooltip = dr["tooltip"].ToString(),
                                targeturl = dr["targeturl"].ToString(),
                                parentid = Convert.ToInt32(dr["parentid"]),
                            }).ToList();
                return Json(Pagelist);
            }
            catch
            {
                return Json("Cannot Get Value");
            }
        }

        [HttpGet]
        public JsonResult BindGrid()
        {
            DataTable dt = BRANDEXCL.Business.PageManagement.GetInstance.GetPageList();
            try
            {
                List<Page> Pagelist = new List<Page>();

                Pagelist = (from DataRow dr in dt.Rows
                            select new Page()
                            {
                                pageid = Convert.ToInt32(dr["pageid"]),
                                distext = dr["distext"].ToString(),
                                tooltip = dr["tooltip"].ToString(),
                                targeturl = dr["targeturl"].ToString()
                                //parentid = Convert.ToInt32(dr["parentid"]),
                            }).ToList();

                return Json(Pagelist);
            }
            catch
            {
                return Json("");
            }

        }
    }
}