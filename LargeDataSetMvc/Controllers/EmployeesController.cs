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

        //public ActionResult Employees_Read([DataSourceRequest] DataSourceRequest request)
        //{
        //    string logSnippet = "[EmployeeController][Employees_Read] =>";

        //    IList<CurrentEmployee> currentEmployees = _dbContext.CurrentEmployees.ToList();
        //    Console.WriteLine($"{logSnippet} (currentEmployees.Count): {currentEmployees.Count}");

        //    var dsResult = currentEmployees.ToDataSourceResult(request);
        //    return Json(dsResult);
        //}

        public ActionResult Employees_Read([DataSourceRequest] DataSourceRequest request)
        {
            string logSnippet = "[EmployeeController][Employees_Read] =>";
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine($"{logSnippet} (request.Take)....: '{request.Take}'");
            Console.WriteLine($"{logSnippet} (request.Skip)....: '{request.Skip}'");
            Console.WriteLine($"{logSnippet} (request.Page)....: '{request.Page}'");
            Console.WriteLine($"{logSnippet} (request.PageSize): '{request.PageSize}'");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine();


            IList<CurrentEmployee> currentEmployees = _dbContext.CurrentEmployees.ToList();
            Console.WriteLine($"{logSnippet} (currentEmployees.Count): {currentEmployees.Count}");

            var dsResult = currentEmployees.ToDataSourceResult(request);
            return Json(dsResult);
        }
    }
}
