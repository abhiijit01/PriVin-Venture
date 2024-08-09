﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRANDEXCL.Model;

namespace BRANDEXCL.Business
{
    public class PermissionManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static PermissionManagement instance = new PermissionManagement();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static PermissionManagement GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Methods & Implementation
        public DataTable GetPagePermissionList()
        {
            return BRANDEXCL.DataAccess.PermissionDataAccess.GetInstance.GetPagePermissionList();
        }

        public DataTable GetPagePermissionListByRoleID(int roleID)
        {
            return BRANDEXCL.DataAccess.PermissionDataAccess.GetInstance.GetPagePermissionListByRoleID(roleID);
        }
        public DataTable GetPagesListByRoleID(int roleID)
        {
            return BRANDEXCL.DataAccess.PermissionDataAccess.GetInstance.GetPagesListByRoleID(roleID);
        }

        public int InsertPagePermission(string strPermission)
        {
            return BRANDEXCL.DataAccess.PermissionDataAccess.GetInstance.InsertPagePermission(strPermission);
        }
        #endregion
    }
}
