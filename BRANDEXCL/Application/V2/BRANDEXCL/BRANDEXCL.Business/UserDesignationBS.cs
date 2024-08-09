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
            return BRANDEXCL.DataAccess.UserDesignationDb.GetInstance.GetUserDesignationList();
        }
        public int UpdateUserDesignation(UserDesignation theDesgn)
        {
            return BRANDEXCL.DataAccess.UserDesignationDb.GetInstance.UpdateUserDesignation(theDesgn);
        }
        public int CreateUserDesignation(UserDesignation theDesgn)
        {
            return BRANDEXCL.DataAccess.UserDesignationDb.GetInstance.CreateUserDesignation(theDesgn);
        }
        public DataTable DeleteDesignation(string Desg_ID)
        {
            return BRANDEXCL.DataAccess.UserDesignationDb.GetInstance.DeleteDesignation(Desg_ID);
        }
        public DataTable GetDesgById(int Desg_ID)
        {
            return BRANDEXCL.DataAccess.UserDesignationDb.GetInstance.GetDesgById(Desg_ID);
        }
        #endregion
    }
}
