using AOWebApp2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace AOWebApp2.Controllers
{
    public class ReportsController : Controller
    {
        private readonly AmazonOrdersDb2025Context _context;

        public ReportsController(AmazonOrdersDb2025Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var years = (from i in _context.CustomerOrders
                        select i.OrderDate.Year)
                        .Distinct()
                        .OrderByDescending(i => i)
                        .ToList();

            return View("AnnualSalesReport", new SelectList(years));
        }

        public IActionResult AnnualSalesReportData(int Year)
        {if (Year > 0)
            {
                var ItemsSold = _context.ItemsInOrders.
                Where(i => i.OrderNumberNavigation.OrderDate.Year == Year)
                .GroupBy(i => new { i.OrderNumberNavigation.OrderDate.Year, i.OrderNumberNavigation.OrderDate.Month })
                .Select(i => new
                {
                    year = i.Key.Year,
                    monthNo = i.Key.Month,
                    monthName = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i.Key.Month),
                    totalItems = i.Sum(i => i.NumberOf),
                    totalSales = i.Sum(i => i.TotalItemCost)

                })
                .OrderBy(i => i.monthNo)
                .ToList();

                return Json(ItemsSold);
            }
        else
            {
                return BadRequest();
            }
        }
    }
}
