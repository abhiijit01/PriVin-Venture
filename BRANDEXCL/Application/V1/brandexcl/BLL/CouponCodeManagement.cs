using BOL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CouponCodeManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static CouponCodeManagement instance = new CouponCodeManagement();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static CouponCodeManagement GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion
        #region Methods & Implementation
        public int InsertCouponCode(CouponCode theRole)
        {
            return DAL.CouponCodeDataAccess.GetInstance.InsertCouponCode(theRole);
        }
        public DataTable GetCouponCodeList(string action)
        {
            return DAL.CouponCodeDataAccess.GetInstance.GetCouponCodeList(action);
        }
        #endregion
    }
}
