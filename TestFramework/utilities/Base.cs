using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;
using WebDriverManager.DriverConfigs.Impl;

namespace TestFramework.utilities
{
    public class Base
    {
        public IWebDriver driver;

        public void StartBrowserWithUrl(string url)
        {
            string browserName = ConfigurationManager.AppSettings["browser"];

            if (string.IsNullOrEmpty(browserName))
            {
                throw new Exception("Browser configuration is missing or empty.");
            }

            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("URL cannot be null or empty.");
            }

            InitBrowser(browserName);
            driver.Manage().Window.Maximize();
            driver.Url = url;
        }

        public IWebDriver getDriver()
        {
            return driver;
        }

        // Browser initialization logic based on the provided browser name
        public void InitBrowser(string browserName)
        {
            switch (browserName.ToLower()) // Use lowercase for case-insensitivity
            {
                case "firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;

                case "edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;

                default:
                    throw new NotSupportedException($"Browser '{browserName}' is not supported.");
            }
        }

        // Cleanup logic to close and dispose of the driver after each test
        [TearDown]
        public void CloseBrowser()
        {
            if (driver != null)
            {
                driver.Quit(); // Quit the browser session
                driver.Dispose(); // Dispose of the WebDriver instance
            }
        }
    }
}
