using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Text.RegularExpressions;
using System.Security;
using OpenQA.Selenium.DevTools.V130.DOM;



namespace GoogleMapsAutomation.Pages
{
    public class GoogleMapsDirectionsPage
    {
      
        private By fromSearchBox = By.XPath("//android.widget.TextView[@content-desc=\"Choose start location\"]");
        private By fromEditSearchBox = By.XPath("//android.widget.EditText[@resource-id=\"com.google.android.apps.maps:id/search_omnibox_edit_text\"]");
        private By driveComponent = By.Id("com.google.android.apps.maps:id/trip_details_summary_header");
        private By walkMode = By.XPath("//android.widget.HorizontalScrollView[@resource-id=\"com.google.android.apps.maps:id/directions_mode_tabs\"]/android.widget.LinearLayout/android.widget.LinearLayout[3]");
        private By walkComponent = By.Id("com.google.android.apps.maps:id/trip_details_summary_header");
        private By bikeMode = By.XPath("//android.widget.HorizontalScrollView[@resource-id=\"com.google.android.apps.maps:id/directions_mode_tabs\"]/android.widget.LinearLayout/android.widget.LinearLayout[4]");
        private By bikeComponent = By.XPath("//android.widget.LinearLayout[@resource-id=\"com.google.android.apps.maps:id/card_stack_peeking_header_container\"]");                                                     
        private By rideMode = By.XPath("//android.widget.HorizontalScrollView[@resource-id=\"com.google.android.apps.maps:id/directions_mode_tabs\"]/android.widget.LinearLayout/android.widget.LinearLayout[5]");
        private By rideComponenet = By.ClassName("android.support.v7.widget.RecyclerView");
        private By publicMode = By.XPath("//android.widget.HorizontalScrollView[@resource-id=\"com.google.android.apps.maps:id/directions_mode_tabs\"]/android.widget.LinearLayout/android.widget.LinearLayout[2]");
        private By publicComponenet = By.Id("com.google.android.apps.maps:id/directions_group_list");
        private By publicAndRideTimeEstimate = By.XPath("(//android.widget.FrameLayout[@resource-id=\"com.google.android.apps.maps:id/trip_card_primary_detail\"])[1]/android.widget.FrameLayout/android.widget.TextView");
        private By driveTimeEstimate = By.XPath("//android.widget.LinearLayout[@resource-id=\"com.google.android.apps.maps:id/card_stack_peeking_header_container\"]/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.TextView[1]");
        private By walkTimeEstimate = By.XPath("//android.widget.LinearLayout[@resource-id=\"com.google.android.apps.maps:id/card_stack_peeking_header_container\"]/android.widget.LinearLayout[1]/android.widget.LinearLayout/android.widget.TextView[1]");
        private By bikeTimeEstimate = By.XPath("//android.widget.LinearLayout[@resource-id=\"com.google.android.apps.maps:id/card_stack_peeking_header_container\"]/android.widget.LinearLayout[2]/android.widget.LinearLayout[1]/android.widget.LinearLayout/android.widget.TextView[1]");
        private By rideTimeEstimate = By.XPath("(//android.widget.FrameLayout[@resource-id=\"com.google.android.apps.maps:id/trip_card_primary_detail\"])[1]/android.widget.FrameLayout/android.widget.TextView");

        private AndroidDriver driver;

        public GoogleMapsDirectionsPage(AndroidDriver driver)
        {
            this.driver = driver;
        }



        public void EnterOriginAddress(string origin)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement from = wait.Until(ExpectedConditions.ElementToBeClickable(fromSearchBox));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            from.Click();
            IWebElement fromEditBox = driver.FindElement(fromEditSearchBox);
            fromEditBox.SendKeys(origin);
            driver.PressKeyCode(66);

        }


        public void DrivingMode()
        {
            IWebElement drive = driver.FindElement(driveComponent);
            bool driveDetails = drive.Displayed;
            IWebElement travelTime = driver.FindElement(driveTimeEstimate);
            this.AssertTravelTime(travelTime.Text);

        }

        public void WalkingMode()
        {
            IWebElement walkingMode = driver.FindElement(walkMode);
            walkingMode.Click();
            IWebElement walk = driver.FindElement(walkComponent);
            bool walkDetails = walk.Displayed;
            IWebElement travelTime = driver.FindElement(walkTimeEstimate);
            this.AssertTravelTime(travelTime.Text);

        }

        public void BikeMode()
        {
            IWebElement bikingMode = driver.FindElement(bikeMode);
            bikingMode.Click();
            IWebElement bike = driver.FindElement(bikeComponent);
            bool bikeDetails = bike.Displayed;
            IWebElement travelTime = driver.FindElement(bikeTimeEstimate);
            this.AssertTravelTime(travelTime.Text);
        }

        public void RideServiceMode()
        {

            IWebElement rideServiceMode = driver.FindElement(rideMode);
            rideServiceMode.Click();
            IWebElement ride = driver.FindElement(rideComponenet);
            bool rideServiceDetails = ride.Displayed;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement travelTime = wait.Until(ExpectedConditions.ElementIsVisible(rideTimeEstimate));
            this.AssertTravelTime(travelTime.Text);

        }

        public void PublicServiceMode()
        {

            IWebElement publicServiceMode = driver.FindElement(publicMode);
            publicServiceMode.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement publicConp = driver.FindElement(publicComponenet);
            bool publicService = publicConp.Displayed;
            IWebElement travelTime = driver.FindElement(publicAndRideTimeEstimate);
            this.AssertTravelTime(travelTime.Text);

        }

        public void AssertTravelTime(string estimatedTime)
          {

            bool containsNumbers = Regex.IsMatch(estimatedTime, @"\d");
            ClassicAssert.IsTrue(containsNumbers, "The string does not contain numbers!");
            ClassicAssert.IsNotEmpty(estimatedTime, "No Travel time present");

        }
    }
}



