using System;
using System.Net;
using System.Web;
using System.Linq;
using Blog.Controllers;
using System.Web.Mvc;
using FakeItEasy;
using Blog.Models;
using System.Data.Entity;
using Xunit;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;


namespace Blog.UnitTests
{
    public class BlogEntriesControllerTests
    {
        private BlogEntriesController _blogEntrCtrlr = new BlogEntriesController();

        [Fact]
        private void Return_View_Index()
        {
            var data = new List<BlogEntry>
            {
                new BlogEntry {ID=1, Entry="TestEntry", EntryDate=DateTime.Now, Title="TestTitle", UserName="TestUser"},
                new BlogEntry {ID=2, Entry="TestEntry", EntryDate=DateTime.Now, Title="TestTitle", UserName="TestUser"},
                new BlogEntry {ID=3, Entry="TestEntry", EntryDate=DateTime.Now, Title="TestTitle", UserName="TestUser"},
                new BlogEntry {ID=4, Entry="TestEntry", EntryDate=DateTime.Now, Title="TestTitle", UserName="TestUser"},
            }.AsQueryable();

            var fakeContext = A.Fake<BlogEntriesDbContext>();

            fakeContext.BlogEntries.AddRange(data);

            var result = data.ToList();
            var viewResult = _blogEntrCtrlr.Index() as ViewResult;

            Assert.Equal(4, result.Count);
        }

        [Fact]
        private void Details_ID_Null()
        {
            var httpStatus = _blogEntrCtrlr.Details(null) as HttpStatusCodeResult;

            Assert.Equal(400, httpStatus.StatusCode);
        }

        [Fact]
        private void Detalis_ID_Correct()
        {
            var fakeEntry = A.Fake<BlogEntry>();

            fakeEntry.ID = 1;
            fakeEntry.Entry = "Test";
            fakeEntry.EntryDate = DateTime.Now;
            fakeEntry.Title = "Test";
            fakeEntry.UserName = "Test";

            var viewResult = _blogEntrCtrlr.Details(1) as ViewResult;

            Assert.Equal(1, fakeEntry.ID);
        }


        //Unfinished
        /*[Fact]
        private void Create_Test_ProperEntrySended()
        {

            var fakeHttpContext = A.Fake<HttpContextBase>();
            var fakeIdentity = new GenericIdentity("User");
            var principal = new GenericPrincipal(fakeIdentity, null);


            A.CallTo(() => fakeHttpContext.User).Returns(principal);

            var controllerContext = A.Fake<ControllerContext>();
            A.CallTo(() => controllerContext.HttpContext).Returns(fakeHttpContext);

            var identity = new GenericIdentity("User");
            Thread.CurrentPrincipal = new GenericPrincipal(identity, null);

            var fakeContext = A.Fake<BlogEntriesDbContext>();
            var fakeEntry = A.Fake<BlogEntry>();

            fakeEntry.Entry = "Test";
            fakeEntry.Title = "Test";

            _blogEntrCtrlr.ViewData.ModelState.Clear();

            _blogEntrCtrlr.ControllerContext = controllerContext;

            _blogEntrCtrlr.Create(fakeEntry);
        }*/


        //Unfinished
        /*[Fact]
        private void Confirmed_Delete_Proper_ID_Returns_To_Proper_View()
        {
            var data = new List<BlogEntry>
            {
                new BlogEntry {ID=1, Entry="TestEntry", EntryDate=DateTime.Now, Title="TestTitle", UserName="TestUser"},
            }.AsQueryable();

            var fakeEntry = A.Fake<DbSet<BlogEntry>>();
            var fakeContext = A.Fake<BlogEntriesDbContext>();

            fakeContext.BlogEntries.AddRange(data);


            A.CallTo(_blogEntrCtrlr.DeleteConfirmed(1)).MustHaveHappened();
        }*/
    }
}