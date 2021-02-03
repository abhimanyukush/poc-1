using Common.Model;
using DataAccessLayer.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace BusinessAccessLayer.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IEmployeeService _service;
        private readonly ILogger<EmployeeRepository> _logger;

        /// <summary>
        /// initialize constructor
        /// </summary>
        /// <param name="service"></param>
        public EmployeeRepository(IEmployeeService service,ILogger<EmployeeRepository> logger)
        {
            _service = service;
            _logger = logger;
        }
        /// <summary>
        /// Fetch all the employees from database
        /// </summary>
        /// <returns>list of employees</returns>
        public List<EmployeeModel> GetAllEmployee()
        {
            try
            {
                 return _service.GetAllEmployee();

                
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex,"Error Occured in EmployeeRepository.GetAllEmployee!!");
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
                return _service.GetEmployee(id);

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex,"Error Occured in EmployeeRepository.GetEmployee!!");
                throw;
            }
        }

        /// <summary>
        /// Fetch employee based on id and name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public EmployeeModel GetEmployeeByIdAndName(int id, string name)
        {
            try
            {
                return _service.GetEmployeeByIdAndName(id,name);

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error Occured in EmployeeRepository.GetEmployeeByIdAndName!!");
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
                return _service.AddEmployee(model);

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex,"Error Occured in EmployeeRepository.AddEmployee!!");
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
                return _service.UpdateEmployee(id, name);

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex,"Error Occured in EmployeeRepository.UpdateEmployee!!");
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
                return _service.DeleteEmployee(id);

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex,"Error Occured in EmployeeRepository.DeleteEmployee!!");
                throw;
            }
        }
               
    }
}
