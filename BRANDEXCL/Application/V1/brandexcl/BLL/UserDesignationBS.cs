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
   public class UserDesignationBS
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static UserDesignationBS instance = new UserDesignationBS();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static UserDesignationBS GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Methods & Implementation
        public DataTable GetUserDesignationList()
        {
            return DAL.UserDesignationDb.GetInstance.GetUserDesignationList();
        }
        public int UpdateUserDesignation(UserDesignation theDesgn)
        {
            return DAL.UserDesignationDb.GetInstance.UpdateUserDesignation(theDesgn);
        }
        public int CreateUserDesignation(UserDesignation theDesgn)
        {
            return DAL.UserDesignationDb.GetInstance.CreateUserDesignation(theDesgn);
        }
        public DataTable DeleteDesignation(string Desg_ID)
        {
            return DAL.UserDesignationDb.GetInstance.DeleteDesignation(Desg_ID);
        }
        public DataTable GetDesgById(int Desg_ID)
        {
            return DAL.UserDesignationDb.GetInstance.GetDesgById(Desg_ID);
        }
        #endregion
    }
}
