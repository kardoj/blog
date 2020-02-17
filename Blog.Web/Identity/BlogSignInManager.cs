using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Blog.Web.Identity
{
    // This is needed to mock SignInManager
    public interface IBlogSignInManager<TUser> where TUser : User
    {
        Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);
        Task SignOutAsync();
    }

    public class BlogSignInManager<TUser> : IBlogSignInManager<TUser> where TUser : User
    {
        private readonly SignInManager<User> _signInManager;

        public BlogSignInManager(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            return _signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
        }

        public Task SignOutAsync()
        {
            return _signInManager.SignOutAsync();
        }
    }
}
