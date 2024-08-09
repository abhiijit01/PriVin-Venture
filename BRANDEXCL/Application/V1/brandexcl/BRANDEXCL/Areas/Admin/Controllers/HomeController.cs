using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using System.Data;
using BLL;

namespace BRANDEXCL.Areas.Outlet.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        //Hii
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult logout()
        {
            try
            {
                Session.Abandon();
                return RedirectToAction("index", "login", new { Area = "Admin" });
            }
            catch(Exception 
            
            Ex)
            {
                return Json("Please Try for login first");
            }
        }
        [HttpGet]
        public JsonResult SelectRateSale(string invoice)
        {
            DataTable dt = SaleManagement.GetInstance.SelectRateSale();
            List<Sale> SaleList = new List<Sale>();
            SaleList = (from DataRow dr in dt.Rows
                        select new Sale()
                        {
                            //saledate= Convert.ToDateTime(dr["saledate"]),
                            finalprice = Convert.ToDecimal(dr["finalprice"]),
                        }).ToList();
            return Json(SaleList, JsonRequestBehavior.AllowGet);
        }

    }
}