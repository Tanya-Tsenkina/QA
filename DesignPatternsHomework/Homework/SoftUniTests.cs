using Homework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Homework
{
    [TestFixture]

    class SoftUniTests:BaseTest
    {
        private SoftUniIndexPage _softUniPage;

        [SetUp]
        public void ClassInit()
        {
            _softUniPage = new SoftUniIndexPage(Driver);
            _softUniPage.Navigate(_softUniPage.Url);
        }

        [Test]
        public void QAAutomayionH1IsExist()
        {
            _softUniPage.TrainingDropDown.Click();
            _softUniPage.QaAutomationCourse.Click();

            var courseH1Tag = Driver.FindElement(By.TagName("h1"));
            Assert.AreEqual("QA Automation - септември 2019", courseH1Tag.Text);

        }

    }
}
