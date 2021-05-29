/*
Name: Resizable.cs
Purpose: Contains the Page Object Model for the resizable page on www.demoqa.com. 
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
using OpenQA.Selenium.Interactions;
using Xunit;

namespace AutomatedUITest_DemoQA.Page_Object_Models.Interactions
{
    class ResizablePage
    {
        private readonly IWebDriver Driver;
        private readonly string url = "https://demoqa.com/resizable";
        private readonly string mainHeader = "Resizable";

        //Creates instance of POM.
        public ResizablePage(IWebDriver driver)
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

        public void ResizeRestricedBox()
        {
            //Find box to resize, its resize handle, and its current size. Then create instance of Actions.
            var box = Driver.FindElement(By.Id("resizableBoxWithRestriction"));
            var boxHandle = Driver.FindElement(By.XPath("//*[@id='resizableBoxWithRestriction']/span"));
            var initialSize = box.Size;
            Actions actions = new Actions(Driver);

            //Resize box and store its current size.
            actions.ClickAndHold(boxHandle).MoveByOffset(374, 180);
            actions.Perform();
            var newSize = box.Size;

            //Validate that the box was properly resized.
            Assert.True(initialSize != newSize, "The select box failed to resize");
        }

        public void ResizeNonRestrictedBox()
        {
            //Find box to resize, its resize handle, and its current size. Then create instance of Actions.
            var box = Driver.FindElement(By.Id("resizableBoxWithRestriction"));
            var boxHandle = Driver.FindElement(By.XPath("//*[@id='resizable']/span"));
            var initialSize = box.Size;
            Actions actions = new Actions(Driver);

            //Resize box and store its current size.
            actions.ClickAndHold(boxHandle).MoveByOffset(473, 267);
            actions.Perform();
            var newSize = box.Size;
            
            //Validation.
             Assert.True(initialSize != newSize, "The select box failed to resize");
        }
    }
}
