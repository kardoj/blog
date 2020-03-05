using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class PrototypeController : Controller
    {
        public IActionResult LatestPosts()
        {
            return View();
        }

        public IActionResult NewPost()
        {
            return View();
        }
    }
}