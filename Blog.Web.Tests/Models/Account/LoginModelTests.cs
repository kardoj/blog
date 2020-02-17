using Blog.Web.Models.Account;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Tests.Models.Account
{
    [TestFixture]
    public class LoginModelTests : TestsBase
    {
        [Test]
        public void Email_Is_Required()
        {
            // Act & Assert
            ShouldHaveCustomAttribute<RequiredAttribute, LoginModel>(m => m.Email);
        }

        [Test]
        public void Password_Is_Required()
        {
            // Act & Assert
            ShouldHaveCustomAttribute<RequiredAttribute, LoginModel>(m => m.Password);
        }
    }
}
