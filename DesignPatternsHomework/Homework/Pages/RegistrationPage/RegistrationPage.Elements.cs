using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Homework.Pages
{
    public partial class RegistrationPage : BasePage
    {
        public RegistrationPage(IWebDriver driver)
            : base(driver)
        {
        }

        public new string Url => "http://automationpractice.com/index.php?controller=authentication&back=my-account#account-creation";

        // ne srabotvva
        //public IList<IWebElement> RadioButtons => Wait.Until(d => d.FindElements(By.ClassName("radio")));

        public IList<IWebElement> RadioButtons
        {
            get
            {
                var watch = new Stopwatch();
                watch.Start();
                var element = Wait.Until(d => d.FindElements(By.ClassName("radio")));
                watch.Stop();

                Debug.WriteLine(watch.ElapsedMilliseconds);

                return element;
            }

        }

        public IWebElement CustomerFirstName => Driver.FindElement(By.Id("customer_firstname"));

        public IWebElement CustomerLastName => Driver.FindElement(By.Id("customer_lastname"));

        public IWebElement Password => Driver.FindElement(By.Id("passwd"));

        public SelectElement Days
        {
            get
            {
                IWebElement reminder = Driver.FindElement(By.Id("days"));
                return new SelectElement(reminder);
            }
        }

        public SelectElement Months
        {
            get
            {
                IWebElement reminder = Driver.FindElement(By.Id("months"));
                return new SelectElement(reminder);
            }
        }

        public SelectElement Years
        {
            get
            {
                IWebElement reminder = Driver.FindElement(By.Id("years"));
                return new SelectElement(reminder);
            }
        }

        public IWebElement FirstName => Driver.FindElement(By.Id("firstname"));

        public IWebElement LastName => Driver.FindElement(By.Id("lastname"));

        public IWebElement Address => Driver.FindElement(By.Id("address1"));

        public IWebElement City => Driver.FindElement(By.Id("city"));

        public SelectElement State
        {
            get
            {
                IWebElement reminder = Driver.FindElement(By.Id("id_state"));
                return new SelectElement(reminder);
            }
        }

        public IWebElement PostCode => Driver.FindElement(By.Id("postcode"));

        public IWebElement Phone => Driver.FindElement(By.Id("phone_mobile"));

        public IWebElement Alias => Driver.FindElement(By.Id("alias"));

        public IWebElement RegisterButton => Driver.FindElement(By.Id("submitAccount"));

        public IWebElement FirstError => Driver.FindElement(By.XPath(@"//*[@id=""center_column""]/div/ol/li[1]"));

        public IWebElement SecondError => Driver.FindElement(By.XPath(@"//*[@id=""center_column""]/div/ol/li[2]"));

    }
}
