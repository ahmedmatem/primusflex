namespace MVCTemplate.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Data.Common;
    using Data.Models;

    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly IDbRepository<Employee> employee;

        public EmployeesController(IDbRepository<Employee> employee)
        {
            this.employee = employee;
        }
        // GET: Employees
        public ActionResult Index()
        {
            return View();
        }
    }
}