using Xunit;
using System;
using FakeItEasy;
using System.Web.Mvc;
using Blog.Controllers;
using Blog.Models;

namespace Blog.UnitTests
{
    public class ShowEntryControllerTests
    {
        [Fact]
        private void ShowEntryController_ShowEntry_With_Null_ID()
        {
            ShowEntryController showEntry = new ShowEntryController();

            var httpStatus = showEntry.Index(null) as HttpStatusCodeResult;

            Assert.NotNull(httpStatus);
            Assert.Equal(400, httpStatus.StatusCode);

        }

        [Fact]
        private void ShowEntryController_ShowEntry_With_ID_NotNull()
        {
            /* niestety nie udało mi się do końca przyswoić sposobu utworzenia fakeEntry z parametrami
                podawanymi w trakcie tworzenia obiektu */
            

            ShowEntryController showEntry = new ShowEntryController();

            var fakeEntry = A.Fake<BlogEntry>();

            fakeEntry.ID = 1;
            fakeEntry.Entry = "Test";
            fakeEntry.EntryDate = DateTime.Now;
            fakeEntry.Title = "Test";
            fakeEntry.UserName = "Test";

            var viewResult = showEntry.Index(1) as ViewResult;

            Assert.NotNull(viewResult);
            Assert.Equal(1, fakeEntry.ID);
        }

      /*  [Fact]
        private void ShowEntryController_Null_BlogEntry()
        {
            ShowEntryController showEntry = new ShowEntryController();

            var fakeDbContext = A.Fake<BlogEntriesDbContext>();

            var fakeEntry = fakeDbContext.BlogEntries.Find(1);

            var httpStatus = showEntry.Index(1) as HttpStatusCodeResult;

            //Assert.NotNull(httpStatus);
            Assert.Equal(404, httpStatus.StatusCode);
        } */
    }
}