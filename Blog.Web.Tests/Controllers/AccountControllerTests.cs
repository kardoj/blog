using Blog.Web.Controllers;
using Blog.Web.Identity;
using Blog.Web.Models.Account;
using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Blog.Web.Tests.Controllers
{
    [TestFixture]
    public class AccountControllerTests
    {
        private Mock<IBlogSignInManager<User>> _signInManagerMock;
        private AccountController _sut;

        [SetUp]
        public void SetUp()
        {
            _signInManagerMock = new Mock<IBlogSignInManager<User>>();
            _sut = new AccountController(_signInManagerMock.Object);
        }

        [Test]
        public async Task Login_POST_Returns_View_With_Model_If_ModelState_Has_Errors()
        {
            var model = Builder<LoginModel>.CreateNew().Build();

            _sut.ModelState.AddModelError("ErrorKey", "ErrorMessage");

            // Act
            var result = (ViewResult)await _sut.Login(model);

            // Assert
            result.Model.Should().BeSameAs(model);
        }

        [Test]
        public async Task Login_POST_Returns_View_With_Model_And_General_Error_Message_If_Sign_In_Fails()
        {
            var model = Builder<LoginModel>.CreateNew().Build();

            _signInManagerMock.Setup(m => m.PasswordSignInAsync(model.Email, model.Password, false, false)).ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Failed);

            // Act
            var result = (ViewResult)await _sut.Login(model);

            // Assert
            result.Model.Should().BeSameAs(model);
            _sut.ModelState.Keys.Should().Contain(k => k == "InvalidEmailAndOrPassword");
            _sut.ModelState["InvalidEmailAndOrPassword"].Errors.Should().Contain(e => e.ErrorMessage == "Invalid e-mail and/or password!");
        }

        [Test]
        public async Task Login_POST_Logs_User_In_And_Redirects_To_Home()
        {
            var model = Builder<LoginModel>.CreateNew().Build();

            _signInManagerMock.Setup(m => m.PasswordSignInAsync(model.Email, model.Password, false, false)).ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);

            // Act
            var result = (RedirectToActionResult)await _sut.Login(model);

            // Assert
            result.ControllerName.Should().Be("Home");
            result.ActionName.Should().Be(nameof(HomeController.Index));
        }

        [Test]
        public async Task LogOff_Logs_User_Off_And_Redirects_To_Login()
        {
            // Act
            var result = (RedirectToActionResult)await _sut.LogOff();

            // Assert
            result.ActionName.Should().Be(nameof(AccountController.Login));
            _signInManagerMock.Verify(m => m.SignOutAsync(), Times.Once);
        }
    }
}
