/*
Name: Links.cs
Purpose: Contains the Page Object Model for the links page on www.demoqa.com. 
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

namespace AutomatedUITest_DemoQA.Page_Object_Models.Elements
{
    class LinksPage
    {
        private readonly IWebDriver Driver;
        private readonly string url = "https://demoqa.com/links";
        private readonly string mainHeader = "Links";

        private WebDriverWait Wait()
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        public LinksPage(IWebDriver driver)
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

        public void ClickLink_Home()
        {
            //Click home link, store all tabs in read only collection, switch to created tab. 
            Driver.FindElement(By.Id("simpleLink")).Click();
            ReadOnlyCollection<String> allTabs = Driver.WindowHandles;
            var linkDestination = Driver.SwitchTo().Window(allTabs[1]);

            //Validate link is working.
            Assert.True(linkDestination.Url == "https://demoqa.com/", "The selected link is no longer working.");
        }

        public void ClickLink_HomeiybUo()
        {
            //Click HomeiybUo link, store all tabs in read only collection, switch to created tab.
            Driver.FindElement(By.Id("dynamicLink")).Click();
            ReadOnlyCollection<String> allTabs = Driver.WindowHandles;
            var linkDestination = Driver.SwitchTo().Window(allTabs[1]);

            //Validate link is working.
            Assert.True(linkDestination.Url == "https://demoqa.com/", "The selected link is no longer working.");
        }

        public void ClickLink_Created()
        {
            //Click created link, wait for response, store response.
            Driver.FindElement(By.Id("created")).Click();
            var response = Wait().Until((d) => Driver.FindElement(By.Id("linkResponse")).Text);

            //Validate link is working.
            Assert.True(response == "Link has responded with staus 201 and status text Created", "The selected link is no longer working.");
        }

        public void ClickLink_NoContent()
        {
            //Click created link, wait for response, store response.
            Driver.FindElement(By.Id("no-content")).Click();
            var response = Wait().Until((d) => Driver.FindElement(By.Id("linkResponse")).Text);

            //Validate link is working.
            Assert.True(response == "Link has responded with staus 204 and status text No Content", "The selected link is no longer working.");
        }

        public void ClickLink_Moved()
        {
            //Click created link, wait for response, store response.
            Driver.FindElement(By.Id("moved")).Click();
            var response = Wait().Until((d) => Driver.FindElement(By.Id("linkResponse")).Text);

            //Validate link is working.
            Assert.True(response == "Link has responded with staus 301 and status text Moved Permanently", "The selected link is no longer working.");
        }

        public void ClickLink_BadRequest()
        {
            //Click created link, wait for response, store response.
            Driver.FindElement(By.Id("bad-request")).Click();
            var response = Wait().Until((d) => Driver.FindElement(By.Id("linkResponse")).Text);

            //Validate link is working.
            Assert.True(response == "Link has responded with staus 400 and status text Bad Request", "The selected link is no longer working.");
        }

        public void ClickLink_Unauthorized()
        {
            //Click created link, wait for response, store response.
            Driver.FindElement(By.Id("unauthorized")).Click();
            var response = Wait().Until((d) => Driver.FindElement(By.Id("linkResponse")).Text);

            //Validate link is working.
            Assert.True(response == "Link has responded with staus 401 and status text Unauthorized", "The selected link is no longer working.");
        }

        public void ClickLink_Forbidden()
        {
            //Click created link, wait for response, store response.
            Driver.FindElement(By.Id("forbidden")).Click();
            var response = Wait().Until((d) => Driver.FindElement(By.Id("linkResponse")).Text);

            //Validate link is working.
            Assert.True(response == "Link has responded with staus 403 and status text Forbidden", "The selected link is no longer working.");
        }

        public void ClickLink_NotFound()
        {
            //Click created link, wait for response, store response.
            Driver.FindElement(By.Id("invalid-url")).Click();
            var response = Wait().Until((d) => Driver.FindElement(By.Id("linkResponse")).Text);

            //Validate link is working.
            Assert.True(response == "Link has responded with staus 404 and status text Not Found", "The selected link is no longer working.");
        }
    }
}
