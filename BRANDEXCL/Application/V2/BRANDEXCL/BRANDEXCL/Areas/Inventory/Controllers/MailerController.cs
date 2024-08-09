using BRANDEXCL.Business;
using BRANDEXCL.Model;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace BRANDEXCL.Areas.Inventory.Controllers
{
    public class MailerController : Controller
    {
        // GET: Inventory/Mailer
        public ActionResult SendDailySalesReport()
        {
            DateTime today = System.DateTime.Now;
            try
            {
                DataTable dt = SaleManagement.GetInstance.SaleReportSelectByDate(today, today);
                List<SaleReport> ProductSalesList = new List<SaleReport>();
                ProductSalesList = (from DataRow dr in dt.Rows
                                      select new SaleReport()
                                      {
                                          saleid = Convert.ToInt32(dr["saleid"]),
                                          invoicedate = Convert.ToDateTime(dr["invoicedate"]),
                                          invoiceno = dr["invoiceno"].ToString(),
                                          barcode = dr["barcode"].ToString(),
                                          prodname = dr["prodname"].ToString(),
                                          descr = dr["descr"].ToString(),
                                          catname = dr["catname"].ToString(),
                                          brandname = dr["brandname"].ToString(),
                                          sizename = dr["sizename"].ToString(),
                                          qty = Convert.ToInt32(dr["qty"]),
                                          priceexgst = Convert.ToDecimal(dr["priceexgst"]),
                                          gst = Convert.ToDecimal(dr["gst"]),
                                          unitprice = Convert.ToDecimal(dr["unitprice"]),
                                          discount = Convert.ToDecimal(dr["discount"]),
                                          finalprice = Convert.ToDecimal(dr["finalprice"]),
                                          paymentmode = dr["paymentmode"].ToString()
                                      }).ToList();
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("DailySaleReport");
                    var currentRow = 1;
                    worksheet.Cell(currentRow, 1).Value = "Invoice Date";
                    worksheet.Cell(currentRow, 2).Value = "Invoice No";
                    worksheet.Cell(currentRow, 3).Value = "Barcode";
                    worksheet.Cell(currentRow, 4).Value = "Product Name";
                    worksheet.Cell(currentRow, 5).Value = "Description";
                    worksheet.Cell(currentRow, 6).Value = "Category";
                    worksheet.Cell(currentRow, 7).Value = "Brand";
                    worksheet.Cell(currentRow, 8).Value = "Size";
                    worksheet.Cell(currentRow, 9).Value = "Quantity";
                    worksheet.Cell(currentRow, 10).Value = "Price Excluding GST";
                    worksheet.Cell(currentRow, 11).Value = "GST";
                    worksheet.Cell(currentRow, 12).Value = "Unit Price";
                    worksheet.Cell(currentRow, 13).Value = "Discount";
                    worksheet.Cell(currentRow, 14).Value = "Final Price";
                    worksheet.Cell(currentRow, 15).Value = "Payment Mode";
                    foreach (SaleReport val in ProductSalesList)
                    {
                        {
                            currentRow++;
                            worksheet.Cell(currentRow, 1).Value = val.invoicedate;
                            worksheet.Cell(currentRow, 2).Value = val.invoiceno;
                            worksheet.Cell(currentRow, 3).Value = val.barcode;
                            worksheet.Cell(currentRow, 4).Value = val.prodname;
                            worksheet.Cell(currentRow, 5).Value = val.descr;
                            worksheet.Cell(currentRow, 6).Value = val.catname;
                            worksheet.Cell(currentRow, 7).Value = val.brandname;
                            worksheet.Cell(currentRow, 8).Value = val.sizename;
                            worksheet.Cell(currentRow, 9).Value = val.qty;
                            worksheet.Cell(currentRow, 10).Value = val.priceexgst;
                            worksheet.Cell(currentRow, 11).Value = val.gst;
                            worksheet.Cell(currentRow, 12).Value = val.unitprice;
                            worksheet.Cell(currentRow, 13).Value = val.discount;
                            worksheet.Cell(currentRow, 14).Value = val.finalprice;
                            worksheet.Cell(currentRow, 15).Value = val.paymentmode;
                        }
                    }
                    string AppLocation = "";
                    AppLocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
                    AppLocation = AppLocation.Replace("file:\\", "");
                    string file =  AppLocation + "\\ExcelFiles\\DailySaleReport.xlsx";
                    if (System.IO.File.Exists(file))
                    {
                        System.IO.File.Delete(file);
                    }
                    workbook.SaveAs(file);
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("info@brandexclusive.in");
                    mail.To.Add(new MailAddress("thebrand.768108@gmail.com")); // Sending MailTo  
                    mail.To.Add(new MailAddress("abhijitparida59@gmail.com")); // Sending MailTo  
                    mail.To.Add(new MailAddress("nabin4476.np@gmail.com")); // Sending MailTo  
                    mail.Subject = "Daily Sales Report-"+ System.DateTime.Now.ToString("dd/MM/yyyy"); // Mail Subject  
                    mail.Body = "Sales Report *This is an automatically generated email, please do not reply*";
                    System.Net.Mail.Attachment attachment;
                    attachment = new System.Net.Mail.Attachment(file); //Attaching File to Mail  
                    mail.Attachments.Add(attachment);
                    SmtpClient SmtpServer = new SmtpClient();
                    SmtpServer.Host="relay-hosting.secureserver.net";
                    SmtpServer.Port = 25; //PORT  
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = new NetworkCredential("info@brandexclusive.in", "thebrand@12345");
                    SmtpServer.Send(mail);
                }
                return Json("1");
            }
            catch
            {
                return Json("2");
            }
        }
        public ActionResult SendDailyProfitLossReport()
        {
            DateTime today = System.DateTime.Now;
            DataTable dt = SaleManagement.GetInstance.ProfitAndLossSelectByDate(today, today);
            try
            {
                List<ProfitAndLossReport> ProfitAndLoss = new List<ProfitAndLossReport>();
                ProfitAndLoss = (from DataRow dr in dt.Rows
                                      select new ProfitAndLossReport()
                                      {
                                          invoiceno = dr["invoiceno"].ToString(),
                                          barcode = dr["barcode"].ToString(),
                                          priceexgst = Convert.ToDecimal(dr["priceexgst"]),
                                          saleprice = Convert.ToDecimal(dr["saleprice"]),
                                          date = Convert.ToDateTime(dr["date"]),
                                          profitamount = Convert.ToDecimal(dr["profitamount"]),
                                          lossamount = Convert.ToDecimal(dr["lossamount"])
                                      }).ToList();
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("DailyProfitLossReport");
                    var currentRow = 1;
                    worksheet.Cell(currentRow, 1).Value = "Invoice No";
                    worksheet.Cell(currentRow, 2).Value = "Date";
                    worksheet.Cell(currentRow, 3).Value = "Barcode";
                    worksheet.Cell(currentRow, 4).Value = "Price Excluding GST";
                    worksheet.Cell(currentRow, 5).Value = "Sale Price";
                    worksheet.Cell(currentRow, 6).Value = "Profit Amount";
                    worksheet.Cell(currentRow, 7).Value = "Loss Amount";
                    foreach (ProfitAndLossReport val in ProfitAndLoss)
                    {
                        {
                            currentRow++;
                            worksheet.Cell(currentRow, 1).Value = val.invoiceno;
                            worksheet.Cell(currentRow, 2).Value = val.date;
                            worksheet.Cell(currentRow, 3).Value = val.barcode;
                            worksheet.Cell(currentRow, 4).Value = val.priceexgst;
                            worksheet.Cell(currentRow, 5).Value = val.saleprice;
                            worksheet.Cell(currentRow, 6).Value = val.profitamount;
                            worksheet.Cell(currentRow, 7).Value = val.lossamount;
                        }
                    }
                    string AppLocation = "";
                    AppLocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
                    AppLocation = AppLocation.Replace("file:\\", "");
                    string file = AppLocation + "\\ExcelFiles\\DailyProfitLossReport.xlsx";
                    if (System.IO.File.Exists(file))
                    {
                        System.IO.File.Delete(file);
                    }
                    workbook.SaveAs(file);
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("info@brandexclusive.in");
                    mail.To.Add(new MailAddress("thebrand.768108@gmail.com")); // Sending MailTo  
                    mail.To.Add(new MailAddress("abhijitparida59@gmail.com")); // Sending MailTo  
                    mail.To.Add(new MailAddress("nabin4476.np@gmail.com")); // Sending MailTo  
                    mail.Subject = "Daily Profit And Loss Report-" + System.DateTime.Now.ToString("dd/MM/yyyy"); // Mail Subject  
                    mail.Body = "Daily Profit And Loss Report *This is an automatically generated email, please do not reply*";
                    System.Net.Mail.Attachment attachment;
                    attachment = new System.Net.Mail.Attachment(file); //Attaching File to Mail  
                    mail.Attachments.Add(attachment);
                    SmtpClient SmtpServer = new SmtpClient();
                    SmtpServer.Host = "relay-hosting.secureserver.net";
                    SmtpServer.Port = 25; //PORT  
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = new NetworkCredential("info@brandexclusive.in", "thebrand@12345");
                    SmtpServer.Send(mail);
                }
                return Json("1");
            }
            catch
            {
                return Json("2");
            }
        }
        public ActionResult SendWeeklyStockReport()
        {
            var baseDate = DateTime.Today;
            var thisWeekStart = baseDate.AddDays(-(int)baseDate.DayOfWeek);
            var thisWeekEnd = thisWeekStart.AddDays(7).AddSeconds(-1);
            try
            {
                DataTable dt = ReceivedProductManagement.GetInstance.GetAllReceivedProducts();
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
                                          qtysold = Convert.ToInt32(dr["qtysold"]),
                                          qtyavailable = Convert.ToInt32(dr["qtyavailable"]),
                                          unitprice = Convert.ToDecimal(dr["unitprice"]),
                                          priceexgst = Convert.ToDecimal(dr["priceexgst"]),
                                          purchprice = Convert.ToDecimal(dr["purchprice"]),
                                          gst = Convert.ToDecimal(dr["gst"]),
                                          proddescr = dr["proddescr"].ToString(),
                                          refundstatus = Convert.ToBoolean(dr["refundstatus"])
                                      }).ToList();
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("WeeklyStockReport");
                    var currentRow = 1;
                    worksheet.Cell(currentRow, 1).Value = "Store Code";
                    worksheet.Cell(currentRow, 2).Value = "Invoice No";
                    worksheet.Cell(currentRow, 3).Value = "Purchase Date";
                    worksheet.Cell(currentRow, 4).Value = "Barcode";
                    worksheet.Cell(currentRow, 5).Value = "Product Code";
                    worksheet.Cell(currentRow, 6).Value = "Product Name";
                    worksheet.Cell(currentRow, 7).Value = "Category";
                    worksheet.Cell(currentRow, 8).Value = "Brand";
                    worksheet.Cell(currentRow, 9).Value = "Size";
                    worksheet.Cell(currentRow, 10).Value = "Total Received Quantity";
                    worksheet.Cell(currentRow, 11).Value = "Quantity Sold";
                    worksheet.Cell(currentRow, 12).Value = "Quantity Available";
                    worksheet.Cell(currentRow, 13).Value = "Unit Price";
                    worksheet.Cell(currentRow, 14).Value = "Price Excluding GST";
                    worksheet.Cell(currentRow, 15).Value = "GST";
                    worksheet.Cell(currentRow, 16).Value = "Purchase Price";
                    foreach (ReceivedProduct val in ProductRecieveList)
                    {
                        {
                            currentRow++;
                            worksheet.Cell(currentRow, 1).Value = val.outcode;
                            worksheet.Cell(currentRow, 2).Value = val.invoiceno;
                            worksheet.Cell(currentRow, 3).Value = val.purcdate;
                            worksheet.Cell(currentRow, 4).Value = val.barcode;
                            worksheet.Cell(currentRow, 5).Value = val.prodcode;
                            worksheet.Cell(currentRow, 6).Value = val.prodname;
                            worksheet.Cell(currentRow, 7).Value = val.catname;
                            worksheet.Cell(currentRow, 8).Value = val.brandname;
                            worksheet.Cell(currentRow, 9).Value = val.sizename;
                            worksheet.Cell(currentRow, 10).Value = val.qty;
                            worksheet.Cell(currentRow, 11).Value = val.qtysold;
                            worksheet.Cell(currentRow, 12).Value = val.qtyavailable;
                            if(val.qtyavailable<=5)
                            {
                                worksheet.Cell(currentRow, 12).Style.Fill.BackgroundColor = XLColor.Red;

                            }
                            worksheet.Cell(currentRow, 13).Value = val.unitprice;
                            worksheet.Cell(currentRow, 14).Value = val.priceexgst;
                            worksheet.Cell(currentRow, 15).Value = val.gst;
                            worksheet.Cell(currentRow, 16).Value = val.purchprice;

                        }
                    }
                    string AppLocation = "";
                    AppLocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
                    AppLocation = AppLocation.Replace("file:\\", "");
                    string file = AppLocation + "\\ExcelFiles\\WeeklyStockReport.xlsx";
                    if(System.IO.File.Exists(file))
                    {
                        System.IO.File.Delete(file);
                    }
                    workbook.SaveAs(file);
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("info@brandexclusive.in");
                    mail.To.Add(new MailAddress("thebrand.768108@gmail.com")); // Sending MailTo  
                    mail.To.Add(new MailAddress("abhijitparida59@gmail.com")); // Sending MailTo  
                    mail.To.Add(new MailAddress("nabin4476.np@gmail.com")); // Sending MailTo  
                    mail.Subject = "Weekly Stocks Report-" + System.DateTime.Now.ToString("dd/MM/yyyy"); // Mail Subject  
                    mail.Body = "Weekly Stocks Report *This is an automatically generated email, please do not reply*";
                    System.Net.Mail.Attachment attachment;
                    attachment = new System.Net.Mail.Attachment(file); //Attaching File to Mail  
                    mail.Attachments.Add(attachment);
                    SmtpClient SmtpServer = new SmtpClient();
                    SmtpServer.Host = "relay-hosting.secureserver.net";
                    SmtpServer.Port = 25; //PORT  
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = new NetworkCredential("info@brandexclusive.in", "thebrand@12345");
                    SmtpServer.Send(mail);
                }
                return Json("1");
            }
            catch
            {
                return Json("2");
            }
        }
    }
}