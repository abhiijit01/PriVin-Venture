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




namespace BRANDEXCL.Areas.User.Controllers
{
    public class NewUserController : Controller
    {
        #region Decalration
        int ReturnValue = 0;
        
        public string RandonNo()
        {
            int len = 8;
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < len--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
        #endregion

        #region View Page

        public ActionResult CreateUser()
        {
            ViewBag.msg = RandonNo();
            return View();
        }
        public ActionResult ViewUser()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        public ActionResult Myprofile()
        {
            return View();
        }
        public ActionResult Indexdata() { return View(); }
        #endregion

        #region Json Data
        [HttpPost]
        public JsonResult CreateUser(NewUser theUser)
        {
            try
            {
               
                if (theUser.Usr_Id >= 1)
                {
                      ReturnValue = BRANDEXCL.Business.NewUserBs.GetInstance.UpdateUser(theUser);
                }
                else
                {
                    ReturnValue = BRANDEXCL.Business.NewUserBs.GetInstance.CreateUser(theUser);
                }
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
                return Json("User Creation Failed");
            }
        }


        [HttpPost]

        public JsonResult DeleteUser(string Id)
        {
            int[] nums = Array.ConvertAll(Id.Split(','), int.Parse);
            DataTable dt = new DataTable();
            dt.Columns.Add("Usr_Id");
            foreach (int s in nums)
            {
                dt.Rows.Add(s);
            }
            string Usr_Id = Common.GetSTRXMLResult(dt);
            try
            {
                DataTable data = NewUserBs.GetInstance.DeleteUser(Usr_Id);
                return Json("Deleted Successfully");
            }
            catch
            {
                return Json("Could not find any Data to Delete");
            }
        }
        //public JsonResult DeleteUser(string[] Usr_Id1)
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Usr_Id");
        //    foreach (string s in Usr_Id1)
        //    {
        //        dt.Rows.Add(s);
        //    }
        //    string Usr_Id = XmlToString.GetSTRXMLResult(dt);
        //    try
        //    {
        //        DataTable data = NewUserBs.GetInstance.DeleteUser(Usr_Id);
        //        return Json("Deleted Successfully");
        //    }
        //    catch
        //    {
        //        return Json("Could not find any Data to Delete");
        //    }
        //}

        [HttpGet]
        public JsonResult PopulateFormField(int Usr_Id)
        {
            DataTable dt = NewUserBs.GetInstance.GetUserById(Usr_Id);
            try
            {
                List<NewUser> Userlist = new List<NewUser>();
                Userlist = (from DataRow dr in dt.Rows
                            select new NewUser()
                            {
                                Usr_Id = Convert.ToInt32(dr["Usr_Id"]),
                                Usr_Nm = dr["Usr_Nm"].ToString(),
                                RoleDesc = dr["RoleDesc"].ToString(),
                                RoleID = Convert.ToInt32(dr["RoleID"]),
                                Desg_ID = Convert.ToInt32(dr["Desg_ID"]),
                                Designation_Name = dr["Designation_Name"].ToString(),
                                outid = Convert.ToInt32(dr["outid"]),
                                outletname = dr["outnm"].ToString(),
                                countid = Convert.ToInt32(dr["countid"]),
                                countername = dr["countnm"].ToString(),
                                Name = dr["Name"].ToString(),
                                EmpCode = dr["EmpCode"].ToString(),
                                Email = dr["Email"].ToString(),
                                Phone = dr["Phone"].ToString()
                            }).ToList();
                return Json(Userlist);
            }
            catch
            {
                return Json("Cannot Find any User.");
            }
        }
        [HttpGet]
        public JsonResult getUserDetailsByLoggedInUser()
        {
            DataTable dt = NewUserBs.GetInstance.getUserDetailsByLoggedInUser();
            try
            {
                List<NewUser> Userlist = new List<NewUser>();
                Userlist = (from DataRow dr in dt.Rows
                            select new NewUser()
                            {
                                Usr_Id = Convert.ToInt32(dr["Usr_Id"]),
                                Usr_Nm = dr["Usr_Nm"].ToString(),
                                RoleDesc = dr["RoleDesc"].ToString(),
                                image = dr["image"].ToString(),
                                RoleID = Convert.ToInt32(dr["RoleID"]),
                                Desg_ID = Convert.ToInt32(dr["Desg_ID"]),
                                Designation_Name = dr["Designation_Name"].ToString(),
                                outletname = dr["outnm"].ToString(),
                                countername = dr["countnm"].ToString(),
                                Name = dr["Name"].ToString(),
                                EmpCode = dr["EmpCode"].ToString(),
                                Email = dr["Email"].ToString(),
                                Phone = dr["Phone"].ToString()
                            }).ToList();
                return Json(Userlist);
            }
            catch(Exception Ex)
            {
                return Json("Cannot Find any User.");
            }
        }


        [HttpPost]
        public JsonResult ProfilepicUpdate()
        {
        
            try
            {
                //HttpFileCollectionBase files = Request.Files;
                //for (int i = 0; i < Request.Files.Count; i++)
                //{
                //    var file = Request.Files[i];
                //    var fileName = Path.GetFileName(file.FileName);
                //    var path = Path.Combine(Server.MapPath("/images/profilepic/"), fileName);
                //    file.SaveAs(path);
                //    var iamgeurl = "/images/profilepic/" + fileName;
                //    ReturnValue = NewUserBs.GetInstance.ProfilepicUpdate(iamgeurl);
                //}
                if (ReturnValue >= 1)
                {
                    return Json("Picture Uploaded successfully");
                }

                else
                {
                    return Json("No picture found to upload");
                }

            }
            catch (Exception Ex)
            {
                return Json("Upload faild");
            }
        }
        [HttpGet]
        public JsonResult BindGrid(string sidx, string sord, int page, int rows,
            bool _search, string searchField, string searchOper, string searchString
            )
        {
            DataTable dt = NewUserBs.GetInstance.GetUserList();
            try
            {
                int pageIndex = Convert.ToInt32(page) - 1;
                int pageSize = rows;
                sord = (sord == null) ? "" : sord;
                List<NewUser> Userlists = new List<NewUser>();
                Userlists = (from DataRow dr in dt.Rows
                             select new NewUser()
                             {
                                 Usr_Id = Convert.ToInt32(dr["Usr_Id"]),
                                 Usr_Nm = dr["Usr_Nm"].ToString(),
                                 RoleDesc = dr["RoleDesc"].ToString(),
                                 RoleID = Convert.ToInt32(dr["RoleID"]),
                                 Desg_ID = Convert.ToInt32(dr["Desg_ID"]),
                                 Designation_Name = dr["Designation_Name"].ToString(),
                                 outletname = dr["outnm"].ToString(),
                                 countername = dr["countnm"].ToString(),
                                 Name = dr["Name"].ToString(),
                                 EmpCode = dr["EmpCode"].ToString(),
                                 Email = dr["Email"].ToString(),
                                 Phone = dr["Phone"].ToString()
                             }).ToList();
                if (_search)
                {
                    switch (searchField)
                    {
                        case "Usr_Nm":
                            Userlists = Userlists.Where(t => t.Usr_Nm.Contains(searchString)).ToList();
                            break;
                        case "RoleDesc":
                            Userlists = Userlists.Where(t => t.RoleDesc.Contains(searchString)).ToList();
                            break;

                        case "Designation_Name":
                            Userlists = Userlists.Where(t => t.Designation_Name.Contains(searchString)).ToList();
                            break;

                        case "outletname":
                            Userlists = Userlists.Where(t => t.outletname.Contains(searchString)).ToList();
                            break;
                        case "countername":
                            Userlists = Userlists.Where(t => t.countername.Contains(searchString)).ToList();
                            break;
                        case "Name":
                            Userlists = Userlists.Where(t => t.Name.Contains(searchString)).ToList();
                            break;

                        case "EmpCode":
                            Userlists = Userlists.Where(t => t.EmpCode.Contains(searchString)).ToList();
                            break;

                        case "Email":
                            Userlists = Userlists.Where(t => t.Email.Contains(searchString)).ToList();
                            break;

                        case "Phone":
                            Userlists = Userlists.Where(t => t.Phone.Contains(searchString)).ToList();
                            break;
                    }
                }
                int totalRecords = Userlists.Count();
                var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
                if (sord.ToUpper() == "DESC")
                {
                    Userlists = Userlists.OrderByDescending(t => t.Usr_Id).ToList();
                    Userlists = Userlists.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                }
                else
                {
                    Userlists = Userlists.OrderBy(t => t.Usr_Id).ToList();
                    Userlists = Userlists.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                }
                var jsonData = new
                {
                    total = totalPages,
                    page,
                    records = totalRecords,
                    rows = Userlists
                };
                return Json(jsonData);
            }
            catch
            {
                return Json("Cann't find any Users");
            }

        }
        //public JsonResult BindGrid()
        //{
        //    DataTable dt = NewUserBs.GetInstance.GetUserList();
        //    try
        //    {
        //        List<NewUser> Userlists = new List<NewUser>();
        //        Userlists = (from DataRow dr in dt.Rows
        //                    select new NewUser()
        //                    {
        //                        Usr_Id = Convert.ToInt32(dr["Usr_Id"]),
        //                        Usr_Nm = dr["Usr_Nm"].ToString(),
        //                        RoleDesc= dr["RoleDesc"].ToString(),
        //                        RoleID= Convert.ToInt32(dr["RoleID"]),
        //                        Desg_ID= Convert.ToInt32(dr["Desg_ID"]),
        //                        Designation_Name= dr["Designation_Name"].ToString(),
        //                        Dept_ID= Convert.ToInt32(dr["Dept_ID"]),
        //                        Dept_Name= dr["Dept_Name"].ToString(),
        //                        Unit_Id= Convert.ToInt32(dr["Unit_Id"]),
        //                        Unit_Name = dr["Unit_Name"].ToString(),
        //                        Name = dr["Name"].ToString(),
        //                        EmpCode = dr["EmpCode"].ToString(),
        //                        Email = dr["Email"].ToString(),
        //                        Phone= dr["Phone"].ToString()
        //                    }).ToList();
        //        return Json(Userlists);
        //    }
        //    catch
        //    {
        //        return Json("Cann't find any Users");
        //    }

        //}
        [HttpPost]
        public JsonResult ChangePassword(NewUser theUser)
        {
            try
            {

                ReturnValue = BRANDEXCL.Business.NewUserBs.GetInstance.ChangePwd(theUser);
     
               
                if (ReturnValue >= 1)
                {
                    return Json("Password Updated Successfully.");
                }               
                else
                {
                    return Json("Old Password did not match.");
                }
            }
            catch(Exception Ex)
            { return Json("Failed to Change Password."); }
           
        }
        [HttpPost]
        public JsonResult ForgotPassword(NewUser theUser)
        {
            try
            {
                ReturnValue = BRANDEXCL.Business.NewUserBs.GetInstance.CheckExist(theUser);
                if (ReturnValue == 1)
                {
                    return Json("User Exists");
                }
                else
                {
                    return Json("User Doesnot Exists");
                }
            }
            catch { return Json("Failed to Check The User"); }
        }
        [HttpPost]
        public int MailSend(string maildata, string username, string resetlink)
        {
           
            try
            {
                System.Net.Mail.MailMessage msg = new MailMessage();                
                msg.To.Add(new MailAddress(maildata));
                msg.From = new MailAddress("madhusmitapatra855@gmail.com","Debashis Palai");
                msg.Subject = "Reset Password Link";
                #region BodySetup
                string body = "Hi " + username + ", <br/>Please Go through the link to resst your password.<br/> " + resetlink + " <br/><br/> Regards,<br/> OASYS Tech Sol Pvt Ltd";
                #endregion

                msg.Body = body; 
                msg.IsBodyHtml = true;
                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("madhusmitapatra855@gmail.com", "9178340084");              
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                try
                {
                    client.Send(msg);
                    return 1;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}