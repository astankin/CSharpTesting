using NUnit.Framework;
using OpenQA.Selenium;
using System.Configuration;
using TestFramework.pageObjects;
using TestFramework.PageObjects;
using TestFramework.utilities;

namespace TestFramework
{
    public class TestLogIn : Base
    {

        string loginUrl = ConfigurationManager.AppSettings["loginUrl"];

        [Test]
        [TestCase("nasko@yahoo.com", "1234")]  
        public void LoginValidCredentials(string username, string password)
        {
            
            StartBrowserWithUrl(loginUrl);

            LoginPage loginPage = new LoginPage(getDriver());
            loginPage.Login(username, password);
            Thread.Sleep(5000);

            HomePage homePage = new HomePage(getDriver());
            Assert.IsTrue(homePage.IsLoggedIn(), "The username is not displayed.");
        }

        [Test]
        public void LoginInvalidUsername()
        {
            StartBrowserWithUrl(loginUrl);

            string expectedMessage = "No active account found with the given credentials";
            string expectedClass = "alert-danger";

            // Perform the login action
            LoginPage loginPage = new LoginPage(getDriver());
            loginPage.Login("invalid@mail.com", "1234");

            // Wait for the validation message to appear
            Thread.Sleep(5000); // Replace with an explicit wait if possible for better performance

            // Assert that the validation message is displayed
            IWebElement validationElement = loginPage.GetValidationElement(); // Adjust based on how the validation message is located
            Assert.IsTrue(validationElement.Displayed, "Validation message is not displayed.");

            // Assert that the validation message text is as expected
            Assert.AreEqual(expectedMessage, validationElement.Text, "Validation message text does not match.");

            // Assert that the class of the validation element contains "alert-danger"
            string actualClass = validationElement.GetAttribute("class");
            Assert.IsTrue(actualClass.Contains(expectedClass), $"Validation message class does not contain '{expectedClass}'.");
        }

    }
}
