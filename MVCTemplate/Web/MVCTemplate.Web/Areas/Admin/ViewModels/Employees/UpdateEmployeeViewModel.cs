namespace MVCTemplate.Web.Areas.Admin.ViewModels.Employees
{
    using System.ComponentModel.DataAnnotations;

    using Data.Models.Types;
    using Data.Models;
    using Infrastructure.Mapping;

    public class UpdateEmployeeViewModel : IMapFrom<Employee>, IMapTo<Employee>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        // Bank details

        [Required]
        public BankName BankName { get; set; }

        [Required]
        public string SortCode { get; set; }

        [Required]
        public string Account { get; set; }
    }
}
