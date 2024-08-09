using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRANDEXCL.DataAccess;
using BRANDEXCL.Model;
using System.Data;

namespace BRANDEXCL.Business
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
            return BRANDEXCL.DataAccess.NewUserDb.GetInstance.CreateUser(theUser);
        }
        public int UpdateUser(NewUser theUser)
        {
            return BRANDEXCL.DataAccess.NewUserDb.GetInstance.UpdateUser(theUser);
        }
        public DataTable GetUserList()
        {
            return BRANDEXCL.DataAccess.NewUserDb.GetInstance.GetUserList();
        }
        
         public int ProfilepicUpdate(string image)
        {
            return BRANDEXCL.DataAccess.NewUserDb.GetInstance.ProfilepicUpdate(image);
        }
        public DataTable GetUserById(int Usr_Id)
        {
            return BRANDEXCL.DataAccess.NewUserDb.GetInstance.GetUserById(Usr_Id);
        }
        public DataTable getUserDetailsByLoggedInUser()
        {
            return BRANDEXCL.DataAccess.NewUserDb.GetInstance.getUserDetailsByLoggedInUser();
        }
        
        public DataTable DeleteUser(string Usr_Id)
        {
            return BRANDEXCL.DataAccess.NewUserDb.GetInstance.DeleteUser(Usr_Id);
        }
        public int ChangePwd(NewUser theUser)
        {
            return BRANDEXCL.DataAccess.NewUserDb.GetInstance.ChangePwd(theUser);
        }
        public int ResetPwd(NewUser theUser)
        {
            return BRANDEXCL.DataAccess.NewUserDb.GetInstance.ResetPwd(theUser);
        }
        public int CheckExist(NewUser theUser)
        {
            return BRANDEXCL.DataAccess.NewUserDb.GetInstance.CheckExist(theUser);
        }
        public DataTable CheckUserExist(NewUser theUser)
        {
            return BRANDEXCL.DataAccess.NewUserDb.GetInstance.CheckUserExist(theUser);
        }
        public DataTable OutletSelectByUserId(int Usr_Id)
        {
            return BRANDEXCL.DataAccess.NewUserDb.GetInstance.OutletSelectByUserId(Usr_Id);
        }
        public DataTable GetQueryData(string query)
        {
            return BRANDEXCL.DataAccess.NewUserDb.GetInstance.GetQueryData(query);
        }
        #endregion
    }
}
