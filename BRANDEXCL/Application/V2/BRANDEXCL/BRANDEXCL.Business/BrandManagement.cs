using BRANDEXCL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRANDEXCL.Business
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
            return BRANDEXCL.DataAccess.BrandDataAccess.GetInstance.InsertBrand(theRole);
        }


        public int UpdateBrand(Brand theRole)
        {
            return BRANDEXCL.DataAccess.BrandDataAccess.GetInstance.UpdateBrand(theRole);
        }
        //public int DeleteUserRole(int RoleID)
        //{
        //    return BRANDEXCL.DataAccess.UserRoleDataAccess.GetInstance.DeleteUserRole(RoleID);
        //}
        public DataTable GetBrandList()
        {
            return BRANDEXCL.DataAccess.BrandDataAccess.GetInstance.GetBrandList();
        }
        public DataRow GetBrandById(int outid)
        {
            return BRANDEXCL.DataAccess.BrandDataAccess.GetInstance.GetBrandById(outid);
        }
        public DataTable DeleteBrand(string outid)
        {
            return BRANDEXCL.DataAccess.BrandDataAccess.GetInstance.DeleteBrand(outid);
        }
        #endregion
    }
}
