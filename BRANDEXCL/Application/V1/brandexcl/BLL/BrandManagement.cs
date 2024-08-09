using BOL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BrandManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static BrandManagement instance = new BrandManagement();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static BrandManagement GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion
        #region Methods & Implementation
        public int InsertBrand(Brand theRole)
        {
            return DAL.BrandDataAccess.GetInstance.InsertBrand(theRole);
        }


        public int UpdateBrand(Brand theRole)
        {
            return DAL.BrandDataAccess.GetInstance.UpdateBrand(theRole);
        }
        //public int DeleteUserRole(int RoleID)
        //{
        //    return DAL.UserRoleDataAccess.GetInstance.DeleteUserRole(RoleID);
        //}
        public DataTable GetBrandList()
        {
            return DAL.BrandDataAccess.GetInstance.GetBrandList();
        }
        public DataRow GetBrandById(int outid)
        {
            return DAL.BrandDataAccess.GetInstance.GetBrandById(outid);
        }
        public DataTable DeleteBrand(string outid)
        {
            return DAL.BrandDataAccess.GetInstance.DeleteBrand(outid);
        }
        #endregion
    }
}
