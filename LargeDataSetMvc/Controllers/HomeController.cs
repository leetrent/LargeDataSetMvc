using LargeDataSetMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LargeDataSetMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Employees()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
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

        public IActionResult Error()
        {
            return View();
        }
    }
}
