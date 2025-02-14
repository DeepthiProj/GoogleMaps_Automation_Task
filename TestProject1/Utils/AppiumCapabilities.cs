using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;

namespace GoogleMapsAutomation.Utils
{
    public class AppiumCapabilities
    {
        private AndroidDriver driver;


        public AndroidDriver SetUp()
        {
                AppiumOptions options = new AppiumOptions();

                options.DeviceName = "Pixel 7";
                options.PlatformName = "Android";
                options.PlatformVersion = "9.0";
                options.AddAdditionalAppiumOption("appPackage", "com.google.android.apps.maps");
                options.AddAdditionalAppiumOption("appActivity", "com.google.android.maps.MapsActivity");
                options.AutomationName = "UiAutomator2";

                var AppiumService = new AppiumServiceBuilder().WithIPAddress("127.0.0.1").UsingPort(4723).Build();
                 AppiumService.Start();
                 driver = new AndroidDriver(AppiumService, options);
                 return driver;

        }


        public void QuitDriver()
        {
            driver.Quit();
        }

    }
}
