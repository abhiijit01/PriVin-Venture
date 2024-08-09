using BOL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static CategoryManagement instance = new CategoryManagement();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static CategoryManagement GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion
        #region Methods & Implementation
        public int InsertCategory(Category theRole)
        {
            return DAL.CategoryDataAccess.GetInstance.InsertCategory(theRole);
        }


        public int UpdateCategory(Category theRole)
        {
            return DAL.CategoryDataAccess.GetInstance.UpdateCategory(theRole);
        }
        //public int DeleteUserRole(int RoleID)
        //{
        //    return DAL.UserRoleDataAccess.GetInstance.DeleteUserRole(RoleID);
        //}
        public DataTable GetCategoryList()
        {
            return DAL.CategoryDataAccess.GetInstance.GetCategoryList();
        }
        public DataRow GetCategoryById(int outid)
        {
            return DAL.CategoryDataAccess.GetInstance.GetCategoryById(outid);
        }
        public DataTable DeleteCategory(string outid)
        {
            return DAL.CategoryDataAccess.GetInstance.DeleteCategory(outid);
        }
        #endregion
    }
}
