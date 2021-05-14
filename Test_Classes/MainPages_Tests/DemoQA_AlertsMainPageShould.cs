/*
Name: DemoQaAlertsPagesShould.cs
Purpose: Contains the test class for the alerts pages on www.demoqa.com. This includes testing for all alerts pages under the Alerts_Frames_Windows section. 
Author: Matthew Comeaux. Github: https://www.github.com/matt-comeaux Linkedin: https://www.linkedin.com/in/matthew-comeaux
Created On: 5/3/2021
First Uploaded To Github On: 5/4/2021

MIT License

Copyright (c) [2021] [Matthew H. Comeaux]

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

 */

using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using AutomatedUITest_DemoQA.Page_Object_Models.AlertsFramesWindows;
using Xunit;

namespace AutomatedUITest_DemoQA.Test_Classes.MainPages_Test
{
    public class DemoQA_AlertsMainPageShould
    {
        [Fact]
        [Trait("Category", "Smoke")]
        public void Load()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var alertsPage = new Alerts_MainPage(driver);
                alertsPage.LoadPage();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToAlertsPage_SideMenu()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var alertsMainPage = new Alerts_MainPage(driver);
                alertsMainPage.LoadPage();
                AlertsPage alertsPage = alertsMainPage.NavigateToAlertsPage_SideMenu();
                alertsPage.EnsurePageLoaded();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToBrowserWindowsPage_SideMenu()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var alertsMainPage = new Alerts_MainPage(driver);
                alertsMainPage.LoadPage();
                BrowserWindowsPage browserWindowsPage = alertsMainPage.NavigateToBrowserWindowsPage_SideMenu();
                browserWindowsPage.EnsurePageLoaded();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToFramesPage_SideMenu()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var alertsMainPage = new Alerts_MainPage(driver);
                alertsMainPage.LoadPage();
                FramesPage framesPage = alertsMainPage.NavigateToFramesPage_SideMenu();
                framesPage.EnsurePageLoaded();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToModalDialogPage_SideMenu()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var alertsMainPage = new Alerts_MainPage(driver);
                alertsMainPage.LoadPage();
                ModalDialogsPage modalDialogsPage = alertsMainPage.NavigateToModalDialogsPage_SideMenu();
                modalDialogsPage.EnsurePageLoaded();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToNestedFramesPage_SideMenu()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var alertsMainPage = new Alerts_MainPage(driver);
                alertsMainPage.LoadPage();
                NestedFramesPage nestedFramesPage = alertsMainPage.NavigateToNestedFramesPage_SideMenu();
                nestedFramesPage.EnsurePageLoaded();
            }
        }
    }
}
