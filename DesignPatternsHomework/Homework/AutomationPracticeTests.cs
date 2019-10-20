using AutoFixture;
using Homework.Extensions;
using Homework.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Homework
{
    [TestFixture]
    public class AutomationPractice : BaseTest
    {
        private WebDriverWait _wait;
        private IndexPage _indexPage;
        private LoginPage _loginPage;
        private RegistrationPage _regPage;
        private RegistrationUser _user;

        [SetUp]
        public void CalssInit()
        {
            _indexPage = new IndexPage(Driver);
            _loginPage = new LoginPage(Driver);
            _regPage = new RegistrationPage(Driver);

            _user = UserFactory.CreateValidUser();
        }

        [Test]
        public void RegistrationPageIsOpen()
        {
            //start from index page
            _indexPage.Navigate(_indexPage.Url);

            //navigate to login page using SignInButton or href atribute of button
             _indexPage.SignInButton.Click();
         
            //_loginPage.Navigate(_indexPage.SignInButton.GetAttribute("href"));
            _loginPage.Email.Type("tgfs@gmail.com");
            _loginPage.Submit.Click();

            //assert
            Assert.AreEqual(_regPage.Url, Driver.Url);
        }

        [Test]
        public void RegistrationPageIsOpen_AssertAuthentication()
        {
            //start from index page
            _indexPage.Navigate(_indexPage.Url);
            _indexPage.SignInButton.Click();
            //_loginPage.Navigate(_indexPage.SignInButton.GetAttribute("href"));
            _loginPage.Email.Type("tgfs@gmail.com");
            _loginPage.Submit.Click();

            var authentication = Driver.FindElement(By.XPath(@"//*[@id=""columns""]/div[1]/span[2]"));
            Assert.AreEqual("Authentication", authentication.Text);
        }

        [Test]
        public void RegistrationUser_Successful()
        {
            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            var welcome = Driver.FindElement(By.XPath(@"//*[@id=""center_column""]/p"));

            _regPage.AssertSuccessful(welcome.Text);
        }

        [Test]
        public void FillRegistrationForm_AssertFirstName()
        {
            _user.FirstName = "";

            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            var firstErrorText = _regPage.FirstError.Text;
            _regPage.AssertFirstNameIsRequired(firstErrorText);
        }

        [Test]
        public void FillRegistrationForm_AssertPhone()
        {
            _user.Phone = "";

            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            var firstErrorText = _regPage.FirstError.Text;
            _regPage.AssertPhoneIsRequired(firstErrorText);
        }

        [Test]
        public void FillRegistrationForm_AssertPostcode()
        {
            _user.PostCode = "144";

            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            var firstErrorText = _regPage.FirstError.Text;
            _regPage.AssertPostcodeIsInvalid(firstErrorText);
        }

        [Test]
        public void FillRegistrationForm_AssertCityAndState()
        {
            _user.City = "";
            _user.State = "";

            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            var firstErrorText = _regPage.FirstError.Text;
            _regPage.AssertCityIsRequired(firstErrorText);

            var seconErrorText = _regPage.SecondError.Text;
            _regPage.AssertStateIsRequired(seconErrorText);
        }

        [Test]
        public void FillRegistrationForm_AssertPassword()
        {
            _user.Password = "";

            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            var firstErrorText = _regPage.FirstError.Text;
            _regPage.AssertPasswordIsRequired(firstErrorText);
        }

        [TearDown]
        public void CleanUp()
        {
            var name = TestContext.CurrentContext.Test.Name;
            var result = TestContext.CurrentContext.Result.Outcome;

            if(result != ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();

                var directory = Directory.GetCurrentDirectory();

                var fullpath = Path.GetFullPath("..\\..\\..\\ScreenShots\\");

                screenshot.SaveAsFile(fullpath + name + ".png", ScreenshotImageFormat.Png);
            }
        }
    }
}
