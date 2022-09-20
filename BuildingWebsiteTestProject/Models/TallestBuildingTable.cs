using BuildingWebsiteTestProject.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BuildingWebsiteTestProject.Models;

public class TallestBuildingTable : BasePage
{
    public IWebDriver Driver { get; set; }

    [FindsBy(How = How.XPath, Using = "//table[@id='buildingsTable']//tbody/tr")]
    public IList<IWebElement> RowsInTheTableLocator;

    [FindsBy(How = How.XPath,
        Using =
            "//table[@id='buildingsTable']//tbody/tr[contains(.,'Lotte World Tower')]/td[@class='hidden lg:table-cell forget']")]
    public IWebElement LittleWorldTowerFloorsLocator;

    [FindsBy(How = How.XPath,
        Using = "//table[@id='buildingsTable']//tbody/tr/td[@class='hidden lg:table-cell forget']")]
    public IList<IWebElement> floorsBuildingProperties;

    [FindsBy(How = How.XPath, Using = "//table[@id='buildingsTable']//tbody/tr/td[@class='building-hover']")]
    public IList<IWebElement> floorBuildingsName; 
    
    IList<int> floorPropertiesText = new List<int>();
    IList<string> buildingNamePropertiesText = new List<string>();
    
    
    
    public TallestBuildingTable(IWebDriver driver) : base(driver)
    {
        this.Driver = driver;
        PageFactory.InitElements(driver, this);
    }

    public void ConvertIWebElementBuilding()
    {
        foreach (var buildingProperty in floorsBuildingProperties)
        {
            floorPropertiesText.Add(int.Parse(buildingProperty.Text));
        }
    } 
    public void ConvertIWebElementFloors()
    {
        foreach (var buildingName in floorBuildingsName)
        {
            buildingNamePropertiesText.Add(buildingName.Text);
        }
    }

    public Dictionary<string, int> CreateDictionaryWithFloorAndBuilding()
    {
        ConvertIWebElementBuilding();
        ConvertIWebElementFloors();
        var dictionaryBuildingAndFloors = buildingNamePropertiesText.Zip(floorPropertiesText, (k, v) => new { k, v })
            .ToDictionary(x => x.k, x => x.v);
        return dictionaryBuildingAndFloors;
    }
    public int NumberOfBuildingInTheTable()
    {
        return RowsInTheTableLocator.Count();
    }

    public int NumberOfFloorsInLotteWorldTower()
    {
        return int.Parse(LittleWorldTowerFloorsLocator.Text);
    }
}