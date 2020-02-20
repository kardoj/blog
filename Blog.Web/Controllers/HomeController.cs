using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Blog.Web.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;

        public HomeController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByEmailAsync("test.user@ema.il");
            ViewBag.TestUser = user;
            return View();
        }
    }
}
