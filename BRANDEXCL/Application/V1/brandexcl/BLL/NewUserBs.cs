using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BOL;
using System.Data;

namespace BLL
{
   public class NewUserBs
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static NewUserBs instance = new NewUserBs();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static NewUserBs GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion
        #region Methods & Implementation
        //Create New User
        public int CreateUser(NewUser theUser)
        {
            return DAL.NewUserDb.GetInstance.CreateUser(theUser);
        }
        public int UpdateUser(NewUser theUser)
        {
            return DAL.NewUserDb.GetInstance.UpdateUser(theUser);
        }
        public DataTable GetUserList()
        {
            return DAL.NewUserDb.GetInstance.GetUserList();
        }
        
         public int ProfilepicUpdate(string image)
        {
            return DAL.NewUserDb.GetInstance.ProfilepicUpdate(image);
        }
        public DataTable GetUserById(int Usr_Id)
        {
            return DAL.NewUserDb.GetInstance.GetUserById(Usr_Id);
        }
        public DataTable getUserDetailsByLoggedInUser()
        {
            return DAL.NewUserDb.GetInstance.getUserDetailsByLoggedInUser();
        }
        
        public DataTable DeleteUser(string Usr_Id)
        {
            return DAL.NewUserDb.GetInstance.DeleteUser(Usr_Id);
        }
        public int ChangePwd(NewUser theUser)
        {
            return DAL.NewUserDb.GetInstance.ChangePwd(theUser);
        }
        public int ResetPwd(NewUser theUser)
        {
            return DAL.NewUserDb.GetInstance.ResetPwd(theUser);
        }
        public int CheckExist(NewUser theUser)
        {
            return DAL.NewUserDb.GetInstance.CheckExist(theUser);
        }
        public DataTable CheckUserExist(NewUser theUser)
        {
            return DAL.NewUserDb.GetInstance.CheckUserExist(theUser);
        }
        public DataTable OutletSelectByUserId(int Usr_Id)
        {
            return DAL.NewUserDb.GetInstance.OutletSelectByUserId(Usr_Id);
        }
        public DataTable GetQueryData(string query)
        {
            return DAL.NewUserDb.GetInstance.GetQueryData(query);
        }
        #endregion
    }
}
