using Common.Model;
using System.Collections.Generic;

namespace RepositoryLayer.Repository
{
    public interface IEmployeeRepository
    {
        int AddEmployee(EmployeeModel model);
        int DeleteEmployee(int id);
        List<EmployeeModel> GetAllEmployee();
        EmployeeModel GetEmployee(int id);
        EmployeeModel GetEmployeeByIdAndName(int id, string name);
        int UpdateEmployee(int id, string name);
    }
}