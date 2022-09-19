using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebsiteTestProject.Base;
using WebsiteTestProject.Models;
using WebsiteTestProject.Pages;

namespace WebsiteTestProject.TestScenario; 

[TestFixture]
public class VerifyTableProperties 
{   
    public IWebDriver _driver;
    private WebDriverWait _wait;  

    
    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
    }
    
    
    [Test]
    public void VerifyTop100HighestBuildingTableProperties()
    {
        SkyScreeperPage skyScreeperPage = new SkyScreeperPage(_driver);
        TallestBuildingTable tallestBuildingTable = new TallestBuildingTable(_driver);
        skyScreeperPage.GoToUrl();
        skyScreeperPage.ClickOnCookiesButton();
        skyScreeperPage.SelectTop100TallestBuildingFromDropdown();
        tallestBuildingTable.NumberOfBuildingInTheTable().Should().Be(100); 
        
        // IWebElement webTable = _driver.FindElement(By.XPath("//table[@id='buildingsTable']//tbody"));
        // IList<IWebElement> rows = _driver.FindElements(By.XPath("//table[@id='buildingsTable']//tbody/tr"));
        // int rowsCount = rows.Count;
        // //1st assertion 
        // rowsCount.Should().Be(100);
        // // Rows attribute 
        // var rowsLotte = int.Parse(_driver.FindElement(By.XPath("//table[@id='buildingsTable']//tbody/tr[contains(.,'Lotte World Tower')]/td[@class='hidden lg:table-cell forget']")).Text);
        // rowsLotte.Should().Be(123); 
    } 
    
    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}