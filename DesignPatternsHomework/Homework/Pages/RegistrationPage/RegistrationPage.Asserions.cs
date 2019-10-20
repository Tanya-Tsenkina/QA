using NUnit.Framework;

namespace Homework.Pages
{
    public partial class RegistrationPage
    {
        public void AssertSuccessful(string expected)
        {
            Assert.AreEqual(expected, "Welcome to your account. Here you can manage all of your personal information and orders.");
        }
        public void AssertFirstNameIsRequired(string expected)
        {
            Assert.AreEqual(expected, "firstname is required.");
        }

        public void AssertPhoneIsRequired(string expected)
        {
            Assert.AreEqual(expected, "You must register at least one phone number.");
        }

        public void AssertPostcodeIsInvalid(string expected)
        {
            Assert.AreEqual(expected, "The Zip/Postal code you've entered is invalid. It must follow this format: 00000");
        }

        public void AssertCityIsRequired(string expected)
        {
            Assert.AreEqual(expected, "city is required.");
        }

        public void AssertStateIsRequired(string expected)
        {
            Assert.AreEqual(expected, "This country requires you to choose a State.");
        }

        public void AssertPasswordIsRequired(string expected)
        {
            Assert.AreEqual(expected, "passwd is required.");
        }

    }
}
