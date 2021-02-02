using BusinessAccessLayer.Repository;
using DataAccessLayer.Model;
using DataAccessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace POC_Abhi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            var result = _employeeRepository.GetAllEmployee();

            return StatusCode(StatusCodes.Status200OK, result);

        }
        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var result = _employeeRepository.GetEmployee(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPost]
        public IActionResult PostEmployee(EmployeeModel model)
        {
            if(TryValidateModel(model))
            {
                _employeeRepository.AddEmployee(model);
            }            

            return StatusCode(StatusCodes.Status201Created, new { Message = $"Id: {model.Id} added successfully" });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id,[FromBody]EmployeeModel model)
        {
            if (TryValidateModel(model))
                _employeeRepository.UpdateEmployee(id, model.Name);

            return StatusCode(StatusCodes.Status204NoContent, new { Message = $"{model.Id} updated successfully" });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployee(id);

            return StatusCode(StatusCodes.Status200OK, new { Message = $"{id} deleted successfully" });
        }
    }
}