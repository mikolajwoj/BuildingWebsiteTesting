using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using FluentAssertions;
using SeleniumExtras.WaitHelpers;


namespace WebsiteTestProject;

public class Tests
{
    private IWebDriver _driver;
    private WebDriverWait _wait;  
    
    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
        _driver.Navigate().GoToUrl("https://www.skyscrapercenter.com/buildings?list=tallest100-construction");
        IWebElement BuildingDropDownElement =
            _driver.FindElement(By.CssSelector("#lists-pages-select-container > select"));
        SelectElement SelectAnTopHighBuilding = new SelectElement(BuildingDropDownElement);
        SelectAnTopHighBuilding.SelectByText("100 Tallest Completed Buildings in the World"); 
        var cookiesButton = _driver.FindElement(By.CssSelector("body > div.js-cookie-consent.cookie-consent > button"));
        cookiesButton.Click();
    }
    
    [Test]
    public void TableVariables()
    {

        IWebElement webTable = _driver.FindElement(By.XPath("//table[@id='buildingsTable']//tbody"));
        IList<IWebElement> rows = _driver.FindElements(By.XPath("//table[@id='buildingsTable']//tbody/tr"));
        int rowsCount = rows.Count;
        //1st assertion 
        rowsCount.Should().Be(100);
        // Rows attribute 
        var rowsLotte = int.Parse(_driver.FindElement(By.XPath("//table[@id='buildingsTable']//tbody/tr[contains(.,'Lotte World Tower')]/td[@class='hidden lg:table-cell forget']")).Text);
        rowsLotte.Should().Be(123); 
        
    }

    [Test]
    public void TestTablleu()
    {
        _driver.Navigate().GoToUrl("https://www.skyscrapercenter.com/buildings?list=tallest100-construction");
        IWebElement buildingDropDownElement =
            _driver.FindElement(By.CssSelector("#lists-pages-select-container > select"));
        SelectElement selectAnTopHighBuilding = new SelectElement(buildingDropDownElement);
        selectAnTopHighBuilding.SelectByText("100 Tallest Completed Buildings in the World");
        IList<IWebElement> floorsBuildingProperties = _driver.FindElements(By.XPath("//table[@id='buildingsTable']//tbody/tr/td[@class='hidden lg:table-cell forget']"));
        IList<IWebElement> floorsBuildingNames =
            _driver.FindElements(
                By.XPath("//table[@id='buildingsTable']//tbody/tr/td[@class='building-hover']"));
        IDictionary<string,int> allFloorsProperties = new Dictionary<string, int>();
        IList<int> floorPropertiesText = new List<int>();
        IList<string> buildingNamePropertiesText = new List<string>();
        foreach (var buildingProperty in floorsBuildingProperties)
        {
            floorPropertiesText.Add(int.Parse(buildingProperty.Text));
        }

        foreach (var buildingName in floorsBuildingNames)
        {
            buildingNamePropertiesText.Add(buildingName.Text);
        }
        
        var dic = buildingNamePropertiesText.Zip(floorPropertiesText, (k, v) => new { k, v })
            .ToDictionary(x => x.k, x => x.v);
        Console.WriteLine("Total key/value pairs in"+
                          " myDict are : " + dic.Count);
        Console.WriteLine(dic);
        foreach (var kvp in dic.OrderByDescending(r =>r.Value).Take(1))
        {
            Console.WriteLine("Building = {0}, Floors = {1}",
                     kvp.Key, kvp.Value);
        }
        
        
    }
    [TearDown] 
    public void TearDown()
    {
        _driver.Quit();
    }
}