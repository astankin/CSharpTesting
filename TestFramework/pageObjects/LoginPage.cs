using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;

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
        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement usernameInput;

        // Password Input Field
        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement passwordInput;

        // Sign In Button
        [FindsBy(How = How.XPath, Using = "//*[@id=\"root\"]/main/div/div/div/div/form/button")]
        private IWebElement signInButton;

        // Validation Message
        [FindsBy(How = How.XPath, Using = "//*[@id=\"root\"]/main/div/div/div/div/div[1]")]
        private IWebElement validationMessage;

        public string GetValidationMessage()
        {
            // Wait for the validation message to be visible
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"root\"]/main/div/div/div/div/div[1]")));

            return validationMessage.Text; // Once visible, return the text
        }

        public IWebElement GetValidationElement()
        {
            // Wait for the validation message to be visible
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"root\"]/main/div/div/div/div/div[1]")));
        }

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
