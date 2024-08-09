using BLL;
using BOL;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Http;

namespace BRANDEXCL.Areas.Inventory.Controllers
{
    public class MailerController : ApiController
    {
        // GET: Inventory/Mailer
        public IHttpActionResult SendDailySalesReport()
        {
            DateTime today = System.DateTime.Now;
            try
            {
                //DataTable dt = SaleManagement.GetInstance.SaleReportSelectByDate(today, today);
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
                                      }).ToList();
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("SalesReport" + System.DateTime.Now.ToString("dd-MM-yyyy"));
                    var currentRow = 1;
                    worksheet.Cell(currentRow, 1).Value = "Invoice No";
                    worksheet.Cell(currentRow, 2).Value = "Date";
                    worksheet.Cell(currentRow, 3).Value = "Barcode";
                    worksheet.Cell(currentRow, 4).Value = "Product";
                    worksheet.Cell(currentRow, 5).Value = "Category";
                    worksheet.Cell(currentRow, 6).Value = "Brand";
                    worksheet.Cell(currentRow, 7).Value = "Size";
                    worksheet.Cell(currentRow, 8).Value = "MRP";
                    worksheet.Cell(currentRow, 9).Value = "Quantity";
                    worksheet.Cell(currentRow, 10).Value = "Discount";
                    worksheet.Cell(currentRow, 11).Value = "Discounted Amount";
                    worksheet.Cell(currentRow, 12).Value = "GST";
                    worksheet.Cell(currentRow, 13).Value = "GST Amount";
                    worksheet.Cell(currentRow, 14).Value = "Final Price";
                    worksheet.Cell(currentRow, 15).Value = "Payment Mode";

                    foreach (ReceivedProduct val in ProductRecieveList)
                    {
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = val.invoiceno;
                        worksheet.Cell(currentRow, 2).Value = val.purcdate;
                        worksheet.Cell(currentRow, 3).Value = "'" + val.barcode;
                        worksheet.Cell(currentRow, 4).Value = val.prodname;
                        worksheet.Cell(currentRow, 5).Value = val.catname;
                        worksheet.Cell(currentRow, 6).Value = val.brandname;
                        worksheet.Cell(currentRow, 7).Value = val.sizename;
                        worksheet.Cell(currentRow, 8).Value = val.unitprice;
                        worksheet.Cell(currentRow, 9).Value = val.qty;
                        worksheet.Cell(currentRow, 10).Value = val.discountper;
                        worksheet.Cell(currentRow, 11).Value = val.discountamount;
                        worksheet.Cell(currentRow, 12).Value = val.gst;
                        worksheet.Cell(currentRow, 13).Value = val.gstprice;
                        worksheet.Cell(currentRow, 14).Value = val.finalprice;
                        worksheet.Cell(currentRow, 15).Value = val.paymentmode;
                    }
                    string AppLocation = "";
                    AppLocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
                    AppLocation = AppLocation.Replace("file:\\", "");
                    string file = AppLocation + "\\ExcelFiles\\DailySaleReport.xlsx";
                    if (System.IO.File.Exists(file))
                    {
                        System.IO.File.Delete(file);
                    }
                    workbook.SaveAs(file);
                    workbook.Dispose();
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("info@brandexclusive.in");
                    mail.To.Add(new MailAddress("nabin4476.np@gmail.com")); // Sending MailTo 
                    mail.To.Add(new MailAddress("thebrand.768108@gmail.com")); // Sending MailTo  
                    mail.To.Add(new MailAddress("abi.sahu@gmail.com")); // Sending MailTo  
                    mail.Bcc.Add(new MailAddress("abhijitparida59@gmail.com")); // Sending MailBcc  
                    mail.Subject = "Daily Sales Report-" + System.DateTime.Now.ToString("dd/MM/yyyy"); // Mail Subject  
                    mail.Body = "Sales Report *This is an automatically generated email, please do not reply*";
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
                return Ok("1");
            }
            catch (Exception Ex)
            {
                return Ok("2");
            }
        }
        public IHttpActionResult SendDailyProfitLossReport()
        {
            DateTime today = System.DateTime.Now;
            //DataTable dt = SaleManagement.GetInstance.ProfitAndLossSelectByDate(today, today);
            try
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

                    foreach (ReceivedProduct val in ProfitAndLossDetails)
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
                    string AppLocation = "";
                    AppLocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
                    AppLocation = AppLocation.Replace("file:\\", "");
                    string file = AppLocation + "\\ExcelFiles\\DailyProfitLossReport.xlsx";
                    if (System.IO.File.Exists(file))
                    {
                        System.IO.File.Delete(file);
                    }
                    workbook.SaveAs(file);
                    workbook.Dispose();
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("info@brandexclusive.in");
                    mail.To.Add(new MailAddress("nabin4476.np@gmail.com")); // Sending MailTo 
                    mail.To.Add(new MailAddress("thebrand.768108@gmail.com")); // Sending MailTo  
                    mail.To.Add(new MailAddress("abi.sahu@gmail.com")); // Sending MailTo  
                    mail.Bcc.Add(new MailAddress("abhijitparida59@gmail.com")); // Sending MailBcc  
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
                return Ok("1");
            }
            catch
            {
                return Ok("2");
            }
        }
        public IHttpActionResult SendWeeklyStockReport()
        {
            var baseDate = DateTime.Today;
            var thisWeekStart = baseDate.AddDays(-(int)baseDate.DayOfWeek);
            var thisWeekEnd = thisWeekStart.AddDays(7).AddSeconds(-1);
            try
            {
                //if (storeno == 1)
                //{
                //    NewUser theUser = new NewUser();
                //    theUser.Usr_Nm = "nabin"; theUser.Pwd = "password";
                //    var result = new Outlet.Controllers.LoginController().LoginData(theUser);
                //}
                //else
                //{

                //}
                //DataTable dt = ReceivedProductManagement.GetInstance.GetAllReceivedProducts();
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

                    foreach (ReceivedProduct val in StockDetails)
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
                    string AppLocation = "";
                    AppLocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
                    AppLocation = AppLocation.Replace("file:\\", "");
                    string file = AppLocation + "\\ExcelFiles\\WeeklyStockReport.xlsx";
                    if (System.IO.File.Exists(file))
                    {
                        System.IO.File.Delete(file);
                    }
                    workbook.SaveAs(file);
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("info@brandexclusive.in");
                    mail.To.Add(new MailAddress("nabin4476.np@gmail.com")); // Sending MailTo 
                    mail.To.Add(new MailAddress("thebrand.768108@gmail.com")); // Sending MailTo  
                    mail.To.Add(new MailAddress("abi.sahu@gmail.com")); // Sending MailTo  
                    mail.Bcc.Add(new MailAddress("abhijitparida59@gmail.com")); // Sending MailBcc  
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
                return Ok("1");
            }
            catch
            {
                return Ok("2");
            }
        }
    }
}