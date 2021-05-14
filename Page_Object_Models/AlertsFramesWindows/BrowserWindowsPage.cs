/*
Name: BrowserWindows.cs
Purpose: Contains the Page Object Model for the browser windows page on www.demoqa.com. 
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
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomatedUITest_DemoQA.Page_Object_Models.AlertsFramesWindows
{
    class BrowserWindowsPage
    {
        private readonly IWebDriver Driver;
        private readonly string url = "https://demoqa.com/browser-windows";
        private readonly string mainHeader = "Browser Windows";

        private WebDriverWait Wait()
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        public BrowserWindowsPage(IWebDriver driver)
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
                throw new Exception($"The requested page did not load correctly. The page url is: '{url}' The page source is: \r\n '{Driver.PageSource}'");
            }
        }
        
        public void ClickButton_NewTab()
        {
            Driver.FindElement(By.Id("tabButton")).Click();
            ReadOnlyCollection<String> allTabs = Driver.WindowHandles;
            var tabCreatedOnButtonClick = allTabs[1]; 
            var createdTab = Wait().Until((d) => Driver.SwitchTo().Window(tabCreatedOnButtonClick));

            bool loadProperly = (createdTab.Url == "https://demoqa.com/sample" && Driver.FindElement(By.Id("sampleHeading")).Text == "This is a sample page");
            if (!loadProperly)
            {
                throw new Exception($"The button with id of: 'tabButton' did not open the correct tab.");
            }
            
        }

        public void ClickButton_NewWindow()
        {
            Driver.FindElement(By.Id("windowButton")).Click();
            ReadOnlyCollection<String> allWindows = Driver.WindowHandles;
            var createdWindow = allWindows[1];
            var newWindow = Wait().Until((d) => Driver.SwitchTo().Window(createdWindow));
            
            bool loadProperly = ( newWindow.Url == "https://demoqa.com/sample" && Driver.FindElement(By.Id("sampleHeading")).Text == "This is a sample page");
            if (!loadProperly)
            {
                throw new Exception($"The button with id of: 'windowButton' did not open the correct window.");
            }
        }

        public void ClickButton_NewWindowMessage()
        {
            var mainWindowHandle = Driver.CurrentWindowHandle;
            Driver.FindElement(By.Id("messageWindowButton")).Click();
            ReadOnlyCollection<String> allWindows = Driver.WindowHandles;
            var windowMessage = Wait().Until((d) => Driver.SwitchTo().Window(allWindows[1]));

            var windowMessageHandle = windowMessage.CurrentWindowHandle;
            bool loadWindowMessage = (mainWindowHandle != windowMessageHandle);
            if (!loadWindowMessage)
            {
                throw new Exception($"The message window failed to load.");
            }
            
        }

    }
}
