using BRANDEXCL.Business;
using BRANDEXCL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace BRANDEXCL.Areas.Outlet.Controllers
{
    [Area("Admin")]
    public class OutletController : Controller
    {
        #region Get
        int returnvf = 0;
        // GET: Admin/Outlet
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OutletIndex()
        {
            return View();
        }

        #endregion
        #region Post
        [HttpPost]
        public JsonResult InsertOutlet(Outlets theRole)
        {
            try
            {
                if (theRole.outid >= 1)
                {
                    returnvf = BRANDEXCL.Business.OutletsManagement.GetInstance.UpdateOutlet(theRole);
                }
                else
                {
                    returnvf = BRANDEXCL.Business.OutletsManagement.GetInstance.InsertOutlet(theRole);
                }

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
        [HttpPost]
        public JsonResult UpdateOutlet(Outlets theRole)
        {
            try
            {
                int returnvf = BRANDEXCL.Business.OutletsManagement.GetInstance.UpdateOutlet(theRole);
                if (returnvf > 1) { return Json("Records Updated Successfully."); }
                else if (returnvf == -1)
                {
                    return Json("Records Already Exists.");
                }
                else if (returnvf == -2)
                {
                    return Json("Failed to Update Record.");
                }
                else { return Json(""); }

            }
            catch (Exception ex)
            {
                return Json("Update Failed");
            }
        }

        [HttpGet]
        public JsonResult ViewOutlet(string sidx, string sord, int page, int rows,
                    bool _search, string searchField, string searchOper, string searchString
                    )
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            sord = (sord == null) ? "" : sord;

            DataTable dt = OutletsManagement.GetInstance.GetOutletList();
            try
            {

                List<Outlets> OutletList = new List<Outlets>();
                OutletList = (from DataRow dr in dt.Rows
                              select new Outlets()
                              {
                                  outid = Convert.ToInt32(dr["outid"]),
                                  outnm = dr["outnm"].ToString(),
                                  outat = dr["outat"].ToString(),
                                  officename = dr["onm"].ToString(),
                                  statename = dr["St_Nm"].ToString(),
                                  distname = dr["Dst_Nm"].ToString(),
                                  outpin = dr["outpin"].ToString(),
                                  cpnm = dr["cpnm"].ToString(),
                                  contct = dr["contct"].ToString(),
                                  cpemail = dr["cpemail"].ToString(),
                              }).ToList();
                switch (searchField)
                {
                    case "outnm":
                        OutletList = OutletList.Where(t => t.outnm.Contains(searchString)).ToList();
                        break;
                    case "statename":
                        OutletList = OutletList.Where(t => t.statename.Contains(searchString)).ToList();
                        break;

                    case "distname":
                        OutletList = OutletList.Where(t => t.distname.Contains(searchString)).ToList();
                        break;

                    case "cpemail":
                        OutletList = OutletList.Where(t => t.cpemail.Contains(searchString)).ToList();
                        break;

                }
                int totalRecords = OutletList.Count();
                var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
                if (sord.ToUpper() == "DESC")
                {
                    OutletList = OutletList.OrderByDescending(t => t.outid).ToList();
                    OutletList = OutletList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                }
                else
                {
                    OutletList = OutletList.OrderBy(t => t.outid).ToList();
                    OutletList = OutletList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                }
                var jsonData = new
                {
                    total = totalPages,
                    page,
                    records = totalRecords,
                    rows = OutletList
                };
                return Json(jsonData);

            }
            catch (Exception EX)
            {
                return Json("Could not find any Outlet details");
            }
        }
        [HttpPost]
        public ActionResult DeleteOutlet(string Id)

        {
            int[] nums = Array.ConvertAll(Id.Split(','), int.Parse);
            DataTable datta = new DataTable();
            datta.Columns.Add("outid");
            foreach (int s in nums)
            {
                datta.Rows.Add(s);
            }

            string outid = Common.GetSTRXMLResult(datta);
            try
            {
                DataTable dt = OutletsManagement.GetInstance.DeleteOutlet(outid);
                return Json("Deleted Successfully");
            }
            catch (Exception Ex)
            {
                return Json("Could not find any Office details");
            }


        }
        [HttpPost]
        public JsonResult ViewOutletDDL()
        {
            DataTable dt = OutletsManagement.GetInstance.GetOutletList();

            List<Outlets> Outletlist = new List<Outlets>();
            Outletlist = (from DataRow dr in dt.Rows
                          select new Outlets()
                          {
                              outid = Convert.ToInt32(dr["outid"]),
                              outnm = dr["outnm"].ToString(),
                          }).ToList();
            return Json(Outletlist);

        }
        public JsonResult OutletSelectByUserId()
        {
            DataTable dt = NewUserBs.GetInstance.OutletSelectByUserId(Common.LoggedInUser[0].Usr_Id);
            // MasterState EmpRepo = new MasterState();
            List<NewUser> outlist = new List<NewUser>();
            outlist = (from DataRow dr in dt.Rows
                       select new NewUser()
                       {
                           outid = Convert.ToInt32(dr["outid"]),
                           outletname = dr["outnm"].ToString(),
                           outcode = dr["outcode"].ToString()
                       }).ToList();
            return Json(outlist);
        }
        #endregion

    } 
}