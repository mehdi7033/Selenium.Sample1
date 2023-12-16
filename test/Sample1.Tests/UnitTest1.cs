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

           // Thread.Sleep(5000);
        }
    }
}