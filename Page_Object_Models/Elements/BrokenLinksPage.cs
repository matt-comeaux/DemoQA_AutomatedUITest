/*
Name: BrokenLinks-Images.cs
Purpose: Contains the Page Object Model for the broken-links-images page on www.demoqa.com. 
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
using Xunit;

namespace AutomatedUITest_DemoQA.Page_Object_Models.Elements
{
    class BrokenLinksPage
    {
        private readonly IWebDriver Driver;
        private readonly string url = "https://demoqa.com/broken";
        private readonly string mainHeader = "Broken Links - Images";

        //Creates instance of POM.
        public BrokenLinksPage(IWebDriver driver)
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
                throw new Exception($"The requested page did not load correctly. The page url is: '{url}' The main header is: \r\n '{Driver.FindElement(By.ClassName("main-header")).Text}'");
            }
        }

        public void VerifyValidImage()
        {
            //Store image.
            var image = Driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/img[1]"));

            //Validate image loaded.
            Assert.True(image.GetAttribute("naturalWidth") != "0", "This image from source: " + image.GetAttribute("src") + " did not load properly.");
        }

        public void VerifyBrokenImage()
        {
            //Store broken image.
            var image = Driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/img[2]"));

            //Validate image is broken.
            Assert.True(image.GetAttribute("naturalWidth") == "0", "The image with the source of: " + image.GetAttribute("src") + " loaded. This image is supposed to be broken.");
        }

        public void VerifyWorkingLink()
        {
            //Click link and store the destination url in a variable.
            Driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/a[1]")).Click();
            var currentUrl = Driver.Url;

            //Validate link is working.
            Assert.True(currentUrl == "https://demoqa.com/", "The selected link is broken. The target site of https://demoqa.com/ was not reached.");
        }

        public void VerifyBrokenLink()
        {
            //Click broken link and store the destination url in a variable.
            Driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/a[2]")).Click();
            var currentUrl = Driver.Url;

            //Validate link is broken.
            Assert.True(currentUrl != "https://demoqa.com", "The selected link was supposed to be broken. However it is navigating to the correct site of https://demoqa.com");
        }
    }
}
