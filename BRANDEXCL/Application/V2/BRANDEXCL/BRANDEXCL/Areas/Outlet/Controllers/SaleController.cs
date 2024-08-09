using BRANDEXCL.Business;
using BRANDEXCL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization;



namespace BRANDEXCL.Areas.Outlet.Controllers
{
    public class SaleController : Controller
    {
        #region Declaration
        int returnvf = 0;
        // GET: Outlet/Sale
        public ActionResult SaleIndex()
        {
            return View();
        }
        [DataContract]
        public class JsonToList
        {
            [DataMember]
            public int saleid { get; set; }
            [DataMember]
            public string outcode { get; set; }
            [DataMember]
            public int purchid { get; set; }
            [DataMember]
            public string barcode { get; set; }
            [DataMember]
            public decimal priceexcludgst { get; set; }
            [DataMember]
            public decimal gst { get; set; }
            [DataMember]
            public decimal gstprice { get; set; }
            [DataMember]
            public decimal unitprice { get; set; }
            [DataMember]
            public decimal quanity { get; set; }
            [DataMember]
            public decimal discountper { get; set; }
            [DataMember]
            public decimal discountamount { get; set; }
            [DataMember]
            public string paymentmode { get; set; }
            [DataMember]
            public decimal finalprice { get; set; }
            [DataMember]
            public string email { get; set; }
            [DataMember]
            public decimal name { get; set; }

            [DataMember]
            public bool isactive { get; set; }
            [DataMember]
            public bool isdelete { get; set; }
            [DataMember]
            public string addon { get; set; }
            [DataMember]
            public int addby { get; set; }
            [DataMember]
            public string modon { get; set; }
            [DataMember]
            public int modby { get; set; }

        }
        #endregion
        #region Methods and Implimentaions
        [HttpPost]
        public JsonResult InsertSale(List<JsonToList> Sales)
        {
            string returnvf = string.Empty;
            try
            {
                List<JsonToList> TheJsonToList = new List<JsonToList>();
                int Salecntr = 1;
                DataTable dt = new DataTable();
                DataRow MovnoDr = default(DataRow);
                DataColumn outcode = new DataColumn("outcode", Type.GetType("System.String"));
                DataColumn purchid = new DataColumn("purchid", Type.GetType("System.String"));
                DataColumn barcode = new DataColumn("barcode", Type.GetType("System.String"));
                DataColumn priceexcludgst = new DataColumn("priceexcludgst", Type.GetType("System.String"));
                DataColumn gst = new DataColumn("gst", Type.GetType("System.String"));
                DataColumn gstprice = new DataColumn("gstprice", Type.GetType("System.String"));
                DataColumn unitprice = new DataColumn("unitprice", Type.GetType("System.String"));
                DataColumn quanity = new DataColumn("quanity", Type.GetType("System.String"));
                DataColumn discountper = new DataColumn("discountper", Type.GetType("System.String"));
                DataColumn discountamount = new DataColumn("discountamount", Type.GetType("System.String"));
                DataColumn paymentmode = new DataColumn("paymentmode", Type.GetType("System.String"));
                DataColumn finalprice = new DataColumn("finalprice", Type.GetType("System.String"));
                DataColumn mobile = new DataColumn("finalprice", Type.GetType("System.String"));
                DataColumn email = new DataColumn("email", Type.GetType("System.String"));
                DataColumn name = new DataColumn("name", Type.GetType("System.String"));

                dt.Columns.Add("outcode");
                dt.Columns.Add("purchid");
                dt.Columns.Add("barcode");
                dt.Columns.Add("priceexcludgst");
                dt.Columns.Add("gst");
                dt.Columns.Add("gstprice");
                dt.Columns.Add("unitprice");
                dt.Columns.Add("quanity");
                dt.Columns.Add("discountper");
                dt.Columns.Add("discountamount");
                dt.Columns.Add("paymentmode");
                dt.Columns.Add("finalprice");
                dt.Columns.Add("email");
                dt.Columns.Add("name");

                foreach (JsonToList Item in Sales)
                {
                    Salecntr++;
                    MovnoDr = dt.NewRow();
                    MovnoDr["outcode"] = Item.outcode;
                    MovnoDr["purchid"] = Item.purchid;
                    MovnoDr["barcode"] = Item.barcode;
                    MovnoDr["priceexcludgst"] = Item.priceexcludgst;
                    MovnoDr["gst"] = Item.gst;
                    MovnoDr["gstprice"] = Item.gstprice;
                    MovnoDr["unitprice"] = Item.unitprice;
                    MovnoDr["quanity"] = Item.quanity;
                    MovnoDr["discountper"] = Item.discountper;
                    MovnoDr["discountamount"] = Item.discountamount;
                    MovnoDr["paymentmode"] = Item.paymentmode;
                    MovnoDr["finalprice"] = Item.finalprice;
                    dt.Rows.Add(MovnoDr);
                }
                string SalDetails = Common.GetSTRXMLResult(dt);

                returnvf = SaleManagement.GetInstance.InsertSalesDetails(SalDetails,mobile.ToString(),email.ToString(), name.ToString());
                return Json(returnvf);
            }
            catch (Exception Ex)
            {
                return Json("Failed ..");
            }

        }

