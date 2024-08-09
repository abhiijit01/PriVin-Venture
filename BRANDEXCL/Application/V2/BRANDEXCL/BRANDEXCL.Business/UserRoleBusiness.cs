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
   public class UserRoleBusiness
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static UserRoleBusiness instance = new UserRoleBusiness();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static UserRoleBusiness GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion
       public int InsertContractor(UserRole theRole)
        {
            return BRANDEXCL.DataAccess.UserRoleDataAccess.GetInstance.InsertUserRole(theRole);
        }

        public int UpdateUserRole(UserRole theRole)
        {
            return BRANDEXCL.DataAccess.UserRoleDataAccess.GetInstance.UpdateUserRole(theRole);
        }
        //public int DeleteUserRole(int RoleID)
        //{
        //    return BRANDEXCL.DataAccess.UserRoleDataAccess.GetInstance.DeleteUserRole(RoleID);
        //}
        public DataTable GetUserRoleList()
        {
            return BRANDEXCL.DataAccess.UserRoleDataAccess.GetInstance.GetUserRoleList();
        }
        public DataRow GetUserRoleById(int RoleID)
        {
            return BRANDEXCL.DataAccess.UserRoleDataAccess.GetInstance.GetUserRoleById(RoleID);
        }
        public DataTable DeleSelectedUser(string RoleID)
        {
            return BRANDEXCL.DataAccess.UserRoleDataAccess.GetInstance.DeleSelectedUser(RoleID);
        }
    }

}
