using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Configuration;
using WebDriverManager.DriverConfigs.Impl;

namespace TestFramework.utilities
{
    public class Base
    {
        public IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            string browserName = ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName);

            driver.Manage().Window.Maximize();
            driver.Url = "http://127.0.0.1:8000/user/login/";
        }

        public void InitBrowser(string browserName)
        {
            switch (browserName) 
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;

                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;
            }
        }

        [TearDown]
        public void CloseBrowser()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();  // Explicitly disposes of the WebDriver instance
            }
        }
    }
}
