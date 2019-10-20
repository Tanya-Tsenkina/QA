using Homework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Homework
{
    [TestFixture]
    class GoogleSearchTests : BaseTest
    {
        private GoogleSearchPage _searchPage;

        [SetUp]
        public void ClassInit()
        {
            _searchPage = new GoogleSearchPage(Driver);
            _searchPage.Navigate(_searchPage.Url);
        }

        [Test]
        public void GoogleSearchForSelenium()
        {
            _searchPage.SearchInput.SendKeys("Selenium");
            _searchPage.SearchInput.SendKeys(Keys.Enter);

            var firstLink = Driver.FindElement(By.XPath(@"//*[@id=""rso""]/div[1]/div/link"));
            Driver.Url = firstLink.GetAttribute("href");

            Assert.AreEqual("Selenium - Web Browser Automation", Driver.Title);
        }
    }
}
