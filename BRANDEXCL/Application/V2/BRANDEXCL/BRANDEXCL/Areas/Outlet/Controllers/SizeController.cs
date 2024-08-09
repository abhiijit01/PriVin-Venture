using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using BRANDEXCL.Model;
using BRANDEXCL.Business;
using System.Data;

namespace BRANDEXCL.Areas.Outlet.Controllers
{
    public class SizeController : Controller
    {
        #region Get
        int returnvf = 0;
        // GET: Outlet/Size
        [HttpGet]
        public ActionResult SizeIndex()
        {
            return View();
        }
        public ActionResult IndexSize()
        {
            return View();
        }

        public ActionResult index1()
        {
            return View();
        }
        #endregion
        #region Post
        [HttpPost]
        public JsonResult InsertSize(Size theSize)
        {
            try
            {
                if (theSize.sizeid >= 1)
                {
                    returnvf = BRANDEXCL.Business.SizeManagement.GetInstance.UpdateSize(theSize);
                }
                else
                {
                    returnvf = BRANDEXCL.Business.SizeManagement.GetInstance.InsertSize(theSize);
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
        public JsonResult UpdateSize(Size theSize)
        {
            try
            {
                int returnvf = BRANDEXCL.Business.SizeManagement.GetInstance.UpdateSize(theSize);
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
                return Json("Upadte Failed");
            }
        }

        [HttpGet]
        public JsonResult ViewSize(string sidx, string sord, int page, int rows,
                    bool _search, string searchField, string searchOper, string searchString
                    )
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            sord = (sord == null) ? "" : sord;

            DataTable dt =SizeManagement.GetInstance.GetSizeList();
            try
            {
                List<Size> SizeList = new List<Size>();
                SizeList = (from DataRow dr in dt.Rows
                                select new Size()
                                {
                                    sizeid = Convert.ToInt32(dr["sizeid"]),
                                    descr = dr["descr"].ToString(),
                                }).ToList();
                switch (searchField)
                {
                    case "countnm":
                        SizeList = SizeList.Where(t => t.descr.Contains(searchString)).ToList();
                        break;
                }
                int totalRecords = SizeList.Count();
                var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
                if (sord.ToUpper() == "DESC")
                {
                    SizeList = SizeList.OrderByDescending(t => t.sizeid).ToList();
                    SizeList = SizeList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                }
                else
                {
                    SizeList = SizeList.OrderBy(t => t.sizeid).ToList();
                    SizeList = SizeList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                }
                var jsonData = new
                {
                    total = totalPages,
                    page,
                    records = totalRecords,
                    rows = SizeList
                };
                return Json(jsonData);

            }
            catch (Exception EX)
            {
                return Json("Could not find any Size details");
            }
        }
        [HttpPost]
        public ActionResult DeleteSize(string Id)

        {
            int[] nums = Array.ConvertAll(Id.Split(','), int.Parse);
            DataTable datta = new DataTable();
            datta.Columns.Add("sizeid");
            foreach (int s in nums)
            {
                datta.Rows.Add(s);
            }

            string countid = Common.GetSTRXMLResult(datta);
            try
            {
                DataTable dt =SizeManagement.GetInstance.DeleteSize(countid);
                return Json("Deleted Successfully");
            }
            catch (Exception Ex)
            {
                return Json("Could not find any Material details");
            }


        }
        [HttpPost]
        public JsonResult ViewSizeDDL()
        {
            DataTable dt = SizeManagement.GetInstance.GetSizeList();

            List<Size> Sizelist = new List<Size>();
            Sizelist = (from DataRow dr in dt.Rows
                            select new Size()
                            {
                                sizeid = Convert.ToInt32(dr["sizeid"]),
                                descr = dr["descr"].ToString(),
                            }).ToList();
            return Json(Sizelist);

        }

        #endregion
    }
}