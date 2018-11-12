using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineMovieStore.Models.Models;
using OnlineMovieStore.Services.Contracts;
using OnlineMovieStore.Web.Areas.UserManagment.Controllers;
using OnlineMovieStore.Web.Areas.UserManagment.Models;
using OnlineMovieStore.Web.Tests.UserManagmentControllerTests.Fakes;
using System.Collections.Generic;
using System.Security.Claims;

namespace OnlineMovieStore.Web.Tests.UserManagmentControllerTests
{
    [TestClass]
    public class UserController_Should
    {
        [TestMethod]
        public void IndexAction_ReturnsViewResult()
        {
            var userServiceMock = this.SetupMockUsersService();
            var userManagerFake = new FakeUserManager();
            var userSignInFake = new FakeSignInManager();

            var viewModelMock = new Mock<UserViewModel>();
            var controller = new UserController(userServiceMock.Object, userManagerFake, userSignInFake);

            var result = controller.Index();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void RequestMovieAction_ReturnsViewResult()
        {
            var userServiceMock = this.SetupMockUsersService();
            var userManagerFake = new FakeUserManager();
            var userSignInFake = new FakeSignInManager();

            var viewModelMock = new Mock<UserViewModel>();
            var controller = new UserController(userServiceMock.Object, userManagerFake, userSignInFake);

            var result = controller.RequestMovie();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void HelpAction_ReturnsViewResult()
        {
            var userServiceMock = this.SetupMockUsersService();
            var userManagerFake = new FakeUserManager();
            var userSignInFake = new FakeSignInManager();

            var viewModelMock = new Mock<UserViewModel>();
            var controller = new UserController(userServiceMock.Object, userManagerFake, userSignInFake);

            var result = controller.Help();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void MyMoviesAction_ReturnsViewResult()
        {
            var userServiceMock = this.SetupMockUsersService();
            var userManagerFake = new FakeUserManager();
            var userSignInFake = new FakeSignInManager();

            var viewModelMock = new Mock<UserMoviesViewModel>();
            var controller = new UserController(userServiceMock.Object, userManagerFake, userSignInFake);

            var result = controller.MyMovies(It.IsAny<string>()) as ViewResult;

            Assert.IsInstanceOfType(result.Model, typeof(UserMoviesViewModel));
        }

        [TestMethod]
        public void OrdersDetailsAction_ReturnsViewResult()
        {
            var userServiceMock = this.SetupMockUsersService();
            var userManagerFake = new Mock<FakeUserManager>();

            var claimPrincipleMock = new Mock<ClaimsPrincipal>();
            userManagerFake.Setup(um => um.GetUserId(claimPrincipleMock.Object));

            var userSignInFake = new FakeSignInManager();

            var viewModelMock = new Mock<UserOrdersViewModel>();
            var controller = new UserController(userServiceMock.Object, userManagerFake.Object, userSignInFake);

            var result = controller.OrdersDetails() as ViewResult;

            Assert.IsInstanceOfType(result.Model, typeof(UserOrdersViewModel));
        }

        [TestMethod]
        public void DepositGetAction_ReturnsViewResult()
        {
            var userServiceMock = this.SetupMockUsersService();
            var userManagerFake = new Mock<FakeUserManager>();

            var claimPrincipleMock = new Mock<ClaimsPrincipal>();
            userManagerFake.Setup(um => um.GetUserId(claimPrincipleMock.Object));

            var userSignInFake = new FakeSignInManager();

            var viewModelMock = new Mock<UserDepositViewModel>();
            var controller = new UserController(userServiceMock.Object, userManagerFake.Object, userSignInFake);

            var result = controller.Deposit(It.IsAny<string>()) as ViewResult;

            Assert.IsInstanceOfType(result.Model, typeof(UserDepositViewModel));
        }

        [TestMethod]
        public void AccountSettingsGetAction_ReturnsViewResult()
        {
            var userServiceMock = this.SetupMockUsersService();
            var userManagerFake = new Mock<FakeUserManager>();

            var claimPrincipleMock = new Mock<ClaimsPrincipal>();
            userManagerFake.Setup(um => um.GetUserId(claimPrincipleMock.Object));

            var userSignInFake = new FakeSignInManager();

            var viewModelMock = new Mock<UserViewModel>();
            var controller = new UserController(userServiceMock.Object, userManagerFake.Object, userSignInFake);

            var result = controller.AccountSettings() as ViewResult;

            Assert.IsInstanceOfType(result.Model, typeof(UserViewModel));
        }

        /// <summary>
        /// Returns IUserService Mock
        /// </summary>
        private Mock<IUsersService> SetupMockUsersService()
        {
            var usersServiceMock = new Mock<IUsersService>();
            var applicationUserMock = new Mock<ApplicationUser>();

            usersServiceMock
               .Setup(ms => ms.Orders(It.IsAny<string>()))
               .Returns(new List<Movie>());

            usersServiceMock
                .Setup(id => id.OrdersDetails(It.IsAny<string>()))
                .Returns(new List<Movie>());

            usersServiceMock
               .Setup(id => id.GetUser(It.IsAny<string>()))
               .Returns(applicationUserMock.Object);

            return usersServiceMock;
        }
    }
}