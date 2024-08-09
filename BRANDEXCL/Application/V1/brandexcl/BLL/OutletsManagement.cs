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
   public  class OutletsManagement
    {

        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static OutletsManagement instance = new OutletsManagement();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static OutletsManagement GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion
        #region Methods & Implementation
        public int InsertOutlet(Outlets theRole)
        {
            return DAL.OutletsDataAccess.GetInstance.InsertOutlet(theRole);
        }


        public int UpdateOutlet(Outlets theRole)
        {
            return DAL.OutletsDataAccess.GetInstance.UpdateOutlet(theRole);
        }
        //public int DeleteUserRole(int RoleID)
        //{
        //    return DAL.UserRoleDataAccess.GetInstance.DeleteUserRole(RoleID);
        //}
        public DataTable GetOutletList()
        {
            return DAL.OutletsDataAccess.GetInstance.GetOutletList();
        }
        public DataRow GetOutletById(int outid)
        {
            return DAL.OutletsDataAccess.GetInstance.GetOutletById(outid);
        }
        public DataTable DeleteOutlet(string outid)
        {
            return DAL.OutletsDataAccess.GetInstance.DeleteOutlet(outid);
        }
        #endregion
    }
}
