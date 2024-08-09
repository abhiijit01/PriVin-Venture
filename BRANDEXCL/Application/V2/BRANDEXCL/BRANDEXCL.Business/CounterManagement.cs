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
    public class CounterManagement
    {

        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static CounterManagement instance = new CounterManagement();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static CounterManagement GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion
        #region Methods & Implementation
        public int InsertCounter(Counter theCounter)
        {
            return BRANDEXCL.DataAccess.CounterDataAccess.GetInstance.InsertCounter(theCounter);
        }


        public int UpdateCounter(Counter theCounter)
        {
            return BRANDEXCL.DataAccess.CounterDataAccess.GetInstance.UpdateCounter(theCounter);
        }
        //public int DeleteUserRole(int RoleID)
        //{
        //    return BRANDEXCL.DataAccess.UserRoleDataAccess.GetInstance.DeleteUserRole(RoleID);
        //}
        public DataTable GetCounterList()
        {
            return BRANDEXCL.DataAccess.CounterDataAccess.GetInstance.GetCounterList();
        }
        public DataRow GetCounterById(int countid)
        {
            return BRANDEXCL.DataAccess.CounterDataAccess.GetInstance.GetCounterById(countid);
        }
        public DataTable DeleteCounter(string outid)
        {
            return BRANDEXCL.DataAccess.CounterDataAccess.GetInstance.DeleteCounter(outid);
        }
        #endregion
    }
}
