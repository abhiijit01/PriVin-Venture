using BRANDEXCL.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace BRANDEXCL.Model
{
    public partial class Common
    {
        public static string GetSTRXMLResult(DataTable dtTable)
        {
            string strXMLResult = "";
            if (dtTable != null)
            {
                if (dtTable.Rows.Count > 0)
                {
                    StringWriter sw = new StringWriter();
                    dtTable.TableName = "MyTable";
                    dtTable.WriteXml(sw);
                    strXMLResult = sw.ToString();
                    sw.Close();
                    sw.Dispose();
                }
            }
            return strXMLResult;
        }

        public static string ReturnZeroIfNull(string val)
        {
            string ReturnValue = string.Empty;

            if (string.IsNullOrEmpty(val))
            {
                ReturnValue = "0";
            }
            else
            {
                ReturnValue = val;
            }

            return ReturnValue;
        }
        public static List<NewUser> LoggedInUser
        {
            get
            {
                var myfileAttachmentList = new List<NewUser>();             
                //myfileAttachmentList = (List<NewUser>)HttpContext.Current.Session["LoggedInUser"]; 
                return new List<NewUser>();
            }
            set
            {
                
                //HttpContext.Current.Session.Add("LoggedInUser", value);
            }
        }

      

    }


}