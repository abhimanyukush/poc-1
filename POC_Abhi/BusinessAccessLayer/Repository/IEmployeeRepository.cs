using System.Collections.Generic;
using DataAccessLayer.Model;

namespace BusinessAccessLayer.Repository
{
    public interface IEmployeeRepository
    {
        int AddEmployee(EmployeeModel model);
        int DeleteEmployee(int id);
        List<EmployeeModel> GetAllEmployee();
        EmployeeModel GetEmployee(int id);
        int UpdateEmployee(int id, string name);
    }
}