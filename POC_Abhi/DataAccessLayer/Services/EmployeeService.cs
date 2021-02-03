using Common.Model;
using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccessLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IAppSettings _sqlHelper;
        private readonly ILogger<EmployeeService> _logger;
        //public IConfiguration Configuration _configuration;

        /// <summary>
        /// initialize constructor
        /// </summary>
        /// <param name="sqlHelper"></param>
        public EmployeeService(IAppSettings sqlHelper, ILogger<EmployeeService> logger)
        {
            _sqlHelper = sqlHelper;
            _logger = logger;
            //var conn = _configuration["ConnectionStrings:DefaultConnection"];
        }

        /// <summary>
        /// Fetch all the employees from database
        /// </summary>
        /// <returns>list of employees</returns>
        public List<EmployeeModel> GetAllEmployee()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_sqlHelper.Connectionstring))
                {
                    using (var result = db.QueryMultiple(Constant.SP_FETCH_ALL_EMPLOYEES, commandType: CommandType.StoredProcedure))
                        return result.Read<EmployeeModel>().ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex,"Error Occured in EmployeeService.GetAllEmployee!!");
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
                using (IDbConnection db = new SqlConnection(_sqlHelper.Connectionstring))
                {
                    using (var result = db.QueryMultiple(Constant.SP_FETCH_EMPLOYEE_BY_ID, new { id = id }, commandType: CommandType.StoredProcedure))
                    {
                        return result.Read<EmployeeModel>().FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex,"Error Occured in EmployeeService.GetEmployee!!");
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
                using (IDbConnection db = new SqlConnection(_sqlHelper.Connectionstring))
                {
                    using (var result = db.QueryMultiple(Constant.SP_FETCH_EMPLOYEE_BY_ID_AND_NAME, new { id = id, name = name }, commandType: CommandType.StoredProcedure))
                    {
                        return result.Read<EmployeeModel>().FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error Occured in EmployeeService.GetEmployeeByIdAndName!!");
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
                using (IDbConnection db = new SqlConnection(_sqlHelper.Connectionstring))
                {
                    var parameter = new DynamicParameters();
                    parameter.Add("@Id", model.Id, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);
                    parameter.Add("@Name", model.Name);
                    parameter.Add("@Gender", model.Gender);
                    parameter.Add("@Salary", model.Salary);
                    parameter.Add("@Age", model.Age);
                    parameter.Add("@Country", model.Country);
                    parameter.Add("@Email", model.Email);

                    db.Execute(Constant.SP_CREATE_EMPLOYEE, parameter, commandType: CommandType.StoredProcedure);

                    //To get newly created ID back  
                    model.Id = parameter.Get<int>("@Id");
                    return model.Id;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error Occured in EmployeeService.AddEmployee!!");
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
                using (IDbConnection db = new SqlConnection(_sqlHelper.Connectionstring))
                {
                    return db.Execute(Constant.SP_UPDATE_EMPLOYEE_BY_ID, new { id = id,name=name }, commandType: CommandType.StoredProcedure);
                       
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error Occured in EmployeeService.UpdateEmployee!!");
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
                using (IDbConnection db = new SqlConnection(_sqlHelper.Connectionstring))
                {
                    return db.Execute(Constant.SP_DELETE_EMPLOYEE_BY_ID, new { id = id }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error Occured in EmployeeService.DeleteEmployee!!");
                throw;
            }            
        }
                
    }
}
