/*
Name: Tabs.cs
Purpose: Contains the Page Object Model for the tabs page on www.demoqa.com. 
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
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace AutomatedUITest_DemoQA.Page_Object_Models.Widgets
{
    class TabsPage
    {
        private readonly IWebDriver Driver;
        private readonly string url = "https://demoqa.com/tabs";
        private readonly string mainHeader = "Tabs";

        //Use whenever WebDriverWait is needed.
        private WebDriverWait Wait()
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        //Create instance of POM.
        public TabsPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        //Load page.
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

        public void Display_WhatTab()
        {
            //Click different tab as the 'what' tab is open on load.
            Driver.FindElement(By.Id("demo-tab-origin")).Click();

            //Click 'what' tab and wait for text to appear.
            Driver.FindElement(By.Id("demo-tab-what")).Click();
            Wait().Until((d) => Driver.FindElement(By.XPath("//*[@id='demo-tabpane-what']/p")).Text);

            //Validate text to determine if correct tab opened. Only testing first sentence due to text length.
            var firstSentence = Driver.FindElement(By.XPath("//*[@id='demo-tabpane-what']/p")).Text.Remove(74);
            var expectedText = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.";
            Assert.True(firstSentence == expectedText, "The 'What' tab did not display its text properly");
           }

        public void Display_OriginTab()
        {
            //Click tab and wait for text to appear.
            Driver.FindElement(By.Id("demo-tab-origin")).Click();
            Wait().Until((d) => Driver.FindElement(By.XPath("//*[@Class='tab-content']/div[2]/p[1]")).Text);

            //Validate text to determine if correct tab opened. Only testing first sentence due to text length.
            var firstSentence = Driver.FindElement(By.XPath("//*[@Class='tab-content']/div[2]/p[1]")).Text.Remove(66);
            var expectedText = "Contrary to popular belief, Lorem Ipsum is not simply random text.";
            Assert.True(firstSentence == expectedText, "The 'Origin' tab did not display its text properly");
        }

        public void Display_UseTab()
        {
            //Click tab and wait for text to appear.
            Driver.FindElement(By.Id("demo-tab-use")).Click();
            Wait().Until((d) => Driver.FindElement(By.XPath("//*[@Class='tab-content']/div[3]/p")).Text);

            //Validate text to determine if correct tab opened. Only testing first sentence due to text length.
            var firstSentence = Driver.FindElement(By.XPath("//*[@Class='tab-content']/div[3]/p")).Text.Remove(124);
            var expectedText = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.";
            Assert.True(firstSentence == expectedText, "The 'Use' tab did not display its text properly");
        }
    }
}
