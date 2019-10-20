namespace Homework
{
    public static class UserFactory
    {
        public static RegistrationUser CreateValidUser()
             => new RegistrationUser
             {
                 FirstName = "Santa",
                 LastName = "Clause",
                 Password = "gdsjafgujdsw",
                 Year = "1989",
                 Month = "3",
                 Day = "3",
                 RealFirstName = "dqdo",
                 RealLastName = "Koleda",
                 Address = "Tintqva",
                 City = "Sofia",
                 State = "2",
                 PostCode = "43244",
                 Country = "",
                 Phone = "85001",
                 Alias = "",
                 Gender = "male",
             };
    }
}
