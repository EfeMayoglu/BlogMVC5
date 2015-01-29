using Xunit;
using System.Web.Mvc;
using System.Collections.Generic;
using Blog.Controllers;
using PagedList;
using FakeItEasy;
using System;
using System.Linq;

namespace Blog.UnitTests
{
    public class HomeControllerTests
    {
        private HomeController _homeController = new HomeController();

        [Fact]
        private void HomeController_Page_Set_To_0()
        {
            var expected = typeof(ArgumentOutOfRangeException);
            Type actual = null;

            try
            {
                var viewResult = _homeController.Index(0) as ViewResult;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                actual = ex.GetType();
            }

            Assert.Equal(expected, actual);
        }

        [Fact]
        private void HomeController_About_Returns_About_View()
        {
            var viewResult = _homeController.About() as ViewResult;

            Assert.NotNull(viewResult);
            Assert.Equal("About", viewResult.ViewName);
        }

        [Fact]
        private void HomeController_Contact_Returns_Contact_View()
        {
            var viewResult = _homeController.Contact() as ViewResult;

            Assert.NotNull(viewResult);
            Assert.Equal("Contact", viewResult.ViewName);
        }
    }
}