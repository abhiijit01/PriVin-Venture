using BRANDEXCL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRANDEXCL.Business
{
    public class PageManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static PageManagement instance = new PageManagement();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static PageManagement GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Methods & Implementation
        public int InsertPage(Page thePage)
        {
            return BRANDEXCL.DataAccess.PageDataAccess.GetInstance.InsertPage(thePage);
        }

        public int UpdatePage(Page thePage)
        {
            return BRANDEXCL.DataAccess.PageDataAccess.GetInstance.UpdatePage(thePage);
        }
        public DataTable GetPageList()
        {
            return BRANDEXCL.DataAccess.PageDataAccess.GetInstance.GetPageList();
        }
        public DataTable GetPageById(int bnkid)
        {
            return BRANDEXCL.DataAccess.PageDataAccess.GetInstance.GetPageById(bnkid);
        }
        public DataTable DeletePage(string bnkid)
        {
            return BRANDEXCL.DataAccess.PageDataAccess.GetInstance.DeletePage(bnkid);
        }
        #endregion
    }
}
