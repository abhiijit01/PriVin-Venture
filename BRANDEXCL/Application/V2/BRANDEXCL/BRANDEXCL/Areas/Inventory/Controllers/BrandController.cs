using BRANDEXCL.Business;
using BRANDEXCL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace BRANDEXCL.Areas.Inventory.Controllers
{
    public class BrandController : Controller
    {
        #region Get
        int returnvf = 0;
        // GET: Admin/Brand
        public ActionResult BrandIndex()
        {
            return View();
        }

        #endregion
        #region Post
        [HttpPost]
        public JsonResult InsertBrand(Brand theRole)
        {
            try
            {
                if (theRole.brandid >= 1)
                {
                    returnvf = BRANDEXCL.Business.BrandManagement.GetInstance.UpdateBrand(theRole);
                }
                else
                {
                    returnvf = BRANDEXCL.Business.BrandManagement.GetInstance.InsertBrand(theRole);
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
        public JsonResult UpdateBrand(Brand theRole)
        {
            try
            {
                int returnvf = BRANDEXCL.Business.BrandManagement.GetInstance.UpdateBrand(theRole);
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
        public JsonResult ViewBrand(string sidx, string sord, int page, int rows,
                    bool _search, string searchField, string searchOper, string searchString
                    )
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            sord = (sord == null) ? "" : sord;

            DataTable dt = BrandManagement.GetInstance.GetBrandList();
            try
            {

                List<Brand> BrandList = new List<Brand>();
                BrandList = (from DataRow dr in dt.Rows
                              select new Brand()
                              {
                                  brandid = Convert.ToInt32(dr["brandid"]),
                                  brandname = dr["brandname"].ToString(),
                              }).ToList();
                switch (searchField)
                {
                    case "brandname":
                        BrandList = BrandList.Where(t => t.brandname.Contains(searchString)).ToList();
                        break;
                }
                int totalRecords = BrandList.Count();
                var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
                if (sord.ToUpper() == "DESC")
                {
                    BrandList = BrandList.OrderByDescending(t => t.brandid).ToList();
                    BrandList = BrandList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                }
                else
                {
                    BrandList = BrandList.OrderBy(t => t.brandid).ToList();
                    BrandList = BrandList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                }
                var jsonData = new
                {
                    total = totalPages,
                    page,
                    records = totalRecords,
                    rows = BrandList
                };
                return Json(jsonData);

            }
            catch (Exception EX)
            {
                return Json("Could not find any Brand details");
            }
        }
        [HttpPost]
        public ActionResult DeleteBrand(string Id)

        {
            int[] nums = Array.ConvertAll(Id.Split(','), int.Parse);
            DataTable datta = new DataTable();
            datta.Columns.Add("brandid");
            foreach (int s in nums)
            {
                datta.Rows.Add(s);
            }

            string brandid = Common.GetSTRXMLResult(datta);
            try
            {
                DataTable dt = BrandManagement.GetInstance.DeleteBrand(brandid);
                return Json("Deleted Successfully");
            }
            catch (Exception Ex)
            {
                return Json("Could not find any Office details");
            }


        }
        [HttpPost]
        public JsonResult ViewBrandDDL()
        {
            DataTable dt = BrandManagement.GetInstance.GetBrandList();

            List<Brand> Brandlist = new List<Brand>();
            Brandlist = (from DataRow dr in dt.Rows
                          select new Brand()
                          {
                              brandid = Convert.ToInt32(dr["brandid"]),
                              brandname = dr["brandname"].ToString(),
                          }).ToList();
            return Json(Brandlist);

        }
        #endregion
    }
}