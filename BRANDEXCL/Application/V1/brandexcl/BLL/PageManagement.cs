using BOL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
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
            return DAL.PageDataAccess.GetInstance.InsertPage(thePage);
        }

        public int UpdatePage(Page thePage)
        {
            return DAL.PageDataAccess.GetInstance.UpdatePage(thePage);
        }
        public DataTable GetPageList()
        {
            return DAL.PageDataAccess.GetInstance.GetPageList();
        }
        public DataTable GetPageById(int bnkid)
        {
            return DAL.PageDataAccess.GetInstance.GetPageById(bnkid);
        }
        public DataTable DeletePage(string bnkid)
        {
            return DAL.PageDataAccess.GetInstance.DeletePage(bnkid);
        }
        #endregion
    }
}
