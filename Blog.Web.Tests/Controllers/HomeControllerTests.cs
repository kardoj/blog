using Blog.Web.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Authorization;
using NUnit.Framework;

namespace Blog.Web.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void Controller_Is_Authorized()
        {
            typeof(HomeController).GetCustomAttributes(true).Should().Contain(a => a is AuthorizeAttribute);
        }
    }
}
