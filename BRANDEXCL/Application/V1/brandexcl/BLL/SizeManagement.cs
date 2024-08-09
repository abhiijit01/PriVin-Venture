using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using System.Data;

namespace BLL
{
   public class SizeManagement
    {


        #region This code is for making it singleton application
        ///<summary>
        ///private static member to implement singleton design pattern
        ///</summary>
        private static SizeManagement instance = new SizeManagement();
        ///<summary>
        ///Static Property of the class which will provide the singleton instance of it 
        ///</summary>
        public static SizeManagement GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion
        #region Methods And Implementation
        public int InsertSize(Size theSize)
        {
            return DAL.SizeDataAccess.GetInstance.InsertSize(theSize);
        }


        public int UpdateSize(Size theSize)
        {
            return DAL.SizeDataAccess.GetInstance.UpdateSize(theSize);
        }
        //public int DeleteUserRole(int RoleID)
        //{
        //    return DAL.UserRoleDataAccess.GetInstance.DeleteUserRole(RoleID);
        //}
        public DataTable GetSizeList()
        {
            return DAL.SizeDataAccess.GetInstance.GetSizeList();
        }
        public DataRow GetSizeById(int sizeid)
        {
            return DAL.SizeDataAccess.GetInstance.GetSizeById(sizeid);
        }
        public DataTable DeleteSize(string sizeid)
        {
            return DAL.SizeDataAccess.GetInstance.DeleteSize(sizeid);
        }
        #endregion
    }
}
