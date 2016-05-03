namespace MVCTemplate.Data.Models
{
    using MVCTemplate.Data.Common.Models;
    using System.ComponentModel.DataAnnotations.Schema;
    using Types;

    public class WorkReport : BaseModel<int>
    {
        public int EmployeeId { get; set; }

        public string PostCode { get; set; }

        public string Address { get; set; }

        public KitchenName KitchenName { get; set; }

        public string Plot { get; set; }

        public WorkType WorkType { get; set; }

        public decimal Price { get; set; }

        public string Note { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
