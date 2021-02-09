using Common.Model;
using Dapper;
using DataAccessLayer;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BusinessLayer.Services
{
    public class EmployeeService : IEmployeeService,IDisposable
    {
        private readonly IAppSettings _appSettings;
        //private readonly ILogger<EmployeeService> _logger;
        IDbConnection db = null;

        /// <summary>
        /// initialize constructor
        /// </summary>
        /// <param name="sqlHelper"></param>
        public EmployeeService(IAppSettings appSettings)
        {
            _appSettings = appSettings;
            //_logger = logger;
            db = new SqlConnection(_appSettings.Connectionstring);
        }

        /// <summary>
        /// Fetch all the employees from database
        /// </summary>
        /// <returns>list of employees</returns>
        public List<EmployeeModel> GetAllEmployee()
        {
            return db.Query<EmployeeModel>(Constant.SP_FETCH_ALL_EMPLOYEES, commandType: CommandType.StoredProcedure).ToList();                

        }

        /// <summary>
        /// Get employee based on id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>employee object</returns>
        public EmployeeModel GetEmployee(int id)
        {
            return db.Query<EmployeeModel>(Constant.SP_FETCH_EMPLOYEE_BY_ID, new { id }, commandType: CommandType.StoredProcedure).SingleOrDefault();

        }

        /// <summary>
        /// Fetch employee based on id and name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public EmployeeModel GetEmployeeByIdAndName(int id, string name)
        {
            return db.Query<EmployeeModel>(Constant.SP_FETCH_EMPLOYEE_BY_ID_AND_NAME, new { id, name }, commandType: CommandType.StoredProcedure).SingleOrDefault();

        }

        /// <summary>
        /// Add new employee into the database
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>int</returns>
        public int AddEmployee(EmployeeModel model)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Id", model.Id, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);
            parameter.Add("@Name", model.Name);
            parameter.Add("@Gender", model.Gender);
            parameter.Add("@Salary", model.Salary);
            parameter.Add("@Age", model.Age);
            parameter.Add("@Country", model.Country);
            parameter.Add("@Email", model.Email);

            db.Execute(Constant.SP_CREATE_EMPLOYEE, parameter, commandType: CommandType.StoredProcedure) ;

            //To get newly created ID back  
            model.Id = parameter.Get<int>("@Id");
            return model.Id;

        }

        /// <summary>
        /// update employee based on id
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="name">name</param>
        /// <returns>int</returns>
        public int UpdateEmployee(int id, string name)
        {
            return db.Execute(Constant.SP_UPDATE_EMPLOYEE_BY_ID, new { id, name }, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// delete employee based on id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public int DeleteEmployee(int id)
        {
            return db.Execute(Constant.SP_DELETE_EMPLOYEE_BY_ID, new { id }, commandType: CommandType.StoredProcedure);
        }

        public void Dispose()
        {
            db.Close();
        }
    }
}
