using OpenQA.Selenium;
using TestFramework.PageObjects;
using TestFramework.utilities;

namespace TestFramework;

public class TestLogIn : Base
{

    [Test]
    public void LoginValidCredentials()
    {
        LoginPage loginPage = new LoginPage(getDriver());
        loginPage.Login("nasko", "As8304034508@");
        Thread.Sleep(5000);
    }

    [Test]
    public void LoginInvalidUsername()
    {
        LoginPage loginPage = new LoginPage(getDriver());
        loginPage.Login("invalid", "As8304034508@");
        Thread.Sleep(5000);
    }


}
