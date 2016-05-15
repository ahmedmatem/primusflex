namespace MVCTemplate.Web.Areas.Admin.ViewModels.Employees
{
    using Infrastructure.Mapping;
    using MVCTemplate.Data.Models.Types;
    using Data.Models;

    public class EmployeeInfoViewModel : IMapFrom<Employee>
    {
        public string Name { get; set; }
        
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        // Bank details
        
        public BankName BankName { get; set; }
        
        public string SortCode { get; set; }
        
        public string Account { get; set; }
    }
}
