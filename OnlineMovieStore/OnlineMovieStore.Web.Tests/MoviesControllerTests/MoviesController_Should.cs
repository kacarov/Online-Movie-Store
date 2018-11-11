using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineMovieStore.Models.Models;
using OnlineMovieStore.Services.Contracts;
using OnlineMovieStore.Web.Controllers;
using OnlineMovieStore.Web.Models;
using System;
using System.Collections.Generic;

namespace OnlineMovieStore.Web.Tests.MoviesControllerTests
{
    [TestClass]
    public class MoviesController_Should
    {
        [TestMethod]
        public void IndexAction_ReturnsViewResult()
        {
            var moviesService = this.SetupMockMoviesService();
            var usersService = this.SetupMockUsersService();
            var mockUserManager = this.SetupMockUserManager();
            var viewModelMock = new Mock<MovieSearchViewModel>();

         /*   viewModelMock
                .SetupGet(vm => vm.SearchText)
                .Returns(It.IsAny<string>());*/
            var controller = new MoviesController(moviesService.Object, mockUserManager.Object, usersService.Object);
            

            var result = controller.Index(viewModelMock.Object);

            Assert.IsInstanceOfType(result, typeof(ViewResult));

        }

        private Mock<IUsersService> SetupMockUsersService()
        {
            var usersServiceMock = new Mock<IUsersService>();


            return usersServiceMock;
        }

        private Mock<IMoviesService> SetupMockMoviesService()
        {
            var moviesServiceMock = new Mock<IMoviesService>();
            moviesServiceMock
                .Setup(ms => ms.ListAllMovies(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new List<Movie>());

            moviesServiceMock
                .Setup(ms => ms.ListByContainingText(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new List<Movie>());

            moviesServiceMock
                .Setup(ms => ms.Total())
                .Returns(It.IsAny<int>());

            moviesServiceMock
                .Setup(ms => ms.Total())
                .Returns(It.IsAny<int>());

            moviesServiceMock
                .Setup(ms => ms.TotalContainingText(It.IsAny<string>()))
                .Returns(It.IsAny<int>());

            return moviesServiceMock;
        }

        private Mock<UserManager<ApplicationUser>> SetupMockUserManager()
        {
           return new Mock<UserManager<ApplicationUser>>(
                    new Mock<IUserStore<ApplicationUser>>().Object,
                    new Mock<IOptions<IdentityOptions>>().Object,
                    new Mock<IPasswordHasher<ApplicationUser>>().Object,
                    new IUserValidator<ApplicationUser>[0],
                    new IPasswordValidator<ApplicationUser>[0],
                    new Mock<ILookupNormalizer>().Object,
                    new Mock<IdentityErrorDescriber>().Object,
                    new Mock<IServiceProvider>().Object,
                    new Mock<ILogger<UserManager<ApplicationUser>>>().Object);
        }
    }
}
