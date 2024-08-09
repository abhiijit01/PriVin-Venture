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
            return DAL.UserRoleDataAccess.GetInstance.InsertUserRole(theRole);
        }

        public int UpdateUserRole(UserRole theRole)
        {
            return DAL.UserRoleDataAccess.GetInstance.UpdateUserRole(theRole);
        }
        //public int DeleteUserRole(int RoleID)
        //{
        //    return DAL.UserRoleDataAccess.GetInstance.DeleteUserRole(RoleID);
        //}
        public DataTable GetUserRoleList()
        {
            return DAL.UserRoleDataAccess.GetInstance.GetUserRoleList();
        }
        public DataRow GetUserRoleById(int RoleID)
        {
            return DAL.UserRoleDataAccess.GetInstance.GetUserRoleById(RoleID);
        }
        public DataTable DeleSelectedUser(string RoleID)
        {
            return DAL.UserRoleDataAccess.GetInstance.DeleSelectedUser(RoleID);
        }
    }

}
