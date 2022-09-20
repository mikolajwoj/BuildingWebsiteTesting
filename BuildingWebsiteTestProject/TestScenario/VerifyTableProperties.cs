using BuildingWebsiteTestProject.Models;
using BuildingWebsiteTestProject.Pages;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;



namespace BuildingWebsiteTestProject.TestScenario; 

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
        tallestBuildingTable.NumberOfFloorsInLotteWorldTower().Should().Be(123);
        var dictionaryWithFloorAndBuilding = tallestBuildingTable.CreateDictionaryWithFloorAndBuilding();
        foreach (var kvp in dictionaryWithFloorAndBuilding.OrderByDescending(r =>r.Value).Take(1))
        {
            TestContext.Out.WriteLine("Building = {0}, Floors = {1}",
                kvp.Key, kvp.Value);
        } 
        
    } 
    
    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}