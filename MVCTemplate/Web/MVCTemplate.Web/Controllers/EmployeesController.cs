namespace MVCTemplate.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Data.Common;
    using Data.Models;

    using Infrastructure.Mapping;

    using ViewModels.Employees;
    using Data;
    [Authorize(Roles ="Admin")]
    public class EmployeesController : BaseController
    {
        private readonly IDbRepository<Employee> employee;
        private ApplicationUserManager userManager;

        public EmployeesController(IDbRepository<Employee> employee)
        {
            this.employee = employee;
        }


        // GET: Employees
        public ActionResult Index()
        {
            var model = this.employee.All()
                .To<EmployeeViewModel>()
                .ToList();

            return View(model);
        }

        // GET: Employees/Create
        [HttpGet]
        public ActionResult Create()
        {
            var model = new CreateEmployeeViewModel();

            return this.View(model);
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = new ApplicationUser() {
                Email = model.Email,
                UserName = model.Email,
                PhoneNumber = model.PhoneNumber,
            };
            this.userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var result = this.userManager.Create(user, model.Password);

            if (result.Succeeded)
            {
                var newEmployee = this.Mapper.Map<Employee>(model);
                newEmployee.UserId = user.Id;

                this.employee.Add(newEmployee);

                this.employee.Save();

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Registration fail. Try again.");
            }

            return this.View(model);
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                userManager = value;
            }
        }

        // GET: Employee/Info/id
        public ActionResult Info(int id)
        {
            var employee = this.employee.GetById(id);
            var user = this.UserManager.FindById(employee.UserId);

            var model = this.Mapper.Map<EmployeeInfoViewModel>(employee);
            model.Email = user.Email;
            model.PhoneNumber = user.PhoneNumber;

            return this.View(model);
        }
    }
}