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
using Xunit;

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
            //Click new tab button, create collection of all tabs, switch to tab and store its data in a variable.
            Driver.FindElement(By.Id("tabButton")).Click();
            ReadOnlyCollection<String> allTabs = Driver.WindowHandles;
            var createdTab = Driver.SwitchTo().Window(allTabs[1]);

            //Assert correct tab was created on button click.
            var pageHeader = Driver.FindElement(By.Id("sampleHeading")).Text;
            Assert.True(createdTab.Url == "https://demoqa.com/sample", "The button with id of: 'tabButton' did not open to the correct url.");
            Assert.True(pageHeader == "This is a sample page", "The button with id of: 'tabButton' did not open to the page with the correct heading.");
        }

        public void ClickButton_NewWindow()
        {
            //Click new window button, create collection of all windows, switch to created window and store its data in a variable.
            Driver.FindElement(By.Id("windowButton")).Click();
            ReadOnlyCollection<String> allWindows = Driver.WindowHandles;
            var createdWindow = Driver.SwitchTo().Window(allWindows[1]);

            //Verify the window loaded to the correct page.
            Assert.True(createdWindow.Url == "https://demoqa.com/sample", "The button with id of: 'windowButton' did not open the correct window.");
            Assert.True(Driver.FindElement(By.Id("sampleHeading")).Text == "This is a sample page", "The button with id of: 'windowButton' did not open the correct window.");
        }

        public void ClickButton_NewWindowMessage()
        {
            //Store current window Id and click new window message button. 
            var mainWindowHandle = Driver.CurrentWindowHandle;
            Driver.FindElement(By.Id("messageWindowButton")).Click();

            //create collection of all windows, switch to created window message and store its data in a variable.
            ReadOnlyCollection<String> allWindows = Driver.WindowHandles;
            var windowMessage = Driver.SwitchTo().Window(allWindows[1]);

            //Validate window message appeared.
            Assert.True(windowMessage.CurrentWindowHandle != mainWindowHandle, "The message window failed to load.");
        }

    }
}
