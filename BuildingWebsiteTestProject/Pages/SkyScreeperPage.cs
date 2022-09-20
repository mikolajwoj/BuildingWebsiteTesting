using OpenQA.Selenium;
using BuildingWebsiteTestProject.Base;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects; 

namespace BuildingWebsiteTestProject.Pages;

public class SkyScreeperPage : BasePage
{
    private string WebsiteURl = "https://www.skyscrapercenter.com/buildings?list=tallest100-construction";
    public IWebDriver Driver { get; set; }
    
    [FindsBy(How = How.CssSelector, Using = "body > div.js-cookie-consent.cookie-consent > button")]
    private IWebElement cookiesButton; 
    [FindsBy(How = How.CssSelector, Using = "#lists-pages-select-container > select")]
    private IWebElement buildingDropDownElement;
    
    public SkyScreeperPage(IWebDriver driver) : base(driver)
    {
        this.Driver = driver;
        PageFactory.InitElements(driver, this);
    }
    
    public void SelectTop100TallestBuildingFromDropdown()
    {
        SelectElement selectAnTopHighBuilding = new SelectElement(buildingDropDownElement);
        selectAnTopHighBuilding.SelectByText("100 Tallest Completed Buildings in the World");
    }
    
    public void ClickOnCookiesButton()
    {
        cookiesButton?.Click();
    }

    public void GoToUrl()
    {
        Driver.Navigate().GoToUrl(WebsiteURl);
    }

}