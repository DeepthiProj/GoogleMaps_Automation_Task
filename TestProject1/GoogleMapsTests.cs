using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using NUnit.Framework;
using GoogleMapsAutomation.Pages;
using GoogleMapsAutomation.Utils;
using OpenQA.Selenium.Appium.Service;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System.Configuration;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using System.Diagnostics;
using AventStack.ExtentReports.Model;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework.Interfaces;




namespace GoogleMapsAutomation
{

        [TestFixture]
    public class GoogleMapsAndroidTest
    {



        private AndroidDriver driver;
        private GoogleMapsDirectionsPage googleMapsDirectionsPage;
        private GoogleMapsLandingPage googleMapsLandingPage;
        private AppiumCapabilities appiumCapabilities;

        private ExtentSparkReporter htmlReporter;
        private ExtentReports extent;
        private ExtentTest test;

        const String fromAddress = "Big Ben, London SW1A 0AA, United Kingdom";
        const String toAddress = "65-68 Leadenhall St";





        [SetUp]
        public void Setup()
        { 
            appiumCapabilities = new AppiumCapabilities();
            driver = appiumCapabilities.SetUp();
            googleMapsDirectionsPage = new GoogleMapsDirectionsPage(driver);
            googleMapsLandingPage = new GoogleMapsLandingPage(driver);

             extent = ExtentManager.GetInstance();
             test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
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


            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                test.Fail("Test has failed.");
            }else if(TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                test.Pass("Test has Pass.");
            }

          



            extent.Flush();

            var reportPath = "C:\\Users\\rajki\\Maps\\TestProject1\\TestProject1\\Reports\\report.html";

             Process.Start(new ProcessStartInfo
             {
                 FileName = reportPath,
                 UseShellExecute = true 
             });
            appiumCapabilities.QuitDriver();

        }

    }

   
}