using Microsoft.AspNetCore.Mvc;

namespace ProgrammersBLog.Mvc.Areas.Admin.Controllers
{
    [Area(areaName:"Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
