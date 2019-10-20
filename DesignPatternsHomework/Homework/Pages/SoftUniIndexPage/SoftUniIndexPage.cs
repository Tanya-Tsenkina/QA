using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Pages
{
    public class SoftUniIndexPage : BasePage
    {
        public SoftUniIndexPage(IWebDriver driver)
        : base(driver)
        {
        }

        public new string Url => "http://www.softuni.bg";

        public IWebElement TrainingDropDown => Driver.FindElement(By.XPath(@"//*[@id=""header-nav""]/div[1]/ul/li[2]/a"));

        public IWebElement QaAutomationCourse => Driver.FindElement(By.LinkText("QA Automation - септември 2019"));
    }

}
