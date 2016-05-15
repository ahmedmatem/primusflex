namespace MVCTemplate.Web.Areas.Admin.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Web.Controllers;
    using Data.Common;
    using Data.Models;
    using Data;

    using Infrastructure.Mapping;
    using ViewModels.Employees;

    [Authorize(Roles = "Admin")]
    public class EmployeesController : BaseController
    {
        private readonly IDbRepository<Employee> employee;

        public EmployeesController(IDbRepository<Employee> employee)
        {
            this.employee = employee;
        }


        // GET: Admin/Employees
        public ActionResult Index()
        {
            var model = this.employee.All()
                .To<EmployeeViewModel>()
                .ToList();

            return View(model);
        }

        // GET: Admin/Employees/Create
        [HttpGet]
        public ActionResult Create()
        {
            var model = new CreateEmployeeViewModel();

            return this.View(model);
        }

        // POST: Admin/Employees/Create
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

        // GET: Admin/Employees/Update/id
        [HttpGet]
        public ActionResult Update(int id)
        {
            var employee = this.employee.GetById(id);

            var model = this.Mapper.Map<UpdateEmployeeViewModel>(employee);

            return this.View(model);
        }

        // POST: Admin/Employees/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(UpdateEmployeeViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return this.View(model);
            }

            var employee = this.employee.GetById(model.Id);

            employee.Name = model.Name;
            employee.BankName = model.BankName;
            employee.SortCode = model.SortCode;
            employee.Account = model.Account;

            this.employee.Update(employee);
            this.employee.Save();

            return RedirectToAction("Index");
        }

        // GET: Admin/Employees/Delete/id
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var employee = this.employee.GetById(id);
            this.employee.Delete(employee);
            this.employee.Save();

            return RedirectToAction("Index");
        }

        // GET: Admin/Employee/Info/id
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