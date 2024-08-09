using BRANDEXCL.Business;
using BRANDEXCL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace BRANDEXCL.Areas.Outlet.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        //int ReturnValue = 0;
        protected static class PageVariables
        {
            public static NewUser ThisUser
            {
                get
                {
                    //NewUser TheUser = System.Web.HttpContext.Current.Session["ThisUser"] as NewUser;
                    return new NewUser();
                }
                set
                {
                    //System.Web.HttpContext.Current.Session.Add("ThisUser", value);
                }
            }
        }
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult LoginData([FromBody]NewUser theUser)
        {
            try
            {
                DataTable dddttt = new DataTable();
                dddttt = BRANDEXCL.Business.NewUserBs.GetInstance.CheckUserExist(theUser);
                List<NewUser> Userlist = new List<NewUser>();
                int usridas = Convert.ToInt32(dddttt.Rows[0]["Usr_Id"]);
               // Session["userid"] = usridas;

                if (dddttt.Rows.Count == 1)
                {

                    Userlist = (from DataRow dr in dddttt.Rows
                                select new NewUser()
                                {
                                    Usr_Id = Convert.ToInt32(dr["Usr_Id"]),
                                    Usr_Nm = dr["Usr_Nm"].ToString(),
                                    RoleDesc = dr["RoleDesc"].ToString(),
                                    RoleID = Convert.ToInt32(dr["RoleID"]),
                                    Desg_ID = Convert.ToInt32(dr["Desg_ID"]),
                                    Designation_Name = dr["Designation_Name"].ToString(),
                                    countid = Convert.ToInt32(dr["countid"]),
                                    countername = dr["countnm"].ToString(),
                                    outid = Convert.ToInt32(dr["outid"]),
                                    outletname = dr["outnm"].ToString(),
                                    Name = dr["Name"].ToString(),
                                    EmpCode = dr["EmpCode"].ToString(),
                                    Email = dr["Email"].ToString(),
                                    Phone = dr["Phone"].ToString(),
                                    outcode = dr["outcode"].ToString()
                                }).ToList();

                    //Session["LoggedInUser"] = Userlist;
                    PageVariables.ThisUser = Userlist.FirstOrDefault();
                    return Json("User Exists");
                }
                else
                {
                    return Json("User Doesnot Exists.");
                }
            }
            catch (Exception Ex)
            {
                return Json("Password is incorrect");
            }

        }
        public ActionResult QueryExecuter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult QueryExecuter(QueryBuilderModel objQuerybuilder)
        {
            bool IsDML = false;
            string strQuery = objQuerybuilder.QueryText;
            string password = objQuerybuilder.DMLCode;

            if (strQuery == "" || strQuery == null)
            {
                ViewBag.showmessage = "Query Textbox can not be left blank!!!";
                return View();
            }
            else if (password == "" || password == null)
            {
                ViewBag.showmessage = "Please enter Password!";
                return View();
            }
            else if (password != "1999")
            {
                ViewBag.showmessage = "Please enter valid Password!";
                return View();
            }
            else
            {
                if (!IsValidQuery(strQuery, objQuerybuilder.DMLCode))
                {
                    ViewBag.showmessage = "You are not authorized to perform any operation.";
                    return View();
                }
                else
                {
                    try
                    {
                        DataTable dt = new DataTable();
                        dt = BRANDEXCL.Business.NewUserBs.GetInstance.GetQueryData(strQuery);


                        if (IsDML == true)
                        {
                            if (objQuerybuilder.DMLCode == null || objQuerybuilder.DMLCode == "")
                            {
                                ViewBag.showmessage = "You are not authorized to perform any operation.";
                                return View();
                            }

                            objQuerybuilder.QueryText = "";
                            ViewBag.showmessage = "Command executed successfully...";
                            return View();
                        }
                        else
                        {
                            DataTable dtData = dt;
                            return PartialView("_GetMyData", dtData);
                        }
                    }
                    catch (Exception ex)
                    {

                        ViewBag.showmessage = ex.Message;
                        return View();
                    }
                }
            }

        }
        private bool IsValidQuery(string queryOrg, string authority)
        {
            string query = queryOrg.TrimStart(new Char[] { '-' });
            bool IsDML = false;
            if (query.ToLower().StartsWith("update ") ||
                query.ToLower().StartsWith("insert ") ||
                query.ToLower().StartsWith("create ") ||
                query.ToLower().StartsWith("alter ") ||
                query.ToLower().StartsWith("delete ") ||
                query.ToLower().StartsWith("truncate ") ||
                query.ToLower().StartsWith("drop ") ||
                query.ToLower().Contains("procedure") ||


                query.ToLower().Contains("update ") ||
                query.ToLower().Contains("insert ") ||
                query.ToLower().Contains("create ") ||
                query.ToLower().Contains("alter ") ||
                query.ToLower().Contains("delete ") ||
                query.ToLower().Contains("truncate ") ||

                query.ToLower().Contains("drop ")

                )
            // query.ToLower().Contains("exec "))
            {
                IsDML = true;
                if (authority == null || authority == "")
                {
                    return false;
                }
                //SqlCommand cmd = new SqlCommand("select * from M_COM_DML_AUTHORITY where vchAuthority='" + authority + "' ");
                //authority = //SHA512Hash.SHa512(DESEncrypt.Encrypt(authority.ToLower()).ToLower()).ToLower();
                //string queryAuthority = "select * from M_COM_DML_AUTHORITY where vchAuthority='" + authority + "'";
                string queryAuthority = "1999";
                //DataTable dt = _PaymentRepository.GetAuthorityInfo(queryAuthority);
                if (queryAuthority == "1999")
                {
                    return true;
                }
                //else
                return false;
            }
            return true;
        }
    }

}