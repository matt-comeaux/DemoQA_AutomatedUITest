/*
Name: HomePage.cs
Purpose: Contains the Page Object Model for the home page on www.demoqa.com. 
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
using AutomatedUITest_DemoQA.Page_Object_Models.AlertsFramesWindows;
using AutomatedUITest_DemoQA.Page_Object_Models.Elements;
using AutomatedUITest_DemoQA.Page_Object_Models.Forms;
using AutomatedUITest_DemoQA.Page_Object_Models.Interactions;
using AutomatedUITest_DemoQA.Page_Object_Models.Widgets;

namespace AutomatedUITest_DemoQA.Page_Object_Models.HomePage
{
    class HomePage
    {
        private readonly IWebDriver Driver;
        private readonly string url = "https://demoqa.com/";
        private readonly string pageTitle = "ToolsQA";

        public HomePage(IWebDriver driver)
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
            bool isLoaded = (Driver.Url == url) && (Driver.Title == pageTitle);

            if (!isLoaded)
            {
                throw new Exception($"The requested page did not load correctly. The page url is: '{url}' The page title is: \r\n '{Driver.Title}'");
            }
        }

        public Elements_MainPage LoadElementsPageFromClick()
        {
            Driver.FindElement(By.XPath("//div[contains(@class,'category-cards')]/div[1]")).Click();
            return new Elements_MainPage(Driver);
        }

        public Forms_MainPage LoadFormsPageFromClick()
        {
            Driver.FindElement(By.XPath("//div[contains(@class,'category-cards')]/div[2]")).Click();
            return new Forms_MainPage(Driver);
        }

        public Alerts_MainPage LoadAlertsPageFromClick()
        {
            Driver.FindElement(By.XPath("//div[contains(@class,'category-cards')]/div[3]")).Click();
            return new Alerts_MainPage(Driver);
        }

        public Widgets_MainPage LoadWidgetsPageFromClick()
        {
            Driver.FindElement(By.XPath("//div[contains(@class,'category-cards')]/div[4]")).Click();
            return new Widgets_MainPage(Driver);
        }

        public Interactions_MainPage LoadInteractionsPageFromClick()
        {
            Driver.FindElement(By.XPath("//div[contains(@class,'category-cards')]/div[5]")).Click();
            return new Interactions_MainPage(Driver);
        }


    }
}
