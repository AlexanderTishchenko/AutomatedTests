using AutomatedTests.Api.Client;
using AutomatedTests.Api.EndPoints;
using AutomatedTests.Logger;
using AutomatedTests.Pages;
using AutomatedTests.Utilities;

namespace AutomatedTests.Tests
{
    internal class CommentsTest : BaseTest
    {
        private Client _client;
        [OneTimeSetUp]
        public void SetUp()
        {
            _client = new Client(); 
        }

        [Test]
        public async Task Test1()
        {
            CustomLog.Step(1, "Open comments page");
            CommentsPage homePage = PageOpening.Open<CommentsPage>(GetBrowser());
            var contentOfAPage = homePage.GetContentText();
            contentOfAPage = contentOfAPage.Replace("\r", string.Empty);

            var commentsEndPoint = new CommentsEndPoint(_client);
            var commentsByApi = await commentsEndPoint.GetCommentsAsync();

            Assert.That(contentOfAPage, Is.EqualTo(commentsByApi), "Content of a page is not equal to API call");
        }
    }
}
