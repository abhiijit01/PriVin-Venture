using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Runtime.Serialization;
using System.IO;
using System.Text;
using iTextSharp.text.pdf;
using ClosedXML.Excel;

namespace BRANDEXCL.Areas.Outlet.Controllers
{
    public class ReceivedProductController : Controller
    {

        #region Decalration
        [DataContract]
        public class JsonToList
        {
            [DataMember]
            public int purchid { get; set; }
            [DataMember]
            public int outid { get; set; }
            [DataMember]
            public string outcode { get; set; }

            [DataMember]
            public string outletname { get; set; }
            [DataMember]
            public string invoiceno { get; set; }
            [DataMember]
            public string itemcode { get; set; }
            [DataMember]

            public DateTime purcdate { get; set; }
            [DataMember]
            public string barcode { get; set; }
            [DataMember]
            public string prodcode { get; set; }
            [DataMember]
            public string prodname { get; set; }
            [DataMember]
            public int qty { get; set; }
            [DataMember]
            public decimal unitprice { get; set; }
            [DataMember]

            public decimal totalprice { get; set; }
            [DataMember]
            public decimal gst { get; set; }
            [DataMember]
            public int catid { get; set; }
            [DataMember]
            public int brandid { get; set; }
            [DataMember]
            public int colourid { get; set; }
            [DataMember]
            public int sizeid { get; set; }
            [DataMember]
            public string descr { get; set; }
        }
        int ReturnValue = 0;
        // GET: Outlet/ReceivedProduct
        public ActionResult ReceivedProductIndex()
        {
            return View();
        }
        public ActionResult ReceivedProductFinalIndex()
        {
            return View();
        }
        public ActionResult EditReceivedProduct()
        {
            return View();
        }
        #endregion

