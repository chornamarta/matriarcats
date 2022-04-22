using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public ActionResult Index()
        {
            return Content("Hello");
        }
    }
}