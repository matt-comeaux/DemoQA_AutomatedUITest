/*
Name: DemoQaHomePageShould.cs
Purpose: Contains the test class for the home page on www.demoqa.com.
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
using OpenQA.Selenium.Support.UI;
using AutomatedUITest_DemoQA.Page_Object_Models.AlertsFramesWindows;
using AutomatedUITest_DemoQA.Page_Object_Models.Elements;
using AutomatedUITest_DemoQA.Page_Object_Models.Forms;
using AutomatedUITest_DemoQA.Page_Object_Models.HomePage;
using AutomatedUITest_DemoQA.Page_Object_Models.Interactions;
using AutomatedUITest_DemoQA.Page_Object_Models.Widgets;
using Xunit;

namespace AutomatedUITest_DemoQA.Test_Classes.MainPages_Test
{
    public class DemoQA_HomePageShould
    {
        [Fact]
        [Trait("Category", "Smoke")]
        public void Load()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var homePage = new HomePage(driver);
                homePage.LoadPage();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToElementsPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var homePage = new HomePage(driver);
                homePage.LoadPage();
                Elements_MainPage elementsPage = homePage.LoadElementsPageFromClick();
                elementsPage.EnsurePageLoaded();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToFormsPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var homePage = new HomePage(driver);
                homePage.LoadPage();
                Forms_MainPage formsPage = homePage.LoadFormsPageFromClick();
                formsPage.EnsurePageLoaded();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToAlertsPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var homePage = new HomePage(driver);
                homePage.LoadPage();
                Alerts_MainPage alertsPage = homePage.LoadAlertsPageFromClick();
                alertsPage.EnsurePageLoaded();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToWidgetsPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var homePage = new HomePage(driver);
                homePage.LoadPage();
                Widgets_MainPage widgetsPage = homePage.LoadWidgetsPageFromClick();
                widgetsPage.EnsurePageLoaded();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToInteractionsPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var homePage = new HomePage(driver);
                homePage.LoadPage();
                Interactions_MainPage interactionsPage = homePage.LoadInteractionsPageFromClick();
                interactionsPage.EnsurePageLoaded();
            }
        }

    }
}
