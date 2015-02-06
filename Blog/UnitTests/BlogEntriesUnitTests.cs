using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xunit;
using FakeItEasy;
using Blog.Controllers;
using Blog.Service;
using Blog.Models;
using System.Web.Mvc;

namespace Blog.UnitTests
{
    public class BlogEntriesUnitTests
    {
        private BlogEntriesController testController;
        IBlogEntryService fakeBlogService = A.Fake<IBlogEntryService>();
        private List<BlogEntry> listBlogs;

        public BlogEntriesUnitTests()
        {
            testController = new BlogEntriesController(fakeBlogService);
            listBlogs = new List<BlogEntry>()
            {
                new BlogEntry {Id=1, UserName="user@mail.com", Entry="Entry1", Title="Title1", EntryDate=DateTime.Parse("2015-01-01")},
                new BlogEntry {Id=2, UserName="user@mail.com", Entry="Entry2", Title="Title2", EntryDate=DateTime.Parse("2015-01-01")},
                new BlogEntry {Id=3, UserName="user@mail.com", Entry="Entry3", Title="Title3", EntryDate=DateTime.Parse("2015-01-01")},
                new BlogEntry {Id=4, UserName="user@mail.com", Entry="Entry4", Title="Title4", EntryDate=DateTime.Parse("2015-01-01")}
            };
        }

        [Fact]
        private void BlogEntries_Index_Returns_List()
        {
            A.CallTo(() => fakeBlogService.SelectAll()).Returns(listBlogs);

            var viewResult = testController.Index() as ViewResult;
            var fakeEntries = viewResult.ViewData.Model as List<BlogEntry>;

            Assert.NotNull(viewResult);
            Assert.Equal(4, fakeEntries.Count);
            Assert.Equal(fakeEntries[0].Id, listBlogs[0].Id);
            Assert.Equal(fakeEntries[0].UserName, listBlogs[0].UserName);
            Assert.Equal(fakeEntries[0].Entry, listBlogs[0].Entry);
            Assert.Equal(fakeEntries[0].EntryDate, listBlogs[0].EntryDate);
            Assert.Equal(fakeEntries[0].Title, listBlogs[0].Title);
        }

        [Fact]
        private void BlogEntries_Details_400_Id_Null()
        {
            var fakeHttpContext = testController.Details(null) as HttpStatusCodeResult;

            Assert.NotNull(fakeHttpContext);
            Assert.Equal(400, fakeHttpContext.StatusCode);
        }

        [Fact]
        private void CRUD_Details_Returns_404_ID_Not_Found()
        {
            A.CallTo(() => fakeBlogService.GetById(1)).Returns<BlogEntry>(null);

            var fakeHttpCodeResult = testController.Details(1) as HttpStatusCodeResult;

            Assert.NotNull(fakeHttpCodeResult);
            Assert.Equal(404, fakeHttpCodeResult.StatusCode);
        }

        [Fact]
        private void CRUD_Details_Returns_Details_Proper_ID()
        {
            A.CallTo(() => fakeBlogService.GetById(1)).Returns(listBlogs[0]);

            var viewResult = testController.Details(1) as ViewResult;
            var fakeEntries = viewResult.ViewData.Model as BlogEntry;

            Assert.NotNull(viewResult);
            Assert.Equal(fakeEntries.Id, listBlogs[0].Id);
            Assert.Equal(fakeEntries.UserName, listBlogs[0].UserName);
            Assert.Equal(fakeEntries.Entry, listBlogs[0].Entry);
            Assert.Equal(fakeEntries.EntryDate, listBlogs[0].EntryDate);
            Assert.Equal(fakeEntries.Title, listBlogs[0].Title);
        }

        [Fact]
        private void CRUD_Create_HTTPGet_Returns_Index_View()
        {
            var viewResult = testController.Create() as ViewResult;

            Assert.NotNull(viewResult);
            Assert.Equal("", viewResult.ViewName);
        }

        [Fact]
        private void CRUD_Create_HTTPPost_Error_Incorrect_Entry()
        {
            var blogEntry = new BlogEntry {Id = 1};

            testController.ModelState.AddModelError("Error", "Title required");
            testController.ModelState.AddModelError("Error", "Content required");

            var viewResult = testController.Create(blogEntry) as ViewResult;

            A.CallTo(() => fakeBlogService.Create(blogEntry)).MustNotHaveHappened();

            Assert.NotNull(viewResult);
            Assert.Equal("", viewResult.ViewName);
        }

