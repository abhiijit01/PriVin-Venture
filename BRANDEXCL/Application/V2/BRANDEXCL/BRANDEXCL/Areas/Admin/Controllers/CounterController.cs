using BRANDEXCL.Business;
using BRANDEXCL.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace BRANDEXCL.Areas.Outlet.Controllers
{
    [Area("Admin")]
    public class CounterController : Controller
    {
        #region Get

        int returnvf = 0;

        // GET: Admin/Counter
        public ActionResult CounterIndex()
        {
            return View();
        }


        #endregion
        #region Post
        [HttpPost]
        public JsonResult InsertCounter(Counter theCounter)
        {
            try
            {
                if (theCounter.countid >= 1)
                {
                    returnvf = BRANDEXCL.Business.CounterManagement.GetInstance.UpdateCounter(theCounter);
                }
                else
                {
                    returnvf = BRANDEXCL.Business.CounterManagement.GetInstance.InsertCounter(theCounter);
                }

                if (returnvf >= 1) { return Json("Records added Successfully."); }
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
        public JsonResult UpdateCounter(Counter theCounter)
        {
            try
            {
                int returnvf = BRANDEXCL.Business.CounterManagement.GetInstance.UpdateCounter(theCounter);
                if (returnvf >= 1) { return Json("Records Updated Successfully."); }
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
        public JsonResult ViewCounter(string sidx, string sord, int page, int rows,
                    bool _search, string searchField, string searchOper, string searchString
                    )
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            sord = (sord == null) ? "" : sord;

            DataTable dt = CounterManagement.GetInstance.GetCounterList();
            try
            {
                List<Counter> CounterList = new List<Counter>();
                CounterList = (from DataRow dr in dt.Rows
                               select new Counter()
                               {
                                   countid = Convert.ToInt32(dr["countid"]),
                                   countnm = dr["countnm"].ToString(),
                               }).ToList();
                switch (searchField)
                {
                    case "countnm":
                        CounterList = CounterList.Where(t => t.countnm.Contains(searchString)).ToList();
                        break;
                }
                int totalRecords = CounterList.Count();
                var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
                if (sord.ToUpper() == "DESC")
                {
                    CounterList = CounterList.OrderByDescending(t => t.countid).ToList();
                    CounterList = CounterList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                }
                else
                {
                    CounterList = CounterList.OrderBy(t => t.countid).ToList();
                    CounterList = CounterList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                }
                var jsonData = new
                {
                    total = totalPages,
                    page,
                    records = totalRecords,
                    rows = CounterList
                };
                return Json(jsonData);

            }
            catch (Exception EX)
            {
                return Json("Could not find any Counter details");
            }
        }
        [HttpPost]
        public ActionResult DeleteCounter(string Id)

        {
            int[] nums = Array.ConvertAll(Id.Split(','), int.Parse);
            DataTable datta = new DataTable();
            datta.Columns.Add("countid");
            foreach (int s in nums)
            {
                datta.Rows.Add(s);
            }

            string countid = Common.GetSTRXMLResult(datta);
            try
            {
                DataTable dt = CounterManagement.GetInstance.DeleteCounter(countid);
                return Json("Deleted Successfully");
            }
            catch (Exception Ex)
            {
                return Json("Could not find any Counter details");
            }


        }
        [HttpPost]
        public JsonResult ViewCounterDDL()
        {
            DataTable dt = CounterManagement.GetInstance.GetCounterList();

            List<Counter> Counterlist = new List<Counter>();
            Counterlist = (from DataRow dr in dt.Rows
                           select new Counter()
                           {
                               countid = Convert.ToInt32(dr["countid"]),
                               countnm = dr["countnm"].ToString(),
                               countcode = dr["countcode"].ToString(),
                           }).ToList();
            return Json(Counterlist);

        }
        public JsonResult GetCounterlist12(string SearchedString)
        {
            DataTable dt = CounterManagement.GetInstance.GetCounterList();
            List<Counter> Counterlist = new List<Counter>();
            Counterlist = (from DataRow dr in dt.Rows
                           select new Counter()
                           {
                               countid = Convert.ToInt32(dr["countid"]),
                               countnm = dr["countnm"].ToString(),
                               countcode = dr["countcode"].ToString(),
                           }).ToList();
            Counterlist = Counterlist.Where(i => i.countnm.Contains(SearchedString)).ToList();
            return Json(Counterlist);
        }
        #endregion
    }
}