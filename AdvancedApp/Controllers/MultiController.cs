using Microsoft.AspNetCore.Mvc;
using AdvancedApp.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace AdvancedApp.Controllers
{
    public class MultiController : Controller
    {
        private AdvancedContext context;
        private ILogger<MultiController> logger;
        public MultiController(AdvancedContext _context, ILogger<MultiController> _logger)
        {
            context = _context;
            logger = _logger;
        }
        public IActionResult Index()
        {
            return View("EditAll", context.Employees);
        }
        [HttpPost]
        public IActionResult UpdateAll(Employee[] employees)
        {
            //foreach (Employee e in employees)
            //{
            //    try
            //    {
            //        context.Update(e);
            //        context.SaveChanges();
            //    }
            //    catch (Exception)
            //    {
            //        context.Entry(e).State = EntityState.Detached;
            //    }
            //}
            context.Database.BeginTransaction();
            //Employee temp = new Employee()
            //{
            //    SSN = "000", FamilyName="(null)", FirstName = "(null)", Salary = 0
            //};
            //    context.UpdateRange(employees);
            //context.Add(temp);
                context.SaveChanges();
            Thread.Sleep(5000);
            //context.Remove(temp);
            if (context.Employees.Sum(c=>c.Salary) < 1_000_000)
            {
                context.Database.CommitTransaction();
            }
            else
            {
                context.Database.RollbackTransaction();
                throw new Exception("Transaction stopped");
            }
            return RedirectToAction(nameof(Index)); 
        }

        public string ReadTest()
        {
           decimal sum1 = context.Employees.Sum(c=>c.Salary);

            Thread.Sleep(5000);
            decimal sum2 = context.Employees.Sum(c => c.Salary);
            return $"first: {sum1}, second: {sum2}";
        }
    }
}
