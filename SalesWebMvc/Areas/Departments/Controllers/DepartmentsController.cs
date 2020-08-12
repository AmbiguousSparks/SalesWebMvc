using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Areas.Departments.Models;

namespace SalesWebMvc.Areas.Departments.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> departments = new List<Department>()
            {
                new Department()
                {
                    Id = 1,
                    Name = "Fashion"
                },
                new Department()
                {
                    Id = 2,
                    Name = "Technology"
                }
            };
            return View(departments);
        }
    }
}
