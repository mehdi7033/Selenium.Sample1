using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit.Abstractions;

namespace Sample1.Tests
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _testOutputHelper;
        IWebDriver _driver;

        public UnitTest1(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _driver = new ChromeDriver();
        }

        [Fact]
        public void Test1()
        {
            Console.WriteLine("First test");
            _testOutputHelper.WriteLine("First test");
            _driver.Navigate().GoToUrl("https://www.google.com");
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void TestRegisterUser(string username, string password, string cpassword, string email)
        {
            _driver
                .Navigate()
                .GoToUrl("http://eaapp.somee.com");

            _driver.FindElement(By.Id("registerLink")).Click();
            _driver.FindElement(By.Id("UserName")).SendKeys(username);
            _driver.FindElement(By.Id("Password")).SendKeys(password);
            _driver.FindElement(By.Id("ConfirmPassword")).SendKeys(cpassword);
            _driver.FindElement(By.Id("Email")).SendKeys(email);


            _driver.FindElement(By.XPath("//input[@type='submit' and @value='Register']")).Submit();

            _testOutputHelper.WriteLine("Test completed");
        }

        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[]
            {
                "MehdiGhadimi",
                "MehdiPassword@12345",
                "MehdiPassword@12345",
                "Mehdi7033@gmail.com"
            },
            //new object[]
            //{
            //    "Prashanth",
            //    "PrasPassword",
            //    "PrasPassword",
            //    "Prashanth@gmail.com"
            //},
            //new object[]
            //{
            //    "James",
            //    "JamesPassword",
            //    "JamesPassword",
            //    "james@gmail.com"
            //}
        };
    }
}