using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineMovieStore.Services.Contracts;
using OnlineMovieStore.Web.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using OnlineMovieStore.Models.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Mvc;

namespace OnlineMovieStore.Web.Tests.HomeControllerTests
{
    [TestClass]
    public class HomeController_Should
    {
        [TestMethod]
        public void IndexAction_ReturnsViewResult()
        {
            var postsServiceMock = this.SetupMockService();
            var cacheMock = new Mock<IMemoryCache>();
            var controller = new HomeController(postsServiceMock.Object, cacheMock.Object);

            var result = controller.Index();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }


        private Mock<IMoviesService> SetupMockService()
        {
            var moviesServiceMock = new Mock<IMoviesService>();
            moviesServiceMock
                .Setup(ms => ms.ListMoviesByHigherPrice(It.IsAny<int>()))
                .Returns(new List<Movie>());

            return moviesServiceMock;
        }

    }
}
