
using EmployeeApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        public Employee[] EmployeeList { get; set; }

        private readonly ILogger<EmployeesController> _logger;
        private readonly EmployeeRepository _employeeRepository;

        public EmployeesController(ILogger<EmployeesController> logger, 
        EmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository; // Resolve
        }


        [HttpGet] // localhost/api/employees [resource]
        public IActionResult GetAllEmployees()
        {
            _logger.LogInformation("GetAllEmployees has been called.");
            return Ok(_employeeRepository.EmployeeList);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneEmployee(int id)
        {
            _logger.LogInformation($"GetOneEmployee with {id} has been called.");
            var result = _employeeRepository.GetOne(id);
            return result!= null?Ok(result):NotFound();
        }


        [HttpPost] // localhost/api/employees [resource]
        public IActionResult CreateOneEmployee(Employee employee)
        {
            _logger.LogInformation($"CreateOneEmployee has been called.");
            var result = _employeeRepository.Add(employee);
            return result == 0?BadRequest("Employee already in the List!"):Ok("Add operation successful!");
                    }

        [HttpPut("{id:int}")] // localhost/api/employees/{id} [resource]
        public IActionResult UpdateOneEmployee(int id, Employee employee)
        {
            _logger.LogInformation($"UpdateOneEmployee with {id} has been called.");
           var result =  _employeeRepository.UpdateOne(id,employee);
           return result ==1?Ok("Update operation is succesfull!"):NotFound("The Employee IS Not Found!!!");//BadRequest("The Employee IS Not Found!!!");=>400, NotFound => 404
        }

        [HttpDelete("{id:int}")] // localhost/api/employees/{id} [resource]
        public IActionResult DeleteOneEmployee(int id, Employee employee)
        {
            _logger.LogInformation($"DeleteOneEmployee with {id} has been called.");
           var result =  _employeeRepository.DeleteOne(id);
           return result ==1?Ok("Update operation is succesfull!"):NotFound("The Employee IS Not Found!!!");//BadRequest("The Employee IS Not Found!!!");=>400, NotFound => 404
        }
    }
}