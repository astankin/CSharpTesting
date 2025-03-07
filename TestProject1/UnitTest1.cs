using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject1
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize(); // Maximizing the browser window
            driver.Navigate().GoToUrl("http://127.0.0.1:8000/user/login/");
        }

        [Test]
        public void Test1()
        {

            driver.FindElement(By.Id("id_username")).SendKeys("");
            driver.FindElement(By.Id("id_password")).SendKeys("As8304034508@");
            //driver.FindElement(By.XPath("/html/body/main/div/div/div/div/div[2]/form/button")).Click();
            //driver.FindElement(By.CssSelector("button[type='submit']")).Click();
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            string actualErrorMessage = driver.FindElement(By.Id("id_username")).GetAttribute("validationMessage");
            string expectedErrorMessage = "Please fill out this field.";

            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8)); 
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#alert-danger")));

            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
            Thread.Sleep(5000);
        }

        public void Test2()
        {
            IWebElement dropdown = driver.FindElement(By.CssSelector("select.form-control"));

            SelectElement s = new SelectElement(dropdown);
            s.SelectByText("Teacher");
            s.SelectByValue("consult");
            s.SelectByIndex(1);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