        [Fact]
        private void CRUD_Create_HTTPPost_Correct_Entry()
        {
            var blogEntry = new BlogEntry {Id=1, UserName="user@mail.com", Entry="Entry1", Title="Title1", EntryDate=DateTime.Parse("2015-01-01")};

            var viewResult = testController.Create(blogEntry) as RedirectToRouteResult;

            A.CallTo(() => fakeBlogService.Create(blogEntry)).MustHaveHappened(Repeated.Exactly.Once);
            Assert.NotNull(viewResult);
            Assert.Equal("Index", viewResult.RouteValues["action"]);
        }

        [Fact]
        private void CRUD_Update_HTTPGet_Null_ID()
        {
            var fakeHttpCodeResult = testController.Edit(null) as HttpStatusCodeResult;

            Assert.NotNull(fakeHttpCodeResult);
            Assert.Equal(400, fakeHttpCodeResult.StatusCode);
        }

        [Fact]
        private void CRUD_HttpPostEdit_HTTPPost_Error_Incorrect_Entry()
        {
            var blogEntry = new BlogEntry { Id = 1 };

            testController.ModelState.AddModelError("Error", "Title required");
            testController.ModelState.AddModelError("Error", "Content required");

            var viewResult = testController.HttpPostEdit(blogEntry) as ViewResult;

            A.CallTo(() => fakeBlogService.Update(blogEntry)).MustNotHaveHappened();

            Assert.NotNull(viewResult);
            Assert.Equal("", viewResult.ViewName);
        }

        [Fact]
        private void CRUD_HttpPostEdit_HTTPPost_Correct_Entry()
        {
            var blogEntry = new BlogEntry() {Id=1, UserName="user@mail.com", Entry="Entry1", Title="Title1", EntryDate=DateTime.Parse("2015-01-01")};

            var viewResult = testController.HttpPostEdit(blogEntry) as RedirectToRouteResult;

            A.CallTo(() => fakeBlogService.Update(blogEntry)).MustHaveHappened(Repeated.Exactly.Once);

            Assert.NotNull(viewResult);
            Assert.Equal("Index", viewResult.RouteValues["action"]);
        }

        [Fact]
        private void CRUD_Delete_HttpGet_Null_ID()
        {
            var fakeHttpCodeResult = testController.Delete(null) as HttpStatusCodeResult;

            Assert.NotNull(fakeHttpCodeResult);
            Assert.Equal(400, fakeHttpCodeResult.StatusCode);
        }

        [Fact]
        private void CRUD_Delete_HTTPGET_Returns_404_ID_Not_Found()
        {
            A.CallTo(() => fakeBlogService.GetById(1)).Returns<BlogEntry>(null);

            var fakeHttpCodeResult = testController.Delete(1) as HttpStatusCodeResult;

            Assert.NotNull(fakeHttpCodeResult);
            Assert.Equal(404, fakeHttpCodeResult.StatusCode);
        }

        [Fact]
        private void CRUD_HTTPGet_Delete_Proper_ID()
        {
            A.CallTo(() => fakeBlogService.GetById(1)).Returns(listBlogs[0]);

            var viewResult = testController.Delete(1) as ViewResult;
            var fakeEntry = viewResult.ViewData.Model as BlogEntry;

            Assert.NotNull(viewResult);
            Assert.Equal(listBlogs[0].Id, fakeEntry.Id);
            Assert.Equal(listBlogs[0].Entry, fakeEntry.Entry);
            Assert.Equal(listBlogs[0].Title, fakeEntry.Title);
        }

        [Fact]
        private void CRUD_HTTPPost_ConfirmDelete_Proper_ID()
        {
            A.CallTo(() => fakeBlogService.GetById(1)).Returns(listBlogs[0]);
            
            var blogPost = listBlogs[0];
            var data = new System.Web.Mvc.FormCollection();
            
            var viewResult = testController.DeleteConfirmed(1)  as RedirectToRouteResult;

            A.CallTo(() => fakeBlogService.Delete(blogPost)).MustHaveHappened(Repeated.Exactly.Once);

            Assert.NotNull(viewResult);
            Assert.Equal("Index", viewResult.RouteValues["action"]);
        }
    }
}