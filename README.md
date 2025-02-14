# Android_GoogleMaps_Task

 This project is intended to automate Google Maps on Android.

## Project Description

This project uses **WebdriverIO** in combination with **Appium** to automate mobile testing for Web browser and Android applications. It supports running tests on Android  real devices and Chrome browser on web.

### Key Features:
- Native app automation using **Appium** for **Android**.
- **Page Object Model (POM)** to structure the test code, keeping page-specific actions and assertions separate from the actual test logic.

## Prerequisites

 1. Install Dependencies via NuGet:
    
    -> Selenium.WebDriver
    
    -> Selenium.Support
    
    -> Appium.WebDriver
    
    -> NUnit
    
    -> ExtentReport
    
3. Set Up Appium Server (Download from Appium.io)
4. Enable Developer Mode on Android and Connect via USB (or use an emulator)
5. Specify the Google Maps Package and Activity:
    -> Package Name: com.google.android.apps.maps
    -> Main Activity: com.google.android.maps.MapsActivity
6. Visual Studios
7. Android SDK & Emulator
   

## Package Structure

GoogleMapsAutomation/
- Pages
    - GoogleMapsLandingPage.cs
    - GoogleMapsDirectionsPage.cs
- Utils
    - AppiumCapabilities.cs
    - ExtantManager.cs
- Reports
    - reports.html
- GoogleMapsTest.cs
 


## Installation

Follow the steps below to set up the project locally:

### 1. Clone the Repository

Clone the project to your local machine using Git:

git clone https://github.com/DeepthiProj/GoogleMaps_Automation_Task.git

## Running Tests
1. Start the Appium Server. (It is done Programmatically on AppiumCapabilities.cs)
2. Execute the Tests in Visual Studio using Test Explorer or command line.
3. After the tests finish, you will find the Extent HTML report in the Reports folder.