        #region Methods and Implimentations
        [HttpPost]
        public JsonResult UpdatReceivedeqty(string barcode, int sizeid, int qty)
        {
            int RetVal = 0;
            RetVal = BLL.ReceivedProductManagement.GetInstance.UpdateReceivedProductqty(barcode, sizeid, qty);
            return Json(RetVal, JsonRequestBehavior.AllowGet);
        }
        public JsonResult BarcodeSelectByBarcode(string barcode, int? sizeid)
        {
            DataTable dt = new DataTable();
            dt = BLL.BarcodeManagement.GetInstance.BarcodeSelectByBarcode(barcode, sizeid);
            List<ReceivedProduct> ProductRecieveList = new List<ReceivedProduct>();
            ProductRecieveList = (from DataRow dr in dt.Rows
                                  select new ReceivedProduct()
                                  {
                                      purchid = Convert.ToInt32(dr["purchid"]),
                                      outid = Convert.ToInt32(dr["purchid"]),
                                      outcode = dr["outcode"].ToString(),
                                      countcode = dr["countcode"].ToString(),
                                      invoiceno = dr["invoiceno"].ToString(),
                                      purcdate = Convert.ToDateTime(dr["purcdate"]),
                                      barcode = dr["barcode"].ToString(),
                                      prodcode = dr["prodcode"].ToString(),
                                      prodname = dr["prodname"].ToString(),
                                      catid = Convert.ToInt32(dr["catid"]),
                                      catname = dr["catname"].ToString(),
                                      brandid = Convert.ToInt32(dr["brandid"]),
                                      brandname = dr["brandname"].ToString(),
                                      sizeid = Convert.ToInt32(dr["sizeid"]),
                                      sizename = dr["sizename"].ToString(),
                                      qty = Convert.ToInt32(dr["qty"]),
                                      unitprice = Convert.ToDecimal(dr["unitprice"]),
                                      gst = Convert.ToDecimal(dr["gst"]),
                                      proddescr = dr["proddescr"].ToString(),
                                      refundstatus = Convert.ToBoolean(dr["refundstatus"])
                                  }).ToList();
            return Json(ProductRecieveList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult StoreReceivedProducts(List<JsonToList> products, string inOrUp)
        {
            try
            {
                if (inOrUp == "1")
                {
                    List<JsonToList> TheJsonToList = new List<JsonToList>();

                    int ItemCounter = 0;
                    DataTable dt = new DataTable();
                    DataRow drMovnodr = default(DataRow);

                    //  DataColumn purchid = new DataColumn("purchid", Type.GetType("System.String"));
                    DataColumn outid = new DataColumn("outid", Type.GetType("System.String"));
                    DataColumn outcode = new DataColumn("outcode", Type.GetType("System.String"));
                    DataColumn purcdate = new DataColumn("purcdate", Type.GetType("System.String"));
                    DataColumn barcode = new DataColumn("barcode", Type.GetType("System.String"));
                    DataColumn prodname = new DataColumn("prodname", Type.GetType("System.String"));
                    DataColumn qty = new DataColumn("qty", Type.GetType("System.String"));
                    DataColumn unitprice = new DataColumn("unitprice", Type.GetType("System.String"));
                    DataColumn totalprice = new DataColumn("totalprice", Type.GetType("System.String"));
                    DataColumn gst = new DataColumn("gst", Type.GetType("System.String"));
                    DataColumn catid = new DataColumn("catid", Type.GetType("System.String"));
                    DataColumn brandid = new DataColumn("brandid", Type.GetType("System.String"));
                    DataColumn colourid = new DataColumn("colourid", Type.GetType("System.String"));
                    DataColumn sizeid = new DataColumn("sizeid", Type.GetType("System.String"));
                    DataColumn descr = new DataColumn("descr", Type.GetType("System.String"));

                    dt.Columns.Add("outid");
                    dt.Columns.Add("outcode");
                    dt.Columns.Add("purcdate");
                    dt.Columns.Add("barcode");
                    dt.Columns.Add("prodname");
                    dt.Columns.Add("qty");
                    dt.Columns.Add("unitprice");
                    dt.Columns.Add("totalprice");
                    dt.Columns.Add("gst");
                    dt.Columns.Add("catid");
                    dt.Columns.Add("brandid");
                    dt.Columns.Add("colourid");
                    dt.Columns.Add("sizeid");
                    dt.Columns.Add("descr");

                    foreach (JsonToList Item in products)
                    {
                        ItemCounter++;
                        drMovnodr = dt.NewRow();
                        drMovnodr["outid"] = Item.outid;
                        drMovnodr["outcode"] = Item.outcode;
                        drMovnodr["purcdate"] = Item.purcdate.ToString("yyyy-MM-dd");
                        //DateTime.Now.ToString("yyyy-MM-dd");
                        drMovnodr["barcode"] = Item.barcode;
                        drMovnodr["prodname"] = Item.prodname;
                        drMovnodr["qty"] = 1;
                        drMovnodr["unitprice"] = Item.unitprice;
                        drMovnodr["totalprice"] = Item.totalprice;
                        drMovnodr["gst"] = Item.gst;
                        drMovnodr["catid"] = Item.catid;
                        drMovnodr["brandid"] = Item.brandid;
                        drMovnodr["colourid"] = Item.colourid;
                        drMovnodr["sizeid"] = Item.sizeid;
                        drMovnodr["descr"] = Item.descr;
                        dt.Rows.Add(drMovnodr);
                    }


                    string purchases = Common.GetSTRXMLResult(dt);
                    ReturnValue = ReceivedProductManagement.GetInstance.InsertReceivedProduct(purchases);

                }
                else
                {
                }
                if (ReturnValue >= 1)
                {
                    return Json("Purchase Entered successfully.");
                }
                else if (ReturnValue == -1)
                {
                    return Json("Purchase alraedy Exist.");
                }
                else if (ReturnValue == -2)
                {
                    return Json("Please add Valid value.");
                }
                else
                {
                    return Json("Invalid values to add.");
                }
            }
            catch (Exception ex)
            {
                return Json("Failed to add Purchase detail.");
            }
        }
        [HttpGet]
        public JsonResult GetAllReceivedProducts(string sidx, string sord, int page, int rows,
                    bool _search, string searchField, string searchOper, string searchString
                    )
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            sord = (sord == null) ? "" : sord;
            DataTable dt = ReceivedProductManagement.GetInstance.GetAllReceivedProducts();
            try
            {
                List<ReceivedProduct> ProductRecieveList = new List<ReceivedProduct>();
                ProductRecieveList = (from DataRow dr in dt.Rows
                                      select new ReceivedProduct()
                                      {
                                          outcode = dr["outcode"].ToString(),
                                          purcdate = Convert.ToDateTime(dr["purcdate"]),
                                          catid = Convert.ToInt32(dr["catid"]),
                                          catname = dr["catname"].ToString(),
                                          brandid = Convert.ToInt32(dr["brandid"]),
                                          brandname = dr["brandname"].ToString(),
                                          sizeid = Convert.ToInt32(dr["sizeid"]),
                                          sizename = dr["sizename"].ToString(),
                                          qty = Convert.ToInt32(dr["qty"]),
                                          qtysold = Convert.ToInt32(dr["qtysold"]),
                                          qtyavailable = Convert.ToInt32(dr["qtyavailable"]),
                                      }).ToList();
                switch (searchField)
                {
                    case "purcdate":
                        ProductRecieveList = ProductRecieveList.Where(t => t.purcdate == Convert.ToDateTime(searchString)).ToList();
                        break;
                    case "catname":
                        ProductRecieveList = ProductRecieveList.Where(t => t.catname.Contains(searchString)).ToList();
                        break;

                    case "brandname":
                        ProductRecieveList = ProductRecieveList.Where(t => t.brandname.Contains(searchString)).ToList();
                        break;

                    case "invoiceno":
                        ProductRecieveList = ProductRecieveList.Where(t => t.invoiceno.Contains(searchString)).ToList();
                        break;
                    case "sizename":
                        ProductRecieveList = ProductRecieveList.Where(t => t.sizename.Contains(searchString)).ToList();
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
        [HttpPost]
        public JsonResult UpdateReceivedProduct(ReceivedProduct theUser)
        {
            try
            {
                ReturnValue = BLL.ReceivedProductManagement.GetInstance.UpdateReceivedProduct(theUser);

                if (ReturnValue >= 1)
                {
                    return Json("User Created Successfully.");
                }
                else if (ReturnValue == -1)
                {
                    return Json("User Already Exists.");
                }
                else if (ReturnValue == -2)
                {
                    return Json("Failed to add User.");
                }
                else
                {
                    return Json("No Record Found for Add User");
                }

            }
            catch
            {
                return Json("Products Puchase entry Failed");
            }
        }
        [HttpPost]
        public JsonResult DeleteReceivedProduct(string Id)
        {
            int[] nums = Array.ConvertAll(Id.Split(','), int.Parse);
            DataTable dt = new DataTable();
            dt.Columns.Add("purcid");
            foreach (int s in nums)
            {
                dt.Rows.Add(s);
            }
            string purchid = Common.GetSTRXMLResult(dt);
            try
            {
                DataTable data = ReceivedProductManagement.GetInstance.DeleteReceivedProduct(purchid);
                return Json("Deleted Successfully");
            }
            catch
            {
                return Json("Could not find any Data to Delete");
            }
        }
        public ActionResult GenerateBarCodes()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GenerateBarCodes(string barcode)
        {
            Barcode128 code128 = new Barcode128();
            code128.CodeType = Barcode.CODE128;
            code128.ChecksumText = true;
            code128.GenerateChecksum = true;
            code128.StartStopText = true;
            code128.Code = barcode;
            code128.Size = 1F;
            System.Drawing.Bitmap bm = new System.Drawing.Bitmap(code128.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White));
            using (MemoryStream memoryStream = new MemoryStream())
            {
                bm.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                ViewBag.BarcodeImage = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
            }
            return View();
        }
        public ActionResult GenerateBarCodeAndGetBarcode()
        {
            var RndBarcode = generateBarcode();
            Barcode128 code128 = new Barcode128();
            code128.CodeType = Barcode.CODE128;
            code128.ChecksumText = true;
            code128.GenerateChecksum = true;
            code128.StartStopText = true;
            code128.Code = RndBarcode;
            code128.Size = 1F;
            System.Drawing.Bitmap bm = new System.Drawing.Bitmap(code128.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White));
            using (MemoryStream memoryStream = new MemoryStream())
            {
                bm.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return Json(new { Barcode = RndBarcode, BarcodeImage = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray()) }, JsonRequestBehavior.AllowGet);
            }
        }
        public string generateBarcode()
        {
            string RandomNum = "";
            StringBuilder randomText = new StringBuilder();
            string Number = "1234567890";
            Random r = new Random();
            for (int j = 1; j <= 12; j++)
            {
                //generating the random code
                randomText.Append(Number[r.Next(Number.Length)]);
            }
            RandomNum = randomText.ToString();
            return RandomNum;
        }
        #endregion
        #region Export to excel StockReport
        public ActionResult ExportStockReport()
        {
            DataTable dt = ReceivedProductManagement.GetInstance.GetAllReceivedProducts();
            List<ReceivedProduct> StockDetails = new List<ReceivedProduct>();
            StockDetails = (from DataRow dr in dt.Rows
                            select new ReceivedProduct()
                            {
                                outcode = dr["outcode"].ToString(),
                                purcdate = Convert.ToDateTime(dr["purcdate"]),
                                catid = Convert.ToInt32(dr["catid"]),
                                catname = dr["catname"].ToString(),
                                brandid = Convert.ToInt32(dr["brandid"]),
                                brandname = dr["brandname"].ToString(),
                                sizeid = Convert.ToInt32(dr["sizeid"]),
                                sizename = dr["sizename"].ToString(),
                                qty = Convert.ToInt32(dr["qty"]),
                                qtysold = Convert.ToInt32(dr["qtysold"]),
                                qtyavailable = Convert.ToInt32(dr["qtyavailable"]),
                            }).ToList();
            ExportStockReport(StockDetails);
            return null;
        }
        private void ExportStockReport(List<ReceivedProduct> data)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("StockReport" + System.DateTime.Now.ToString("dd-MM-yyyy"));
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Date";
                worksheet.Cell(currentRow, 2).Value = "Category";
                worksheet.Cell(currentRow, 3).Value = "Brand";
                worksheet.Cell(currentRow, 4).Value = "Size";
                worksheet.Cell(currentRow, 5).Value = "Quantity";
                worksheet.Cell(currentRow, 6).Value = "Quantity Sold";
                worksheet.Cell(currentRow, 7).Value = "AvailableQuantity";

                foreach (ReceivedProduct val in data)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = val.purcdate;
                    worksheet.Cell(currentRow, 2).Value = val.catname;
                    worksheet.Cell(currentRow, 3).Value = val.brandname;
                    worksheet.Cell(currentRow, 4).Value = val.sizename;
                    worksheet.Cell(currentRow, 5).Value = val.qty;
                    worksheet.Cell(currentRow, 6).Value = val.qtysold;
                    if (val.qtyavailable <= 5)
                    {
                        worksheet.Cell(currentRow, 7).Style.Fill.BackgroundColor = XLColor.Red;

                    }
                    worksheet.Cell(currentRow, 7).Value = val.qtyavailable;
                }
                var stream = new MemoryStream();
                workbook.SaveAs(stream);
                var content = stream.ToArray();
                Response.Clear();
                Response.Headers.Add("content-disposition", "attachment;filename=" + "StockReport" + System.DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx");
                Response.ContentType = "application/xlsx";
                Response.BinaryWrite(content);
                Response.Flush();
            }
        }
        #endregion
    }
}