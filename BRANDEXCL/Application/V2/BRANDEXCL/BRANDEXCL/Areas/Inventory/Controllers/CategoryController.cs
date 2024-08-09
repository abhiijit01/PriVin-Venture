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
    public class CategoryController : Controller
    {
        #region Get
        int returnvf = 0;
        // GET: Admin/Category
        public ActionResult CategoryIndex()
        {
            return View();
        }

        #endregion
        #region Post
        [HttpPost]
        public JsonResult InsertCategory(Category theRole)
        {
            try
            {
                if (theRole.catid >= 1)
                {
                    returnvf = BRANDEXCL.Business.CategoryManagement.GetInstance.UpdateCategory(theRole);
                }
                else
                {
                    returnvf = BRANDEXCL.Business.CategoryManagement.GetInstance.InsertCategory(theRole);
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
        public JsonResult UpdateCategory(Category theRole)
        {
            try
            {
                int returnvf = BRANDEXCL.Business.CategoryManagement.GetInstance.UpdateCategory(theRole);
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
        public JsonResult ViewCategory(string sidx, string sord, int page, int rows,
                    bool _search, string searchField, string searchOper, string searchString
                    )
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            sord = (sord == null) ? "" : sord;

            DataTable dt = CategoryManagement.GetInstance.GetCategoryList();
            try
            {

                List<Category> CategoryList = new List<Category>();
                CategoryList = (from DataRow dr in dt.Rows
                              select new Category()
                              {
                                  catid = Convert.ToInt32(dr["catid"]),
                                  catname = dr["catname"].ToString(),
                              }).ToList();
                switch (searchField)
                {
                    case "catname":
                        CategoryList = CategoryList.Where(t => t.catname.Contains(searchString)).ToList();
                        break;
                }
                int totalRecords = CategoryList.Count();
                var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
                if (sord.ToUpper() == "DESC")
                {
                    CategoryList = CategoryList.OrderByDescending(t => t.catid).ToList();
                    CategoryList = CategoryList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                }
                else
                {
                    CategoryList = CategoryList.OrderBy(t => t.catid).ToList();
                    CategoryList = CategoryList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                }
                var jsonData = new
                {
                    total = totalPages,
                    page,
                    records = totalRecords,
                    rows = CategoryList
                };
                return Json(jsonData);

            }
            catch (Exception EX)
            {
                return Json("Could not find any Category details");
            }
        }
        [HttpPost]
        public ActionResult DeleteCategory(string Id)

        {
            int[] nums = Array.ConvertAll(Id.Split(','), int.Parse);
            DataTable datta = new DataTable();
            datta.Columns.Add("catid");
            foreach (int s in nums)
            {
                datta.Rows.Add(s);
            }

            string catid = Common.GetSTRXMLResult(datta);
            try
            {
                DataTable dt = CategoryManagement.GetInstance.DeleteCategory(catid);
                return Json("Deleted Successfully");
            }
            catch (Exception Ex)
            {
                return Json("Could not find any Office details");
            }


        }
        [HttpPost]
        public JsonResult ViewCategoryDDL()
        {
            DataTable dt = CategoryManagement.GetInstance.GetCategoryList();

            List<Category> Categorylist = new List<Category>();
            Categorylist = (from DataRow dr in dt.Rows
                          select new Category()
                          {
                              catid = Convert.ToInt32(dr["catid"]),
                              catname = dr["catname"].ToString(),
                          }).ToList();
            return Json(Categorylist);

        }
        #endregion
    }
}