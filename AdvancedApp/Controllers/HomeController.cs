using Microsoft.AspNetCore.Mvc;
using AdvancedApp.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.Net.Http;
using System.Net.Http;
using System;

namespace AdvancedApp.Controllers
{
    public class HomeController : Controller
    {
        private AdvancedContext context;
        public HomeController(AdvancedContext context)
        {
            this.context = context;
        }
       // private static Func<AdvancedContext, string, IEnumerable<Employee>> query = EF.CompileQuery((AdvancedContext context, string searchTerm) =>
        //context.Employees.Where(e => EF.Functions.Like(e.FirstName, searchTerm)));
        public IActionResult Index(string searchTerm)
        {
            // IQueryable<Employee> data = context.Employees;
            //  if (!string.IsNullOrEmpty(searchTerm))
            //  {
            //   data = data.Where(e => EF.Functions.Like(e.FirstName, searchTerm));
            //  }
            //  HttpClient client = new HttpClient();
            //  ViewBag.PageSize = (await client.GetAsync("http://apress.com")).Content.Headers.ContentLength;
           
            IEnumerable<Employee> data = context.Employees.Include(c => c.OtherIdentity).OrderByDescending(c=>c.LastUpdated).IgnoreQueryFilters();


            ViewBag.Secondaries = data.Select(c=>c.OtherIdentity);
            return View((!string.IsNullOrEmpty(searchTerm)) ?   data.Where(e => e.FirstName.ToLower().Contains(searchTerm.ToLower()) || e.FamilyName.ToLower().Contains(searchTerm.ToLower())).ToList() 
                : data.ToArray());
        }
        public IActionResult Edit(string SSN, string firstName, string familyName)
        {
          
            return View(string.IsNullOrEmpty(SSN) ? new Employee() : context.Employees.Include(c => c.OtherIdentity)
                .First(x => x.SSN == SSN && x.FirstName == firstName && x.FamilyName == familyName )) ;
  
        }
        [HttpPost]
        public IActionResult Update(Employee emp)
        {
             if (context.Employees.Count(c=>c.SSN == emp.SSN && c.FirstName == emp.FirstName && c.FamilyName == emp.FamilyName) == 0)
            {
                context.Add(emp);
            }
            else
            {
               // context.Entry(existing).State = EntityState.Detached;
               Employee e = new Employee { SSN = emp.SSN, FirstName = emp.FirstName, FamilyName = emp.FamilyName};
                context.Employees.Attach(e);
                e.Salary = emp.Salary;
              e.LastUpdated = DateTime.Now;
                //context.Update(emp);   
            }
           
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            context.Employees.Attach(employee);
            employee.SoftDeleted = true;
            //   context.Set<SecondaryIdentity>().FirstOrDefault(id=>id.PrimarySSN == employee.SSN && id.PrimaryFirstName == employee.FirstName &&
            // id.PrimaryFamilyName == employee.FamilyName);
                            //if (employee.OtherIdentity != null)
                            //{
                            //   SecondaryIdentity identity =  context.Set<SecondaryIdentity>().Find(employee.OtherIdentity.Id);
                            //    identity.PrimarySSN = null;
                            //    identity.PrimaryFirstName = null;
                            //    identity.PrimaryFamilyName = null;
                            //}
                            //employee.OtherIdentity = null;
                     // context.Employees.Remove(employee);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));


        }
    }
}
