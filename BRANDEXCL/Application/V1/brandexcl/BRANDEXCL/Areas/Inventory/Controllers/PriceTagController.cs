using BOL;
using ExcelDataReader;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BRANDEXCL.Areas.Inventory.Controllers
{
    public class PriceTagController : Controller
    {
        // GET: Inventory/PriceTag
        public ActionResult GeneratePriceTag()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> ImportFile(HttpPostedFileBase importFile)
        {
            if (importFile == null) return Json(new { Status = 0, Message = "No File Selected" });

            try
            {
                string filePath = string.Empty;
                string path = Server.MapPath("~/ExcelFiles/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                filePath = path + Path.GetFileName(importFile.FileName);
                string extension = Path.GetExtension(importFile.FileName);
                if (!System.IO.File.Exists(filePath))
                {
                    importFile.SaveAs(filePath);
                }
                else
                {

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                    importFile.SaveAs(filePath);
                }
                var fileData = GetList(filePath);
                foreach (var data in fileData)
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
                        data.BarcodeImage = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
                        data.RndBarcode = RndBarcode;
                    }
                }
                return Json(fileData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Status = 0, Message = ex.Message });
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
        private List<PriceTag> GetList(string path)
        {
            var empList = new List<PriceTag>();
            try
            {
                DataTable dataTable = GetDataTableFromExcel(path);
                foreach (DataRow objDataRow in dataTable.Rows)
                {
                    if (objDataRow.ItemArray.All(x => string.IsNullOrEmpty(x?.ToString()))) continue;
                    empList.Add(new PriceTag()
                    {
                        Brand = objDataRow["Brand"].ToString(),
                        Product = objDataRow["Product"].ToString(),
                        PackedOn = objDataRow["PackedOn"].ToString(),
                        Style = objDataRow["Style"].ToString(),
                        ChestSize = objDataRow["ChestSize"].ToString(),
                        NetQuantity = objDataRow["NetQuantity"].ToString(),
                        MRP = objDataRow["MRP"].ToString(),
                        ManufacteredOn = objDataRow["ManufacteredOn"].ToString(),
                        StyleCode = objDataRow["StyleCode"].ToString(),
                        ArticleNo = objDataRow["ArticleNo"].ToString(),
                        ArticleName = objDataRow["ArticleName"].ToString(),
                        Color = objDataRow["Color"].ToString(),
                        Size = objDataRow["Size"].ToString(),
                        WaistSize = objDataRow["WaistSize"].ToString(),
                        InseamLength = objDataRow["InseamLength"].ToString(),
                        OtherDetails = objDataRow["OtherDetails"].ToString(),
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            return empList;
        }
        private static DataTable GetDataTableFromExcel(string inputFilePath, bool hasHeader = true)
        {
            try
            {
                //System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                var stream = System.IO.File.Open(inputFilePath, FileMode.Open, FileAccess.Read);
                IExcelDataReader reader;

                if (inputFilePath.EndsWith(".xls"))
                    reader = ExcelReaderFactory.CreateBinaryReader(stream);
                else if (inputFilePath.EndsWith(".xlsx"))
                    reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                else
                    throw new Exception("The file to be processed is not an Excel file");
                var conf = new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                };
                var dataSet = reader.AsDataSet(conf);

                // Now you can get data from each sheet by its index or its "name"
                var dataTable = dataSet.Tables[0];
                return dataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}