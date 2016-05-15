namespace MVCTemplate.Web.Areas.Employee.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Data.Common;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Infrastructure.Mapping;
    using Infrastructure;
    using Web.Controllers;
    using ViewModels.Employee;

    [Authorize(Roles = "Employee")]
    public class ReportsController : BaseController
    {
        private readonly IDbRepository<WorkReport> workReports;
        private readonly IDbRepository<Employee> employees;

        public ReportsController(IDbRepository<WorkReport> workReports,
            IDbRepository<Employee> employees)
        {
            this.workReports = workReports;
            this.employees = employees;
        }

        // GET: Employee/Reports{/Index}
        public ActionResult Index()
        {
            var user = this.UserManager.FindById(this.User.Identity.GetUserId());

            var employee = this.employees.All()
                .First(e => e.UserId == user.Id);

            ViewBag.EmployeeName = employee.Name;

            var reports = this.workReports.All()
                .Where(wr => wr.EmployeeId == employee.Id)
                .OrderByDescending(wr  => wr.WeekNumber)
                .ThenBy(wr => wr.Date)
                .To<WorkReportViewModel>()
                .ToList();

            ViewBag.WeekSummury = WeekSummury.MakeWeekSummury(reports);

            return View(reports);
        }

        // GET: Employee/Reports/Create
        [HttpGet]
        public ActionResult Create()
        {
            var user = this.UserManager.FindById(this.User.Identity.GetUserId());

            var employee = this.employees.All()
                .First(e => e.UserId == user.Id);

            var model = new WorkReportViewModel()
            {
                EmployeeId = employee.Id
            };

            return this.View(model);
        }

        // POST: Employee/Reports/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkReportViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var report = this.Mapper.Map<WorkReport>(model);
            report.WeekNumber = DateTimeHelper.GetIso8601WeekOfYear(model.Date);

            this.workReports.Add(report);
            this.workReports.Save();

            return RedirectToAction("Index");
        }

        // GET: Employee/Reports/Update/Id
        [HttpGet]
        public ActionResult Update(int id)
        {
            var report = this.workReports.GetById(id);

            var model = this.Mapper.Map<WorkReportViewModel>(report);

            return this.View(model);
        }

        // POST: Employee/Reports/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(WorkReportViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var report = this.workReports.GetById(model.Id);
            report.Date = model.Date;
            report.PostCode = model.PostCode;
            report.Address = model.Address;
            report.KitchenName = model.KitchenName;
            report.Plot = model.Plot;
            report.WorkType = model.WorkType;
            report.Price = model.Price;
            report.Note = model.Note;
            report.WeekNumber = DateTimeHelper.GetIso8601WeekOfYear(model.Date);

            this.workReports.Update(report);
            this.workReports.Save();

            return RedirectToAction("Index");
        }
    }
}