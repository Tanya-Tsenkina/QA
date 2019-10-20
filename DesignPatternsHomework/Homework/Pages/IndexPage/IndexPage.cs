using OpenQA.Selenium;


namespace Homework.Pages
{
    class IndexPage : BasePage
    {
        public IndexPage(IWebDriver driver)
           : base(driver)
        {
        }

        public new string Url => "http://automationpractice.com/index.php";

        public IWebElement SignInButton => Driver.FindElement(By.XPath(@"//*[@id=""header""]/div[2]/div/div/nav/div[1]/a"));
    }
}
