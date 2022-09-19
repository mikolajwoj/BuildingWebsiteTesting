using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebsiteTestProject.Base;

[TestFixture]
public class BaseTest
{
    public IWebDriver _driver;
    private WebDriverWait _wait;  

    
    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
    }
    
    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}