using Blog.Web.Identity;
using Blog.Web.Models.Account;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IBlogSignInManager<User> _signInManager;

        public AccountController(IBlogSignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var signInResult = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("InvalidEmailAndOrPassword", "Invalid e-mail and/or password!");
                return View(model);
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}