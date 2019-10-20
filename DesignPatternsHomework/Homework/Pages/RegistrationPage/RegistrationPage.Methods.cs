using System;

namespace Homework.Pages
{
    public partial class RegistrationPage
    {

        public void FillForm(RegistrationUser user)
        {
            RadioButtons[0].Click();
            CustomerFirstName.SendKeys(user.FirstName);
            CustomerLastName.SendKeys(user.LastName);
            Password.SendKeys(user.Password);
            Days.SelectByValue(user.Day);
            Months.SelectByValue(user.Month);
            Years.SelectByValue(user.Year);
            FirstName.SendKeys(user.RealFirstName);
            LastName.SendKeys(user.RealLastName);
            Address.SendKeys(user.Address);
            City.SendKeys(user.City);
            State.SelectByValue(user.State);
            PostCode.SendKeys(user.PostCode);
            Phone.SendKeys(user.Phone);
            Alias.SendKeys(user.Alias);
            RegisterButton.Click();
        }

        public void Navigate(LoginPage loginPage)
        {
            loginPage.Navigate(loginPage.Url);

            var randNum = new Random();
            loginPage.Email.SendKeys($"typ{randNum.Next(1000)}@abv.bg");
            loginPage.Submit.Click();
        }
    }
}
