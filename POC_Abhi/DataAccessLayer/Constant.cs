using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public static class Constant
    {
        public const string SP_FETCH_ALL_EMPLOYEES = "sp_fetch_employees";
        public const string SP_FETCH_EMPLOYEE_BY_ID = "sp_FetchEmployee_By_Id";
        public const string SP_FETCH_EMPLOYEE_BY_ID_AND_NAME = "sp_FetchEmployee_By_Id_And_Name";
        public const string SP_CREATE_EMPLOYEE = "sp_create_employee";
        public const string SP_UPDATE_EMPLOYEE_BY_ID = "sp_update_employee_by_id";
        public const string SP_DELETE_EMPLOYEE_BY_ID = "sp_delete_employee_By_Id";
        public const string ERRORMSG = "Custome Error";
    }
}
