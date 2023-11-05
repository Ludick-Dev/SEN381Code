using CallCenter.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CallCenter.Models;
using System.Text.Json;
using System.Collections.Generic; 

namespace CallCenter.Controllers
{
    public class AdminController : Controller
    {
        private readonly EmployeeRepository _employeeRepository;

        public AdminController(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET: /Admin/AdminEmployees
        public async Task<IActionResult> AdminEmployees()
        {
            var employees = await _employeeRepository.GetAllEmployees();
            List<Employee> employeeList = JsonSerializer.Deserialize<List<Employee>>(employees);
            ViewData["Employees"] = employees; // Passing employees to ViewData
            return View();
        }
        
        // GET: /Admin/AdminRequestLogs
        public IActionResult AdminRequestLogs()
        {
            // Your logic for AdminRequestLogs
            return View();
        }
    }
}