        [HttpGet]
        public JsonResult latestbiinoselectproduct(string invoice)
        {
            DataTable dt = SaleManagement.GetInstance.latestbiinoselectproduct(invoice);
            List<Sale> SaleList = new List<Sale>();
            SaleList = (from DataRow dr in dt.Rows
                        select new Sale()
                        {
                            prodname = dr["prodname"].ToString(),
                            sizename = dr["sizename"].ToString(),
                            quanity = Convert.ToInt32(dr["quanity"]),
                            unitprice = Convert.ToDecimal(dr["unitprice"]),
                            discountper = Convert.ToDecimal(dr["discountper"]),
                            finalprice = Convert.ToDecimal(dr["finalprice"])
                        }).ToList();
            return Json(SaleList);
        }
        [HttpGet]
        public JsonResult GetCustomerDetailsByMobNo(string mobileno)
        {
            DataTable dt = SaleManagement.GetInstance.GetCustomerDetailsByMobNo(mobileno);
            List<Sale> SaleList = new List<Sale>();
            SaleList = (from DataRow dr in dt.Rows
                        select new Sale()
                        {
                            emailid = dr["emailid"].ToString(),
                            custname = dr["custname"].ToString()
                        }).ToList();
            return Json(SaleList);
        }
        public ActionResult SaleReport() 
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetAllSoldProducts(string sidx, string sord, int page, int rows, 
                    bool _search, string searchField, string searchOper, string searchString
                    )
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            sord = (sord == null) ? "" : sord;
            DataTable dt = SaleManagement.GetInstance.GetAllSoldProducts();
            try
            {
                List<ReceivedProduct> ProductRecieveList = new List<ReceivedProduct>();
                ProductRecieveList = (from DataRow dr in dt.Rows
                                      select new ReceivedProduct()
                                      {
                                          invoiceno = dr["billno"].ToString(),
                                          purcdate = Convert.ToDateTime(dr["saledate"]),
                                          barcode = dr["barcode"].ToString(),
                                          prodname = dr["prodname"].ToString(),
                                          catname = dr["catname"].ToString(),
                                          brandname = dr["brandname"].ToString(),
                                          sizename = dr["sizename"].ToString(),
                                          unitprice = Convert.ToDecimal(dr["unitprice"]),
                                          qty = Convert.ToInt32(dr["quanity"]),
                                          discountper = Convert.ToDecimal(dr["discountper"]),
                                          discountamount = Convert.ToDecimal(dr["discountamount"]),
                                          gst = Convert.ToDecimal(dr["gst"]),
                                          gstprice = Convert.ToDecimal(dr["gstprice"]),
                                          finalprice = Convert.ToDecimal(dr["finalprice"]),
                                          paymentmode = dr["paymentmode"].ToString(),
                                      }).ToList();
                switch (searchField)
                {
                    case "invoiceno":
                        ProductRecieveList = ProductRecieveList.Where(t => t.purcdate == Convert.ToDateTime(searchString)).ToList();
                        break;
                    case "barcode":
                        ProductRecieveList = ProductRecieveList.Where(t => t.purcdate == Convert.ToDateTime(searchString)).ToList();
                        break;
                    case "prodname":
                        ProductRecieveList = ProductRecieveList.Where(t => t.prodname.Contains(searchString)).ToList();
                        break;
                    case "catname":
                        ProductRecieveList = ProductRecieveList.Where(t => t.catname.Contains(searchString)).ToList();
                        break;

                    case "brandname":
                        ProductRecieveList = ProductRecieveList.Where(t => t.brandname.Contains(searchString)).ToList();
                        break;
                    case "sizename":
                        ProductRecieveList = ProductRecieveList.Where(t => t.sizename.Contains(searchString)).ToList();
                        break;
                    case "finalprice":
                        ProductRecieveList = ProductRecieveList.Where(t => t.finalprice.ToString().Contains(searchString)).ToList();
                        break;
                    case "paymentmode":
                        ProductRecieveList = ProductRecieveList.Where(t => t.paymentmode.Contains(searchString)).ToList();
                        break;
                }
                int totalRecords = ProductRecieveList.Count();
                var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
                if (sord.ToUpper() == "DESC")
                {
                    ProductRecieveList = ProductRecieveList.OrderByDescending(t => t.purchid).ToList();
                    ProductRecieveList = ProductRecieveList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                }
                else
                {
                    ProductRecieveList = ProductRecieveList.OrderBy(t => t.purchid).ToList();
                    ProductRecieveList = ProductRecieveList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                }
                var jsonData = new
                {
                    rows = ProductRecieveList
                };
                return Json(jsonData);
            }
            catch (Exception Ex)
            {
                return Json("Cann't find any Received products");
            }

        }
        public ActionResult ProfitLossReport()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetProfitLossDetails(string sidx, string sord, int page, int rows,
                    bool _search, string searchField, string searchOper, string searchString
                    ) 
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            sord = (sord == null) ? "" : sord;
            DataTable dt = SaleManagement.GetInstance.GetProfitAndLossDetails(); 
            try
            {
                List<ReceivedProduct> ProductRecieveList = new List<ReceivedProduct>();
                ProductRecieveList = (from DataRow dr in dt.Rows
                                      select new ReceivedProduct()
                                      {
                                          saledate = Convert.ToDateTime(dr["saledate"]),
                                          barcode = dr["barcode"].ToString(),
                                          prodname = dr["prodname"].ToString(),
                                          catname = dr["catname"].ToString(),
                                          brandname = dr["brandname"].ToString(),
                                          sizename = dr["sizename"].ToString(),
                                          saleprice = Convert.ToDecimal(dr["saleprice"]),
                                          purchprice = Convert.ToDecimal(dr["purchprice"]),
                                          profitprice = Convert.ToDecimal(dr["profitprice"]),
                                          lossprice = Convert.ToDecimal(dr["lossprice"])
                                      }).ToList();
                switch (searchField)
                {
                    case "saledate":
                        ProductRecieveList = ProductRecieveList.Where(t => t.saledate == Convert.ToDateTime(searchString)).ToList();
                        break;
                    case "barcode":
                        ProductRecieveList = ProductRecieveList.Where(t => t.barcode.Contains(searchString)).ToList();
                        break;
                    case "prodname":
                        ProductRecieveList = ProductRecieveList.Where(t => t.prodname.Contains(searchString)).ToList();
                        break;
                }
                int totalRecords = ProductRecieveList.Count();
                var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
                if (sord.ToUpper() == "DESC")
                {
                    ProductRecieveList = ProductRecieveList.OrderByDescending(t => t.purchid).ToList();
                    ProductRecieveList = ProductRecieveList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                }
                else
                {
                    ProductRecieveList = ProductRecieveList.OrderBy(t => t.purchid).ToList();
                    ProductRecieveList = ProductRecieveList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                }
                var jsonData = new
                {
                    rows = ProductRecieveList
                };
                return Json(jsonData);
            }
            catch (Exception Ex)
            {
                return Json("Cann't find any Received products");
            }

        }
        #endregion
    }
}
