namespace MVCTemplate.Web.Areas.Admin.ViewModels.Employees
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Data.Models.Types;
    using Data.Models;
    
    using Infrastructure.Mapping;

    public class EmployeeViewModel : IMapFrom<Employee>, IMapTo<Employee>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
