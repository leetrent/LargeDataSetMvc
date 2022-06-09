using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using LargeDataSetMvc.Model;
using LargeDataSetMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LargeDataSetMvc.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeContext _dbContext;

        public EmployeesController(EmployeeContext dbc)
        {
            _dbContext = dbc;
        }

        public ActionResult Employees_Read([DataSourceRequest] DataSourceRequest request)
        {
            string logSnippet = "[EmployeeController][Employees_Read] =>";

            Console.WriteLine($"{logSnippet} (_dbContext == null): {_dbContext == null}");

            this.test();

            var result = Enumerable.Range(0, 50).Select(i => new OrderViewModel
            {
                OrderID = i,
                Freight = i * 10,
                OrderDate = new DateTime(2016, 9, 15).AddDays(i % 7),
                ShipName = "ShipName " + i,
                ShipCity = "ShipCity " + i
            });

            var dsResult = result.ToDataSourceResult(request);
            return Json(dsResult);
        }

        private void test()
        {
            string logSnippet = "[EmployeeController][test] =>";

            IList<CurrentEmployee> currentEmployees = _dbContext.CurrentEmployees.ToList();
            Console.WriteLine($"{logSnippet} (currentEmployees.Count): {currentEmployees.Count}");
        }
    }
}
