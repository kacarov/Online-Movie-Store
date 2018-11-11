using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineMovieStore.Services.Contracts;
using OnlineMovieStore.Web.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using OnlineMovieStore.Models.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Mvc;
using OnlineMovieStore.Web.Models;

namespace OnlineMovieStore.Web.Tests.HomeControllerTests
{
    [TestClass]
    public class HomeController_Should
    {
        [TestMethod]
        public void IndexAction_ReturnsViewResult()
        {
            var moviesService = this.SetupMockService();
            var cacheMock = new Mock<IMemoryCache>();
            var controller = new HomeController(moviesService.Object, cacheMock.Object);
            var entry = new Mock<ICacheEntry>();

          /*  entry
                .Setup(e => e.AbsoluteExpiration).Returns(new DateTime.UtcNow.AddHours(3));

            cacheMock
                .Setup(c => c.GetOrCreate("s", entry))
                .
               */
                
       

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
