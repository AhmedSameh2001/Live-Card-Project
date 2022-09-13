using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiveCards.Web.Areas.Vendor.Controllers
{

    [Area("Vendor")]
    [Authorize(Roles = "Agent")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
