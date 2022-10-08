using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWithADO.DataAccess;
using CoreWithADO.Models;
using Microsoft.AspNetCore.Authorization;

namespace CoreWithADO.Controllers
{
    [Authorize]
    public class EmplooyeeController : Controller
    {
        EmployeeAccessDb db = new EmployeeAccessDb();

        public IActionResult Index()
        {
            var emps = db.GetEmployees();
            return View(emps);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employees emp)
        {
            db.CreateEmployee(emp);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var data = db.GetEmployee(id);
            return View(data);
        }
        
        [HttpPost]
        public IActionResult Update(Employees emp)
        {
            db.UpdateEmployee(emp);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
           db.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

    }
}
