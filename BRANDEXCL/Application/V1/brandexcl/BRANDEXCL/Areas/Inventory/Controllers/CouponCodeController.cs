using BOL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using System.Text;
using ClosedXML.Excel;
using System.IO;

namespace BRANDEXCL.Areas.Inventory.Controllers
{
    public class CouponCodeController : Controller
    {
        #region Get
        int returnvf = 0;
        // GET: Inventory/CouponCode
        public ActionResult CreateCouponCode()
        {
            return View();
        }

        #endregion
        #region Post
        [HttpPost]
        public JsonResult InsertCouponCode(CouponCode theRole)
        {
            try
            {
                for (int i = 0; i < theRole.totalcoupons; i++)
                {
                    theRole.couponcode = "TBD" + theRole.offerprice.ToString("00") + generateCouponCode();
                    //DateTime.Now.ToString("yyMMddHHmmss");
                    returnvf = CouponCodeManagement.GetInstance.InsertCouponCode(theRole);
                }
                if (returnvf > 1) { return Json("Records added Successfully."); }
                else
                {
                    return Json("Failed to add Record.");
                }
            }
            catch
            {
                return Json("Records not added,");
            }
        }
        [HttpGet]
        public JsonResult ViewCouponCode(string sidx, string sord, int page, int rows,
                    bool _search, string searchField, string searchOper, string searchString
                    )
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            sord = (sord == null) ? "" : sord;

            DataTable dt = CouponCodeManagement.GetInstance.GetCouponCodeList("all");
            try
            {

                List<CouponCode> CategoryList = new List<CouponCode>();
                CategoryList = (from DataRow dr in dt.Rows
                                select new CouponCode()
                                {
                                    coupondesc = dr["coupondesc"].ToString(),
                                    validfrom = Convert.ToDateTime(dr["validfrom"]),
                                    validto = Convert.ToDateTime(dr["validto"]),
                                    totalcoupons = Convert.ToInt32(dr["totalcoupons"]),
                                    redeemedcoupons = Convert.ToInt32(dr["redeemedcoupons"]),
                                }).ToList();
                switch (searchField)
                {
                    case "coupondesc":
                        CategoryList = CategoryList.Where(t => t.coupondesc.ToString().Contains(searchString)).ToList();
                        break;
                }
                int totalRecords = CategoryList.Count();
                var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
                if (sord.ToUpper() == "DESC")
                {
                    CategoryList = CategoryList.OrderByDescending(t => t.totalcoupons).ToList();
                    CategoryList = CategoryList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                }
                else
                {
                    CategoryList = CategoryList.OrderBy(t => t.totalcoupons).ToList();
                    CategoryList = CategoryList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                }
                var jsonData = new
                {
                    total = totalPages,
                    page,
                    records = totalRecords,
                    rows = CategoryList
                };
                return Json(jsonData, JsonRequestBehavior.AllowGet);

            }
            catch (Exception EX)
            {
                return Json("Could not find any Category details");
            }
        }
        public string generateCouponCode()
        {
            string RandomNum = "";
            StringBuilder randomText = new StringBuilder();
            string Number = "1234567890";
            Random r = new Random();
            for (int j = 1; j <= 6; j++)
            {
                //generating the random code
                randomText.Append(Number[r.Next(Number.Length)]);
            }
            RandomNum = randomText.ToString();
            return RandomNum;
        }
        #region Export to excel CouponCode
        public ActionResult ExportCouponCodes()
        {
            DataTable dt = CouponCodeManagement.GetInstance.GetCouponCodeList("excel");
            List<CouponCode> couponCodes = new List<CouponCode>();
            couponCodes = (from DataRow dr in dt.Rows
                           select new CouponCode()
                           {
                               coupondesc = dr["coupondesc"].ToString(),
                               validfrom = Convert.ToDateTime(dr["validfrom"]),
                               validto = Convert.ToDateTime(dr["validto"]),
                               couponcode = dr["couponcode"].ToString(),
                               isredeemed = Convert.ToBoolean(dr["isredeemed"]),
                           }).ToList();
            ExportCouponCodes(couponCodes);
            return null;
        }
        private void ExportCouponCodes(List<CouponCode> data)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("CouponCode" + System.DateTime.Now.ToString("dd-MM-yyyy"));
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Coupon Description";
                worksheet.Cell(currentRow, 2).Value = "Valid From";
                worksheet.Cell(currentRow, 3).Value = "Valid To";
                worksheet.Cell(currentRow, 4).Value = "Coupon Code";
                worksheet.Cell(currentRow, 5).Value = "Is Redeemed";

                foreach (CouponCode val in data)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = val.coupondesc;
                    worksheet.Cell(currentRow, 2).Value = val.validfrom;
                    worksheet.Cell(currentRow, 3).Value = val.validto;
                    worksheet.Cell(currentRow, 4).Value = "'" + val.couponcode;
                    if (val.isredeemed == true)
                    {
                        worksheet.Cell(currentRow, 5).Value = "Yes";
                        worksheet.Cell(currentRow, 5).Style.Fill.BackgroundColor = XLColor.Red;
                    }
                    else
                    {
                        worksheet.Cell(currentRow, 5).Value = "No";
                    }
                }
                var stream = new MemoryStream();
                workbook.SaveAs(stream);
                var content = stream.ToArray();
                Response.Clear();
                Response.Headers.Add("content-disposition", "attachment;filename=" + "CouponCode" + System.DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx");
                Response.ContentType = "application/xlsx";
                Response.BinaryWrite(content);
                Response.Flush();
            }
        }
        #endregion
        #endregion
    }
}