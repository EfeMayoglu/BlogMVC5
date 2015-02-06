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
    }
}