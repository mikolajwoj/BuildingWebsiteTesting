using AutomationTestSiiFramework.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace WebsiteTestProject.Models;

public class TallestBuildingTable : BasePage
{
    public IWebDriver Driver { get; set; }

    [FindsBy(How = How.XPath, Using = "//table[@id='buildingsTable']//tbody/tr")]
    public IList<IWebElement> RowsInTheTable; 
    


    public TallestBuildingTable(IWebDriver driver) : base(driver)
    {
        this.Driver = driver;
        PageFactory.InitElements(driver, this);
    }

    public int NumberOfBuildingInTheTable()
    {
        return RowsInTheTable.Count();
    } 
    
}