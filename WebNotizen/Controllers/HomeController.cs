using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebNotizen.Models;

namespace WebNotizen.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
