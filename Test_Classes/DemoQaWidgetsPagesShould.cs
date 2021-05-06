/*
Name: DemoQaWidgetsPagesShould.cs
Purpose: Contains the test class for the widget pages on www.demoqa.com. This includes testing for all widgets pages under the widgets section. 
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
using TestAutomation_DemoQA.Page_Object_Models.Widgets;
using Xunit;

namespace TestAutomation_DemoQA
{
    public class DemoQaWidgetsPagesShould
    {
        [Fact]
        [Trait("Category", "Smoke")]
        public void Load()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var widgetsMainPage = new Widgets_MainPage(driver);
                widgetsMainPage.LoadPage();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToAccordianPage_SideMenu()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var widgetsMainPage = new Widgets_MainPage(driver);
                widgetsMainPage.LoadPage();
                AccordianPage accordianPage = widgetsMainPage.NavigateToAccordianPage_SideMenu();
                accordianPage.EnsurePageLoaded();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToAutoCompletePage_SideMenu()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var widgetsMainPage = new Widgets_MainPage(driver);
                widgetsMainPage.LoadPage();
                AutoCompletePage autoCompletePage = widgetsMainPage.NavigateToAutoCompletePage_SideMenu();
                autoCompletePage.EnsurePageLoaded();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToDatePickerPage_SideMenu()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var widgetsMainPage = new Widgets_MainPage(driver);
                widgetsMainPage.LoadPage();
                DatePickerPage datePickerPage = widgetsMainPage.NavigateToDatePickerPage_SideMenu();
                datePickerPage.EnsurePageLoaded();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToMenuPage_SideMenu()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var widgetsMainPage = new Widgets_MainPage(driver);
                widgetsMainPage.LoadPage();
                MenuPage menuPage = widgetsMainPage.NavigateToMenuPage_SideMenu();
                menuPage.EnsurePageLoaded();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToProgressBarPage_SideMenu()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var widgetsMainPage = new Widgets_MainPage(driver);
                widgetsMainPage.LoadPage();
                ProgressBarPage progressBarPage = widgetsMainPage.NavigateToProgressBarPage_SideMenu();
                progressBarPage.EnsurePageLoaded();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToSelectMenuPage_SideMenu()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var widgetsMainPage = new Widgets_MainPage(driver);
                widgetsMainPage.LoadPage();
                SelectMenuPage selectMenuPage = widgetsMainPage.NavigateToSelectMenuPage_SideMenu();
                selectMenuPage.EnsurePageLoaded();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToSliderPage_SideMenu()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var widgetsMainPage = new Widgets_MainPage(driver);
                widgetsMainPage.LoadPage();
                SliderPage sliderPage = widgetsMainPage.NavigateToSliderPage_SideMenu();
                sliderPage.EnsurePageLoaded();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToTabsPage_SideMenu()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var widgetsMainPage = new Widgets_MainPage(driver);
                widgetsMainPage.LoadPage();
                TabsPage tabsPage = widgetsMainPage.NavigateToTabsPage_SideMenu();
                tabsPage.EnsurePageLoaded();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToToolTipsPage_SideMenu()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var widgetsMainPage = new Widgets_MainPage(driver);
                widgetsMainPage.LoadPage();
                ToolTipsPage toolTipsPage = widgetsMainPage.NavigateToToolTipsPage_SideMenu();
                toolTipsPage.EnsurePageLoaded();
            }
        }
    }
}
