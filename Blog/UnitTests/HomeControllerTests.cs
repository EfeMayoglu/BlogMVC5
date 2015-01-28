using Xunit;
using System.Web.Mvc;
using Blog.Controllers;

namespace Blog.UnitTests
{
    public class HomeControllerTests
    {
        [Fact]
        private void Home_Controller_About_Returns_About_View()
        {
            HomeController homeController = new HomeController();
            var viewResult = homeController.About() as ViewResult;

            Assert.NotNull(viewResult);
            Assert.Equal("About", viewResult.ViewName);
        }

        [Fact]
        private void Home_Controller_Contact_Returns_Contact_View()
        {
            HomeController homeController = new HomeController();
            var viewResult = homeController.Contact() as ViewResult;

            Assert.NotNull(viewResult);
            Assert.Equal("Contact", viewResult.ViewName);
        }
    }
}