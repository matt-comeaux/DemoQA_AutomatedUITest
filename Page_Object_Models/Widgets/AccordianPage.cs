/*
Name: Accordian.cs
Purpose: Contains the Page Object Model for the accordian page on www.demoqa.com. 
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
using OpenQA.Selenium.Support.Extensions;
using Xunit;

namespace AutomatedUITest_DemoQA.Page_Object_Models.Widgets
{
    class AccordianPage
    {
        private readonly IWebDriver Driver;
        private readonly string url = "https://demoqa.com/accordian";
        private readonly string mainHeader = "Accordian";

        //Creates instance of POM.
        public AccordianPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        //Loads page.
        public void LoadPage()
        {
            Driver.Navigate().GoToUrl(url);
            EnsurePageLoaded();
        }

        //Validate that the correct page loaded.
        public void EnsurePageLoaded()
        {
            bool isLoaded = (Driver.Url == url) && (Driver.FindElement(By.ClassName("main-header")).Text == mainHeader);

            if (!isLoaded)
            {
                throw new Exception($"The requested page did not load correctly. The page url is: '{url}' The page source is: \r\n '{Driver.PageSource}'");
            }
        }

        public void DisplayText_WhatIsTab()
        {
            //Since this tab is alway open on load we must move to a new tab.
            Driver.FindElement(By.Id("section1Heading")).Click();
            //Now we open the what is tab.
            Driver.FindElement(By.Id("section1Heading")).Click();

            //Verify text is displayed. Ignoring correctness for now as text is way too long.
            bool isDisplayed = (Driver.FindElement(By.Id("section1Content")).Enabled);
            Assert.True(isDisplayed, "The selected tab's text was not displayed.");
        }
        public void DisplayText_WhereDoesTab()
        {
            //Open tab. Using javascript to click as element isn't visible on default window size.
            Driver.ExecuteJavaScript("document.getElementById('section2Heading').click();");

            //Verify text is displayed. Ignoring correctness for now as text is way too long.
            bool isDisplayed = (Driver.FindElement(By.Id("section2Content")).Enabled);
            Assert.True(isDisplayed, "The selected tab's text was not displayed.");
        }
        public void DisplayText_WhyUseTab()
        {
            //Open tab. Using javascript to click as element isn't visible on default window size.
            Driver.ExecuteJavaScript("document.getElementById('section3Heading').click();");

            //Verify text is displayed. Ignoring correctness for now as text is way too long.
            bool isDisplayed = (Driver.FindElement(By.Id("section3Content")).Enabled);
            Assert.True(isDisplayed, "The selected tab's text was not displayed.");
        }
    }
}
