using Microsoft.AspNetCore.Mvc;

namespace LargeDataSetMvc.Controllers
{
    public class EmployeesContoller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
