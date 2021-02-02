using DataAccessLayer.Model;
using DataAccessLayer.Services;
using System;
using System.Collections.Generic;

namespace BusinessAccessLayer.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IEmployeeService _service;

        /// <summary>
        /// initialize constructor
        /// </summary>
        /// <param name="service"></param>
        public EmployeeRepository(IEmployeeService service)
        {
            _service = service;
        }
        /// <summary>
        /// Fetch all the employees from database
        /// </summary>
        /// <returns>list of employees</returns>
        public List<EmployeeModel> GetAllEmployee()
        {
            try
            {
                var employees = _service.GetAllEmployee();

                return employees;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Get employee based on id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>employee object</returns>
        public EmployeeModel GetEmployee(int id)
        {
            try
            {
                var employee =_service.GetEmployee(id);

                return employee;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Add new employee into the database
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>int</returns>
        public int AddEmployee(EmployeeModel model)
        {
            try
            {
                var id= _service.AddEmployee(model);

                return id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// update employee based on id
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="name">name</param>
        /// <returns>int</returns>
        public int UpdateEmployee(int id, string name)
        {
            try
            {
                var updatedId =_service.UpdateEmployee(id, name);

                return updatedId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// delete employee based on id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public int DeleteEmployee(int id)
        {
            try
            {
                var deletedId = _service.DeleteEmployee(id);

                return deletedId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
