using AdvancedApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedApp.Controllers
{
    public class DeleteController : Controller
    {
        private AdvancedContext context;
        public DeleteController(AdvancedContext _contex)
        {
            context = _contex;
        }
        public IActionResult Index()
        {
            return View(context.Employees.Where(e=>e.SoftDeleted).Include(c=>c.OtherIdentity).IgnoreQueryFilters());
        }
        [HttpPost]
        public IActionResult Restore(Employee employee)
        {
            context.Employees.IgnoreQueryFilters().FirstOrDefault(e=>e.SSN == employee.SSN && e.FirstName == employee.FirstName && e.FamilyName == employee.FamilyName).SoftDeleted = false;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            
            //if(employee.OtherIdentity != null)
            //{
            //    context.Remove(employee.OtherIdentity);
            //}
            context.Employees.Remove(employee);
            if (employee.OtherIdentity != null)
                {
                    context.Remove(employee.OtherIdentity);
                }
                context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult DeleteAll()
        {
            IEnumerable<Employee> data = context.Employees.Include(c => c.OtherIdentity).IgnoreQueryFilters().Where(e => e.SoftDeleted);
            context.RemoveRange(data.Select(c=>c.OtherIdentity));
            context.RemoveRange(data);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
