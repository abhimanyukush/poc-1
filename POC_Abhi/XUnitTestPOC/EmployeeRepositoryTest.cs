using BusinessLayer.Services;
using Common.Model;
using Microsoft.Extensions.Logging;
using Moq;
using RepositoryLayer.Repository;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestPOC
{
    public class EmployeeRepositoryTest
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly Mock<IEmployeeService> _employeeRepoMock = new Mock<IEmployeeService>();
        private readonly Mock<ILogger<EmployeeRepository>> _loggerMock = new Mock<ILogger<EmployeeRepository>>();

        public EmployeeRepositoryTest()
        {
            _employeeRepository = new EmployeeRepository(_employeeRepoMock.Object, _loggerMock.Object);
        }

        [Fact]
        public void GetAllEmployee_ShouldReturnWhenEmployeeExist()
        {
            //Arrange

            var employees = EmployeeDataSource();

            _employeeRepoMock.Setup(x => x.GetAllEmployee()).Returns(employees);

            //Act
            var actualResult = _employeeRepository.GetAllEmployee();

            //Assert
            Assert.Equal(employees, actualResult);
        }

        [Fact]
        public void GetEmployee_ShouldReturnWhenEmployeeByIdExist()
        {
            //Arrange
            var employeeId = 4;

            EmployeeModel employee = new EmployeeModel()
            {
                Id = employeeId,
                Name = "Abhi",
                Age = 30,
                Country = "India",
                Gender = "Male",
                Salary = 29000,
                Email = "abhi@mailinator.com"
            };

            _employeeRepoMock.Setup(x => x.GetEmployee(employeeId)).Returns(employee);

            //Act
            var actualResult = _employeeRepository.GetEmployee(employeeId);

            //Assert
            Assert.Equal(employee, actualResult);
        }

        [Fact]
        public void GetEmployee_ShouldWhenEmployeeByIdAndNameExist()
        {
            //Arrange
            var employeeId = 3;
            var name = "Smith";

            EmployeeModel employee = new EmployeeModel()
            {
                Id = employeeId,
                Name = name,
                Age = 38,
                Country = "Aus",
                Gender = "Male",
                Salary = 19000,
                Email = "smith@mailinator.com"
            };

            _employeeRepoMock.Setup(x => x.GetEmployeeByIdAndName(employeeId,name)).Returns(employee);

            //Act
            var actualResult = _employeeRepository.GetEmployeeByIdAndName(employeeId,name);

            //Assert
            Assert.Equal(employee, actualResult);
        }

        [Fact]
        public void AddEmployee_ShouldWhenEmployee()
        {
            //Arrange
            var employeeId = 3;
            var name = "Smith";

            EmployeeModel employee = new EmployeeModel()
            {
                Name = name,
                Age = 38,
                Country = "Aus",
                Gender = "Male",
                Salary = 19000,
                Email = "smith@mailinator.com"
            };

            _employeeRepoMock.Setup(x => x.AddEmployee(employee)).Returns(employeeId);

            //Act
            var actualResult = _employeeRepository.AddEmployee(employee);

            //Assert
            Assert.Equal(employeeId, actualResult);
        }

        [Fact]
        public void UpdateEmployee_ShouldWhenEmployeeIdExist()
        {
            //Arrange
            var employeeId = 3;
            var name = "Smith";

            EmployeeModel employee = new EmployeeModel()
            {
                Id = employeeId,
                Name = name,
                Age = 38,
                Country = "Aus",
                Gender = "Male",
                Salary = 19000,
                Email = "smith@mailinator.com"
            };

            _employeeRepoMock.Setup(x => x.UpdateEmployee(employeeId,name)).Returns(employeeId);

            //Act
            var actualResult = _employeeRepository.UpdateEmployee(employeeId,name);

            //Assert
            Assert.Equal(employeeId, actualResult);
        }

        [Fact]
        public void DeleteEmployee_ShouldWhenEmployeeIdExist()
        {
            //Arrange
            var employeeId = 3;
            var name = "Smith";

            EmployeeModel employee = new EmployeeModel()
            {
                Id = employeeId,
                Name = name,
                Age = 38,
                Country = "Aus",
                Gender = "Male",
                Salary = 19000,
                Email = "smith@mailinator.com"
            };

            _employeeRepoMock.Setup(x => x.DeleteEmployee(employeeId)).Returns(employeeId);

            //Act
            var actualResult = _employeeRepository.DeleteEmployee(employeeId);

            //Assert
            Assert.Equal(employeeId, employeeId);
        }

        private List<EmployeeModel> EmployeeDataSource()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>()
            {
                new EmployeeModel()
                {
                    Id = 1,
                    Name = "Ketty",
                    Age = 32,
                    Country = "Aus",
                    Gender = "Female",
                    Salary = 25000,
                    Email = "ketty@gmail.com"
                },
                new EmployeeModel()
                {
                    Id = 2,
                    Name = "Todd",
                    Age = 28,
                    Country = "China",
                    Gender = "Male",
                    Salary = 17000,
                    Email = "todd@yahoo.com"
                },
                new EmployeeModel()
                {
                    Id = 3,
                    Name = "Smith",
                    Age = 38,
                    Country = "Aus",
                    Gender = "Male",
                    Salary = 19000,
                    Email = "smith@mailinator.com"
                },
                new EmployeeModel()
                {
                    Id = 4,
                    Name = "Abhi",
                    Age = 30,
                    Country = "India",
                    Gender = "Male",
                    Salary = 29000,
                    Email = "abhi@mailinator.com"
                },
                new EmployeeModel()
                {
                    Id = 6,
                    Name = "Mohan",
                    Age = 31,
                    Country = "India",
                    Gender = "Male",
                    Salary = 19000,
                    Email = "mohan@gmail.com"
                },
            };
            return employees;
        }
    }
}
