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

            IList<CurrentEmployee> currentEmployees = _dbContext.CurrentEmployees.ToList();
            var dsResult = currentEmployees.ToDataSourceResult(request);
            return Json(dsResult);
        }
    }
}
