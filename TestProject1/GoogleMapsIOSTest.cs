using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapsAutomation.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;

namespace GoogleMapsAutomation
{
    public class GoogleMapsIOSTest
    {

        private AndroidDriver driver;
        private GoogleMapsDirectionsPage googleMapsDirectionsPage;
        private GoogleMapsLandingPage googleMapsLandingPage;

        const String fromAddress = "Big Ben, London SW1A 0AA, United Kingdom";
        const String toAddress = "65-68 Leadenhall St";


        [SetUp]
        public void Setup()
        {
            AppiumOptions options = new AppiumOptions();

            options.DeviceName = "iPhone 12";
            options.PlatformName = "iOS";
            options.PlatformVersion = "15";
            options.AddAdditionalAppiumOption("app", "path_to_google_maps.app");
            options.AddAdditionalAppiumOption("appActivity", "com.google.android.maps.MapsActivity");
            options.AutomationName = "XCUITest";

            //Starting the Appiumm server
            var AppiumService = new AppiumServiceBuilder().WithIPAddress("127.0.0.1").UsingPort(4723).Build();
            AppiumService.Start();

            // driver = new AndroidDriver(new Uri("http://127.0.0.1:4723/"), options);
            driver = new AndroidDriver(AppiumService, options);

            // Instantiate the Google Maps Page Object
            googleMapsDirectionsPage = new GoogleMapsDirectionsPage(driver);
            googleMapsLandingPage = new GoogleMapsLandingPage(driver);


        }

        [Test]
        public void TestDrivingMode()
        {
            googleMapsLandingPage.SearchLocation(toAddress);
            googleMapsLandingPage.AssertAddress(toAddress);
            googleMapsLandingPage.ClickDirections();
            googleMapsDirectionsPage.EnterOriginAddress(fromAddress);
            googleMapsLandingPage.CheckImersiveViewExists();
            googleMapsDirectionsPage.DrivingMode();

        }

        [Test]

        public void TestPublicTransitMode()
        {
            googleMapsLandingPage.SearchLocation(toAddress);
            googleMapsLandingPage.ClickDirections();
            googleMapsDirectionsPage.EnterOriginAddress(fromAddress);
            googleMapsDirectionsPage.PublicServiceMode();

        }
        [Test]

        public void TestWalkingMode()
        {
            googleMapsLandingPage.SearchLocation(toAddress);
            googleMapsLandingPage.ClickDirections();
            googleMapsDirectionsPage.EnterOriginAddress(fromAddress);
            googleMapsDirectionsPage.WalkingMode();

        }
        [Test]

        public void TestBikeMode()
        {
            googleMapsLandingPage.SearchLocation(toAddress);
            googleMapsLandingPage.ClickDirections();
            googleMapsDirectionsPage.EnterOriginAddress(fromAddress);
            googleMapsDirectionsPage.BikeMode();

        }
        [Test]

        public void TestRideServiceMode()
        {
            googleMapsLandingPage.SearchLocation(toAddress);
            googleMapsLandingPage.ClickDirections();
            googleMapsDirectionsPage.EnterOriginAddress(fromAddress);
            googleMapsDirectionsPage.RideServiceMode();

        }


        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit(); // This will stop the session and clean up resources
                driver = null; // Set the driver to null to ensure it's properly cleaned up
            }
        }
        // driver.Quit();

    }
    
}
