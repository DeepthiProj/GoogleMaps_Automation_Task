
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace GoogleMapsAutomation.Pages
{
    public class GoogleMapsLandingPage
    {

        private By searchBox = By.XPath("//android.widget.TextView[@text=\"Search here\"]");
        private By editSearchBox = By.XPath("//android.widget.EditText[@text=\"Search here\"]");
        private By addressHeader = By.XPath("//android.widget.TextView[@content-desc=\"65-68 Leadenhall St\"]");
        private By directionsButton = By.XPath("//android.widget.Button[@content-desc=\"Directions to 65-68 Leadenhall St, 65-68 Leadenhall St\"]");
        private By immersiveView = By.XPath("//android.widget.RelativeLayout/android.widget.ImageView[1]");

        private AndroidDriver driver;


        public GoogleMapsLandingPage(AndroidDriver driver)
        {
            this.driver = driver;
        }


        // Search Directions
        public void SearchLocation(string location)
        {
            IWebElement searchField = driver.FindElement(searchBox);
            searchField.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement editSearchField = wait.Until(ExpectedConditions.ElementToBeClickable(editSearchBox));
            editSearchField.SendKeys(location);
            driver.PressKeyCode(66);
        }



        // Method to click on the directions button
        public void ClickDirections()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement directionsBtn = wait.Until(ExpectedConditions.ElementToBeClickable(directionsButton));
            directionsBtn.Click();

        }


        public void AssertAddress(string address)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement Header = driver.FindElement(addressHeader);
            var addressText = Header.Text;
            Assert.That(addressText, Is.EquivalentTo(address));

        }

        public void CheckImersiveViewExists()

        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement testableElement = wait.Until(ExpectedConditions.ElementIsVisible(immersiveView));
            bool isClickable = testableElement.Displayed && testableElement.Enabled;
        }
    }
}
