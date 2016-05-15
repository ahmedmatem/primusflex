namespace MVCTemplate.Web.Areas.Employee.ViewModels.Employee
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;
    using MVCTemplate.Data.Models.Types;

    public class WorkReportViewModel : IMapFrom<WorkReport>, IMapTo<WorkReport>
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public DateTime Date { get; set; }

        public int WeekNumber { get; set; }

        [Display(Name = "Post Code")]
        public string PostCode { get; set; }

        public string Address { get; set; }

        [Display(Name = "Kitchcen")]
        public KitchenName KitchenName { get; set; }

        public string Plot { get; set; }

        [Display(Name = "Work Type")]
        public WorkType WorkType { get; set; }
        
        public decimal Price { get; set; }

        public string Note { get; set; }
    }
}
