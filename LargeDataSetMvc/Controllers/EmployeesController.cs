using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using LargeDataSetMvc.Model;
using LargeDataSetMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LargeDataSetMvc.Utils;

namespace LargeDataSetMvc.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeContext _dbContext;

        public EmployeesController(EmployeeContext dbc)
        {
            _dbContext = dbc;
        }

        public ActionResult Paging()
        {
            return View(new PagerViewModel());
        }

        [HttpPost]
        public ActionResult Paging(PagerViewModel pager)
        {
            return View(pager);
        }

        public ActionResult Employees_Read([DataSourceRequest] DataSourceRequest request)
        {
            //string title = "Senior Engineer";

            IList<CurrentEmployee> currentEmployees = _dbContext.CurrentEmployees.ToList();

            //IList<CurrentEmployee> currentEmployees = _dbContext.CurrentEmployees.Where(e => e.Title == title).ToList();

            var dsResult = currentEmployees.ToDataSourceResult(request);
            return Json(dsResult);
        }

    }
}
