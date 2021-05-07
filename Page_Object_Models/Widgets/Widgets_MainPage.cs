/*
Name: Widgets_MainPage.cs
Purpose: Contains the Page Object Model for the widgets home page on www.demoqa.com. 
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

namespace AutomatedUITest_DemoQA.Page_Object_Models.Widgets
{
    class Widgets_MainPage
    {
        private readonly IWebDriver Driver;
        private readonly string url = "https://demoqa.com/widgets";
        private readonly string mainHeader = "Widgets";

        public Widgets_MainPage(IWebDriver driver)
        {
            this.Driver = driver;
        }
        public void LoadPage()
        {
            Driver.Navigate().GoToUrl(url);
            EnsurePageLoaded();
        }

        public void EnsurePageLoaded()
        {
            bool isLoaded = (Driver.Url == url) && (Driver.FindElement(By.ClassName("main-header")).Text == mainHeader);

            if (!isLoaded)
            {
                throw new Exception($"The requested page did not load correctly. The page url is: '{url}' The main header is: \r\n '{Driver.FindElement(By.ClassName("main-header")).Text}'");
            }
        }

        public AccordianPage NavigateToAccordianPage_SideMenu()
        {
            IWebElement accordianMenuItem =
                Driver.FindElement(By.XPath("//div[contains(@class, 'element-group')][4]/div/ul/li[1]"));

            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click()", accordianMenuItem);

            return new AccordianPage(Driver);
        }

        public AutoCompletePage NavigateToAutoCompletePage_SideMenu()
        {
            IWebElement autoCompleteMenuItem =
                Driver.FindElement(By.XPath("//div[contains(@class, 'element-group')][4]/div/ul/li[2]"));

            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click()", autoCompleteMenuItem);

            return new AutoCompletePage(Driver);
        }

        public DatePickerPage NavigateToDatePickerPage_SideMenu()
        {
            IWebElement datePickerMenuItem =
                Driver.FindElement(By.XPath("//div[contains(@class, 'element-group')][4]/div/ul/li[3]"));

            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click()", datePickerMenuItem);

            return new DatePickerPage(Driver);
        }

        public MenuPage NavigateToMenuPage_SideMenu()
        {
            IWebElement menuPageMenuItem =
                Driver.FindElement(By.XPath("//div[contains(@class, 'element-group')][4]/div/ul/li[8]"));

            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click()", menuPageMenuItem);

            return new MenuPage(Driver);
        }

        public ProgressBarPage NavigateToProgressBarPage_SideMenu()
        {
            IWebElement progressBarMenuItem =
                Driver.FindElement(By.XPath("//div[contains(@class, 'element-group')][4]/div/ul/li[5]"));

            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click()", progressBarMenuItem);

            return new ProgressBarPage(Driver);
        }

        public SelectMenuPage NavigateToSelectMenuPage_SideMenu()
        {
            IWebElement selectMenuMenuItem =
                Driver.FindElement(By.XPath("//div[contains(@class, 'element-group')][4]/div/ul/li[9]"));

            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click()", selectMenuMenuItem);

            return new SelectMenuPage(Driver);
        }

        public SliderPage NavigateToSliderPage_SideMenu()
        {
            IWebElement sliderMenuItem =
                Driver.FindElement(By.XPath("//div[contains(@class, 'element-group')][4]/div/ul/li[4]"));

            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click()", sliderMenuItem);

            return new SliderPage(Driver);
        }

        public TabsPage NavigateToTabsPage_SideMenu()
        {
            IWebElement tabsMenuItem =
                Driver.FindElement(By.XPath("//div[contains(@class, 'element-group')][4]/div/ul/li[6]"));

            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click()", tabsMenuItem);

            return new TabsPage(Driver);
        }

        public ToolTipsPage NavigateToToolTipsPage_SideMenu()
        {
            IWebElement toolTipsMenuItem =
                Driver.FindElement(By.XPath("//div[contains(@class, 'element-group')][4]/div/ul/li[7]"));

            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click()", toolTipsMenuItem);

            return new ToolTipsPage(Driver);
        }
    }
}
