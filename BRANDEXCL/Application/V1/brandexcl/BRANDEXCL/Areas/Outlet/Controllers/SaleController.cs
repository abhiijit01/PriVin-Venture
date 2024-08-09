using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using System.Runtime.Serialization;
using ClosedXML.Excel;
using System.IO;
using System.Xml.Linq;
using System.Text.RegularExpressions;

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
        public ActionResult ExchangeItem() 
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
            public string mobileno { get; set; }
            [DataMember] 
            public string email { get; set; }
            [DataMember]
            public string name { get; set; }

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
            [DataMember]
            public string billno { get; set; }
            [DataMember]
            public int couponid { get; set; }
            [DataMember]
            public string comment { get; set; } 
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
                DataColumn couponid = new DataColumn("couponid", Type.GetType("System.String"));
                DataColumn comment = new DataColumn("comment", Type.GetType("System.String"));

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
                dt.Columns.Add("couponid");
                dt.Columns.Add("comment");

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
                    MovnoDr["comment"] = Item.comment;
                    MovnoDr["couponid"] = Item.couponid;
                    dt.Rows.Add(MovnoDr);
                }
                string SalDetails = Common.GetSTRXMLResult(dt);

                returnvf = SaleManagement.GetInstance.InsertSalesDetails(SalDetails, Sales[0].mobileno, Sales[0].email, Sales[0].name, Sales[0].couponid);
                return Json(returnvf);
            }
            catch (Exception Ex)
            {
                return Json("Failed ..");
            }

        }

        [HttpGet]
        public JsonResult latestbiinoselectproduct(string invoice, string mobileno)
        {
            DataTable dt = SaleManagement.GetInstance.latestbiinoselectproduct(invoice, mobileno);
            List<Sale> SaleList = new List<Sale>();
            SaleList = (from DataRow dr in dt.Rows
                        select new Sale()
                        {
                            prodname = dr["prodname"].ToString(),
                            sizename = dr["sizename"].ToString(),
                            quanity = Convert.ToInt32(dr["quanity"]),
                            unitprice = Convert.ToDecimal(dr["unitprice"]),
                            discountper = Convert.ToDecimal(dr["discountper"]),
                            finalprice = Convert.ToDecimal(dr["finalprice"]),
                            billno = dr["billno"].ToString(),
                            addon= Convert.ToDateTime(dr["addon"]).ToString("dd-MMM-yy")
                        }).ToList();
            return Json(SaleList, JsonRequestBehavior.AllowGet);
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
            return Json(SaleList, JsonRequestBehavior.AllowGet);
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
                                          CouponOfferd = Convert.ToDecimal(dr["CouponOfferd"]),
                                          comment = dr["comment"].ToString(),
                                          mobileno = dr["mobileno"].ToString(),
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
                    total = totalPages,
                    page,
                    records = totalRecords,
                    rows = ProductRecieveList
                };
                return Json(jsonData, JsonRequestBehavior.AllowGet);
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
                    total = totalPages,
                    page,
                    records = totalRecords,
                    rows = ProductRecieveList
                };
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json("Cann't find any Received products");
            }

        }
        [HttpGet]
        public JsonResult GetInvoicesByMobileOrInvoice(string invoice, string mobileno) 
        {
            DataTable dt = SaleManagement.GetInstance.GetInvoicesByMobileOrInvoice(invoice, mobileno);
            List<Sale> SaleList = new List<Sale>();
            SaleList = (from DataRow dr in dt.Rows
                        select new Sale()
                        {
                            prodname = dr["prodname"].ToString(),
                            sizename = dr["sizename"].ToString(),
                            quanity = Convert.ToInt32(dr["quanity"]),
                            unitprice = Convert.ToDecimal(dr["unitprice"]),
                            discountper = Convert.ToDecimal(dr["discountper"]),
                            finalprice = Convert.ToDecimal(dr["finalprice"]),
                            billno = dr["billno"].ToString(),
                            addon = Convert.ToDateTime(dr["addon"]).ToString("dd-MMM-yy")
                        }).ToList();
            return Json(SaleList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetAllSaleByInvoiceno(string invoices, string sidx, string sord, int page, int rows,
                    bool _search, string searchField, string searchOper, string searchString)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            sord = (sord == null) ? "" : sord;
            DataTable dt = SaleManagement.GetInstance.GetAllSaleByInvoiceno(invoices);
            List<Sale> SaleList = new List<Sale>();
            try
            {
                SaleList = (from DataRow dr in dt.Rows
                            select new Sale()
                            {
                                saleid = Convert.ToInt32(dr["saleid"]),
                                prodname = dr["prodname"].ToString(),
                                sizename = dr["sizename"].ToString(),
                                quanity = Convert.ToInt32(dr["quanity"]),
                                unitprice = Convert.ToDecimal(dr["unitprice"]),
                                discountper = Convert.ToDecimal(dr["discountper"]),
                                finalprice = Convert.ToDecimal(dr["finalprice"]),
                                billno = dr["billno"].ToString(),
                                mobile = dr["mobile"].ToString(),
                                addon = Convert.ToDateTime(dr["addon"]).ToString("dd-MMM-yy")
                            }).ToList();
                switch (searchField)
                {
                    case "billno":
                        SaleList = SaleList.Where(t => t.billno.Contains(searchString)).ToList();
                        break;
                    case "prodname":
                        SaleList = SaleList.Where(t => t.prodname.Contains(searchString)).ToList();
                        break;
                }
                int totalRecords = SaleList.Count();
                var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
                if (sord.ToUpper() == "DESC")
                {
                    SaleList = SaleList.OrderByDescending(t => t.purchid).ToList();
                    SaleList = SaleList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                }
                else
                {
                    SaleList = SaleList.OrderBy(t => t.purchid).ToList();
                    SaleList = SaleList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                }
                var jsonData = new
                {
                    total = totalPages,
                    page,
                    records = totalRecords,
                    rows = SaleList
                };
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json("Cann't find any Received products");
            }
        }
        #endregion
        #region Export to excel profit and loss report
        public ActionResult ExportSalesReport()
        {
            DataTable dt = SaleManagement.GetInstance.GetAllSoldProducts();
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
                                      CouponOfferd = Convert.ToDecimal(dr["couponOfferd"]),
                                      comment = dr["comment"].ToString(),
                                      mobileno = dr["mobileno"].ToString(),
                                  }).ToList();
            ExportSalesReport(ProductRecieveList);
            return null;
        }
        private void ExportSalesReport(List<ReceivedProduct> data)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("SalesReport" + System.DateTime.Now.ToString("dd-MM-yyyy"));
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Invoice No";
                worksheet.Cell(currentRow, 2).Value = "Mobile No";
                worksheet.Cell(currentRow, 3).Value = "Date";
                worksheet.Cell(currentRow, 4).Value = "Barcode";
                worksheet.Cell(currentRow, 5).Value = "Product";
                worksheet.Cell(currentRow, 6).Value = "Category";
                worksheet.Cell(currentRow, 7).Value = "Brand";
                worksheet.Cell(currentRow, 8).Value = "Size";
                worksheet.Cell(currentRow, 9).Value = "MRP";
                worksheet.Cell(currentRow, 10).Value = "Quantity";
                worksheet.Cell(currentRow, 11).Value = "Discount";
                worksheet.Cell(currentRow, 12).Value = "Discounted Amount";
                worksheet.Cell(currentRow, 13).Value = "GST";
                worksheet.Cell(currentRow, 14).Value = "GST Amount";
                worksheet.Cell(currentRow, 15).Value = "Final Price";
                worksheet.Cell(currentRow, 16).Value = "Payment Mode";
                worksheet.Cell(currentRow, 17).Value = "Coupon Offered(%)";
                worksheet.Cell(currentRow, 18).Value = "Comment";

                foreach (ReceivedProduct val in data)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = val.invoiceno;
                    worksheet.Cell(currentRow, 2).Value = val.mobileno;
                    worksheet.Cell(currentRow, 3).Value = val.purcdate;
                    worksheet.Cell(currentRow, 4).Value = "'" + val.barcode;
                    worksheet.Cell(currentRow, 5).Value = val.prodname;
                    worksheet.Cell(currentRow, 6).Value = val.catname;
                    worksheet.Cell(currentRow, 7).Value = val.brandname;
                    worksheet.Cell(currentRow, 8).Value = val.sizename;
                    worksheet.Cell(currentRow, 9).Value = val.unitprice;
                    worksheet.Cell(currentRow, 10).Value = val.qty;
                    worksheet.Cell(currentRow, 11).Value = val.discountper;
                    worksheet.Cell(currentRow, 12).Value = val.discountamount;
                    worksheet.Cell(currentRow, 13).Value = val.gst;
                    worksheet.Cell(currentRow, 14).Value = val.gstprice;
                    worksheet.Cell(currentRow, 15).Value = val.finalprice;
                    worksheet.Cell(currentRow, 16).Value = val.paymentmode;
                    worksheet.Cell(currentRow, 17).Value = val.CouponOfferd;
                    worksheet.Cell(currentRow, 18).Value = val.comment;
                }
                var stream = new MemoryStream();
                workbook.SaveAs(stream);
                var content = stream.ToArray();
                Response.Clear();
                Response.Headers.Add("content-disposition", "attachment;filename=" + "SalesReport" + System.DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx");
                Response.ContentType = "application/xlsx";
                Response.BinaryWrite(content);
                Response.Flush();
            }
        }
        [HttpPost]
        public JsonResult SaveExchangeDetails(List<JsonToList> Exchs)
        {
            string returnvf = string.Empty;
            try
            {
                List<JsonToList> TheJsonToList = new List<JsonToList>();
                int Salecntr = 1;
                DataTable dt = new DataTable();
                DataRow MovnoDr = default(DataRow);
                DataColumn saleid = new DataColumn("saleid", Type.GetType("System.String"));

                dt.Columns.Add("saleid");

                foreach (JsonToList Item in Exchs)
                {
                    Salecntr++;
                    MovnoDr = dt.NewRow();
                    MovnoDr["saleid"] = Item.saleid;
                    dt.Rows.Add(MovnoDr);
                }
                string ExchDetails = Common.GetSTRXMLResult(dt);
                returnvf = SaleManagement.GetInstance.InsertExchangeData(ExchDetails);
                return Json(returnvf);
            }
            catch (Exception Ex)
            {
                return Json("Failed ..");
            }
        }
        [HttpGet]
        public JsonResult GetOfferDetailsByCouponCode(string couponcode)
        {
            DataTable dt = SaleManagement.GetInstance.GetOfferDetailsByCouponCode(couponcode);
            CouponCode CouponDetails = new CouponCode();
            CouponDetails = (from DataRow dr in dt.Rows
                        select new CouponCode()
                        {
                            couponid= Convert.ToInt32(dr["couponid"]),
                            uptobillprice = Convert.ToDecimal(dr["uptobillprice"]),
                            offerinper = Convert.ToDecimal(dr["offerinper"]),
                            validfrom = Convert.ToDateTime(dr["validfrom"]),
                            validto = Convert.ToDateTime(dr["validto"]),
                            isredeemed = Convert.ToBoolean(dr["isredeemed"]),
                        }).FirstOrDefault();
            return Json(CouponDetails, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult latestexchbiinoselectproduct(string invoice, string mobileno) 
        {
            DataTable dt = SaleManagement.GetInstance.latestbiinoselectproduct(invoice, mobileno);
            List<Sale> SaleList = new List<Sale>();
            SaleList = (from DataRow dr in dt.Rows
                        select new Sale()
                        {
                            prodname = dr["prodname"].ToString(),
                            sizename = dr["sizename"].ToString(),
                            quanity = Convert.ToInt32(dr["quanity"]),
                            unitprice = Convert.ToDecimal(dr["unitprice"]),
                            discountper = Convert.ToDecimal(dr["discountper"]),
                            finalprice = Convert.ToDecimal(dr["finalprice"]),
                            billno = dr["billno"].ToString(),
                            addon = Convert.ToDateTime(dr["addon"]).ToString("dd-MMM-yy")
                        }).ToList();
            return Json(SaleList, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region Export to excel ProfitAndLossReport
        public ActionResult ExportProfitAndLossReport()
        {
            DataTable dt = SaleManagement.GetInstance.GetProfitAndLossDetails();
            List<ReceivedProduct> ProfitAndLossDetails = new List<ReceivedProduct>();
            ProfitAndLossDetails = (from DataRow dr in dt.Rows
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
            ExportProfitAndLossReport(ProfitAndLossDetails);
            return null;
        }
        private void ExportProfitAndLossReport(List<ReceivedProduct> data)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("ProfitAndLossReport" + System.DateTime.Now.ToString("dd-MM-yyyy"));
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Sale Date";
                worksheet.Cell(currentRow, 2).Value = "Barcode";
                worksheet.Cell(currentRow, 3).Value = "Product";
                worksheet.Cell(currentRow, 4).Value = "Category";
                worksheet.Cell(currentRow, 5).Value = "Brand";
                worksheet.Cell(currentRow, 6).Value = "Size";
                worksheet.Cell(currentRow, 7).Value = "Sale Price";
                worksheet.Cell(currentRow, 8).Value = "Purchase Price";
                worksheet.Cell(currentRow, 9).Value = "Profit Price";
                worksheet.Cell(currentRow, 10).Value = "Loss Price";

                foreach (ReceivedProduct val in data)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = val.saledate;
                    worksheet.Cell(currentRow, 2).Value = "'" + val.barcode;
                    worksheet.Cell(currentRow, 3).Value = val.prodname;
                    worksheet.Cell(currentRow, 4).Value = val.catname;
                    worksheet.Cell(currentRow, 5).Value = val.brandname;
                    worksheet.Cell(currentRow, 6).Value = val.sizename;
                    worksheet.Cell(currentRow, 7).Value = val.saleprice;
                    worksheet.Cell(currentRow, 8).Value = val.purchprice;
                    worksheet.Cell(currentRow, 9).Value = val.profitprice;
                    if (val.lossprice > 0)
                    {
                        worksheet.Cell(currentRow, 10).Style.Fill.BackgroundColor = XLColor.Red;

                    }
                    worksheet.Cell(currentRow, 10).Value = val.lossprice;
                }
                var stream = new MemoryStream();
                workbook.SaveAs(stream);
                var content = stream.ToArray();
                Response.Clear();
                Response.Headers.Add("content-disposition", "attachment;filename=" + "ProfitAndLossReport" + System.DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx");
                Response.ContentType = "application/xlsx";
                Response.BinaryWrite(content);
                Response.Flush();
            }
        }
        #endregion
    }
}
