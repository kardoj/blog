using Blog.Web.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web.TestData
{
    public class TestUserSeed
    {
        private readonly UserManager<User> _userManager;

        public TestUserSeed(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task Seed()
        {
            if (_userManager.Users.Any())
            {
                return;
            }

            await _userManager.CreateAsync(new User("testuser", "test.user@ema.il"), "Password123!");
        }
    }
}
