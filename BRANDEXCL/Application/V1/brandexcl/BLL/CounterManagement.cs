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
            return DAL.CounterDataAccess.GetInstance.InsertCounter(theCounter);
        }


        public int UpdateCounter(Counter theCounter)
        {
            return DAL.CounterDataAccess.GetInstance.UpdateCounter(theCounter);
        }
        //public int DeleteUserRole(int RoleID)
        //{
        //    return DAL.UserRoleDataAccess.GetInstance.DeleteUserRole(RoleID);
        //}
        public DataTable GetCounterList()
        {
            return DAL.CounterDataAccess.GetInstance.GetCounterList();
        }
        public DataRow GetCounterById(int countid)
        {
            return DAL.CounterDataAccess.GetInstance.GetCounterById(countid);
        }
        public DataTable DeleteCounter(string outid)
        {
            return DAL.CounterDataAccess.GetInstance.DeleteCounter(outid);
        }
        #endregion
    }
}
