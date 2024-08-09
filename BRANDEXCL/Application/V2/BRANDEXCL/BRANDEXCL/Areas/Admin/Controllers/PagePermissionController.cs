using BRANDEXCL.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using BRANDEXCL.Business;

namespace BRANDEXCL.Areas.Outlet.Controllers
{
    [Area("Admin")]
    public class PagePermissionController : Controller
    {
        // GET: Admin/PagePermissionController
        public ActionResult PagePermission()
        {
            return View();
        }

        [HttpGet]

        public JsonResult BindGrid(int RoleID, string sidx, string sord, int page, int rows,
            bool _search, string searchField, string searchOper, string searchString)
        {

            DataTable dt = PermissionManagement.GetInstance.GetPagePermissionListByRoleID(RoleID);
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            sord = (sord == null) ? "" : sord;
            try
            {
                List<Permission> PermissionList = new List<Permission>();
                PermissionList = (from DataRow dr in dt.Rows
                                  select new Permission()
                                  {
                                      permid = int.Parse(Common.ReturnZeroIfNull(dr["permid"].ToString())),
                                      pageid = int.Parse(Common.ReturnZeroIfNull(dr["pageid"].ToString())),
                                      roleid = int.Parse(Common.ReturnZeroIfNull(dr["roleid"].ToString())),
                                      roleDesc = dr["RoleDesc"].ToString(),
                                      distext = dr["distext"].ToString(),
                                      targeturl = dr["targeturl"].ToString(),
                                      parentid = int.Parse(Common.ReturnZeroIfNull(dr["parentid"].ToString())),
                                      canadd = bool.Parse(dr["canadd"].ToString()),
                                      canedit = bool.Parse(dr["canedit"].ToString()),
                                      canview = bool.Parse(dr["canview"].ToString()),
                                      candelete = bool.Parse(dr["candelete"].ToString()),
                                      IsActive = bool.Parse(dr["IsActive"].ToString()),
                                  }).ToList();

                var jsonData = new
                {
                    total = 0,
                    page = 0,
                    records = 0,
                    rows = PermissionList
                };
                return Json(jsonData);
            }
            catch (Exception ee)
            {
                return Json(ee);
            }
        }



        [HttpPost]
        public JsonResult SavePage(List<Permission> DataList)
        {
            try
            {
                int returnpage = 0;


                var xml = new XElement("Permission",
          from page in DataList
          select new XElement("MyTable",
                             new XElement("roleid", page.roleid),
                             new XElement("pageid", page.pageid),
                             new XElement("canadd", page.canadd),
                             new XElement("canedit", page.canedit),
                             new XElement("candelete", page.candelete),
                             new XElement("canview", page.canview)
                         ));

                string x = xml.ToString();
                returnpage = BRANDEXCL.Business.PermissionManagement.GetInstance.InsertPagePermission(x);
                if (returnpage > 1)
                {
                    return Json("Pages added Successfully.");
                }
                else
                {
                    return Json("Could find Pages to Add.");
                }
            }
            catch (Exception ee)
            {
                return Json(ee + "Pages add Failed.");
            }
        }
        public JsonResult GetPageByRoleId()
        {
            DataTable dt = PermissionManagement.GetInstance.GetPagePermissionListByRoleID(Common.LoggedInUser[0].RoleID);
            if (dt != null)
            {
                List<Permission> PermissionList = new List<Permission>();
                PermissionList = (from DataRow dr in dt.Rows
                                  select new Permission()
                                  {
                                      permid = int.Parse(Common.ReturnZeroIfNull(dr["permid"].ToString())),
                                      pageid = int.Parse(Common.ReturnZeroIfNull(dr["pageid"].ToString())),
                                      roleid = int.Parse(Common.ReturnZeroIfNull(dr["roleid"].ToString())),
                                      roleDesc = dr["RoleDesc"].ToString(),
                                      distext = dr["distext"].ToString(),
                                      targeturl = dr["targeturl"].ToString(),
                                      parentid = int.Parse(Common.ReturnZeroIfNull(dr["parentid"].ToString())),
                                      canadd = bool.Parse(dr["canadd"].ToString()),
                                      canedit = bool.Parse(dr["canedit"].ToString()),
                                      canview = bool.Parse(dr["canview"].ToString()),
                                      candelete = bool.Parse(dr["candelete"].ToString()),
                                      IsActive = bool.Parse(dr["IsActive"].ToString()),
                                  }).ToList();
                return Json(PermissionList);

            }
            else
            {
                return Json("Cannot Find any User.");
            }

        }

        public JsonResult GetPagesListByRoleId()
        {


           DataTable dt = PermissionManagement.GetInstance.GetPagesListByRoleID(Common.LoggedInUser[0].RoleID);
            if (dt != null)
            {
                List<Permission> PermissionList = new List<Permission>();
                PermissionList = (from DataRow dr in dt.Rows
                                  select new Permission()
                                  {
                                      permid = int.Parse(Common.ReturnZeroIfNull(dr["permid"].ToString())),
                                      pageid = int.Parse(Common.ReturnZeroIfNull(dr["pageid"].ToString())),
                                      roleid = int.Parse(Common.ReturnZeroIfNull(dr["roleid"].ToString())),
                                      roleDesc = dr["RoleDesc"].ToString(),
                                      distext = dr["distext"].ToString(),
                                      targeturl = dr["targeturl"].ToString(),
                                      parentid = int.Parse(Common.ReturnZeroIfNull(dr["parentid"].ToString())),
                                      canadd = bool.Parse(dr["canadd"].ToString()),
                                      canedit = bool.Parse(dr["canedit"].ToString()),
                                      canview = bool.Parse(dr["canview"].ToString()),
                                      candelete = bool.Parse(dr["candelete"].ToString()),
                                      IsActive = bool.Parse(dr["IsActive"].ToString()),
                                  }).ToList();
                return Json(PermissionList);

            }
            else
            {
                return Json("Cannot Find any User.");
            }

        }

    }
}