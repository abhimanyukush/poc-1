using BusinessAccessLayer.Repository;
using Common.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace POC_Abhi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetAllEmployee()
        {
            _logger.LogInformation("EmployeeController.GetAllEmployee method called!!!");
            return Ok(_employeeRepository.GetAllEmployee());
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetEmployeeById(int id)
        {
            _logger.LogInformation("EmployeeController.GetEmployeeById method called!!!");
            return Ok(_employeeRepository.GetEmployee(id));
        }

        [HttpGet("{id}/{name}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetEmployeeByIdAndName(int id,string name)
        {
            _logger.LogInformation("EmployeeController.GetEmployeeByIdAndName method called!!!");
            return Ok(_employeeRepository.GetEmployeeByIdAndName(id,name));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult PostEmployee(EmployeeModel model)
        {
            _logger.LogInformation("EmployeeController.PostEmployee method called!!!");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Model validation failed");
                return BadRequest();
            }
            _employeeRepository.AddEmployee(model);
            return StatusCode(StatusCodes.Status201Created, new { Message = $"Id: {model.Id} added successfully" });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult UpdateEmployee(int id, [FromBody]EmployeeModel model)
        {
            _logger.LogInformation("EmployeeController.UpdateEmployee method called!!!");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Model validation failed");
                return BadRequest();
            }

            _employeeRepository.UpdateEmployee(id, model.Name);
            
            return StatusCode(StatusCodes.Status204NoContent, new { Message = $"{model.Id} updated successfully" });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult DeleteEmployee(int id)
        {
            _logger.LogInformation("EmployeeController.DeleteEmployee method called!!!");
            _employeeRepository.DeleteEmployee(id);

            return StatusCode(StatusCodes.Status200OK, new { Message = $"{id} deleted successfully" });
        }
    }
}