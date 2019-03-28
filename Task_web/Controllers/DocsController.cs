using Microsoft.AspNetCore.Mvc;

namespace Task_web.Controllers
{
    public class DocsController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("swagger");
        }
    }
}