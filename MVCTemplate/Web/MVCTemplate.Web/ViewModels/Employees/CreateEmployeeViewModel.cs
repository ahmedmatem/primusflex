namespace MVCTemplate.Web.ViewModels.Employees
{
    using System.ComponentModel.DataAnnotations;

    using Infrastructure.Mapping;

    using Data.Models.Types;
    using Data.Models;

    public class CreateEmployeeViewModel : IMapFrom<Employee>, IMapTo<Employee>
    {
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        public string PhoneNumber { get; set; }

        public Group Group { get; set; }

        // Bank details

        [Required]
        public BankName BankName { get; set; }

        [Required]
        public string SortCode { get; set; }

        [Required]
        public string Account { get; set; }
    }
}
