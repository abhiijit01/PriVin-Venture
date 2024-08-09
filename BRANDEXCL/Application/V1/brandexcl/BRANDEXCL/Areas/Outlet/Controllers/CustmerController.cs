using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using BOL;
using BLL;

namespace BRANDEXCL.Areas.Outlet.Controllers
{
    public class CustmerController : Controller
    {
        #region Declaretion 
        // GET: Outlet/Custmerk
        int returnvf = 0;
        public ActionResult Index()
        {
            return View();
        }
        #endregion
        #region Methods and implimentations
        [HttpPost]
        public JsonResult SelectCustmerByMobileNo(string mobileno)
        {
            DataTable dt = new DataTable();
            dt = BLL.CustmerManagement.GetInstance.SelectCustmerByMobileNo(mobileno);
            List<Custmer> CustList = new List<Custmer>();
            CustList = (from DataRow dr in dt.Rows
                        select new Custmer()
                        {
                            exchinvoice = dr["exchinvoice"].ToString(),
                            custname = dr["custname"].ToString(),
                            custcode = dr["custcode"].ToString()
                        }).ToList();
            return Json(CustList, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SaveCustmerDetail(Custmer theCustmer)
        {
          try
            {
                
                if(theCustmer.custid == 0)
                {
                    returnvf = BLL.CustmerManagement.GetInstance.SaveCustmerDetail(theCustmer);
                }
                if (returnvf >=1)
                {
                    return Json("Custmer Added Successfully");
                }
                else if(returnvf==-1)
                {
                    return Json("Custmer Already Exist");
                }
                else if(returnvf==-2)
                {
                    return Json("Custmer not Added ");
                }
                else
                {
                    return Json("");
                }
                
            }
            catch(Exception Ex)
            {
                return Json("Record cant't added");
            }
        }
        #endregion
    }
}