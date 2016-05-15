using System.Collections.Generic;

namespace MVCTemplate.Web.Areas.Employee.ViewModels.Employee
{
    public class WeekSummury
    {
        public decimal TotalPrice { get; set; }

        public decimal TotalPriceLess20prc { get; set; }

        public static Dictionary<int, WeekSummury> MakeWeekSummury(List<WorkReportViewModel> reports)
        {
            Dictionary<int, WeekSummury> weekSummury = new Dictionary<int, WeekSummury>();
            decimal totalPrice = 0;
            int currentWeekNumber = -1;

            foreach (var report in reports)
            {
                if (report.WeekNumber != currentWeekNumber)
                {
                    weekSummury.Add(currentWeekNumber, new WeekSummury() {
                        TotalPrice = totalPrice,
                        TotalPriceLess20prc = (decimal)(0.8 * (double)totalPrice)
                    });
                    currentWeekNumber = report.WeekNumber;
                    totalPrice = report.Price;
                }
                else
                {
                    totalPrice += report.Price;
                }
            }
            weekSummury.Add(currentWeekNumber, new WeekSummury() {
                TotalPrice = totalPrice,
                TotalPriceLess20prc = (decimal)(0.8 * (double)totalPrice)
            });

            return weekSummury;
        }
    }
}
