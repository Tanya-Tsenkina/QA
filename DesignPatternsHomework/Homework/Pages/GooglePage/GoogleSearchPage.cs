using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Pages
{
    class GoogleSearchPage : BasePage
    {
        public GoogleSearchPage(IWebDriver driver)
            : base(driver)
        {

        }

        public new string Url => "https://www.google.bg/";

        public IWebElement SearchInput => Driver.FindElement(By.XPath(@"//*[@id=""tsf""]/div[2]/div[1]/div[1]/div/div[2]/input"));
    }
}
