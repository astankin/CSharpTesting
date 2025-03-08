using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestFramework.PageObjects
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // Explicit wait
            PageFactory.InitElements(driver, this);
        }

        // Username Input Field
        [FindsBy(How = How.Id, Using = "id_username")]
        private IWebElement usernameInput;

        // Password Input Field
        [FindsBy(How = How.Id, Using = "id_password")]
        private IWebElement passwordInput;

        // Sign In Button
        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        private IWebElement signInButton;

        public void Login(string username, string password)
        {
            wait.Until(driver => usernameInput.Displayed); // Ensure field is visible
            usernameInput.Clear();
            usernameInput.SendKeys(username);

            wait.Until(driver => passwordInput.Displayed);
            passwordInput.Clear();
            passwordInput.SendKeys(password);

            signInButton.Click();
        }

     
        public bool IsLoginPageDisplayed()
        {
            return wait.Until(driver => signInButton.Displayed);
        }
    }
}
