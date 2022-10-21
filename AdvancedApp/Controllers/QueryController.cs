using AdvancedApp.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
namespace AdvancedApp.Controllers
{
    public class QueryController  : Controller
    {
        private AdvancedContext context;
        public QueryController(AdvancedContext _context)
        {
            context = _context;
        }
        public IActionResult ServerEval()
        {
            return View("Query", context.Employees.Where(c=>c.Salary > 150));
        }
        public IActionResult ClientEval()
        {
            return View("Query", context.Employees.Where(c=> HighSalary(c)).AsQueryable());
        }
        private bool HighSalary(Employee employee)
        {
            return employee.Salary > 150_000;
        }
    }
}
