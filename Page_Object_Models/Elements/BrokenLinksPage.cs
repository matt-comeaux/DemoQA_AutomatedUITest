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
using OpenQA.Selenium.Support.UI;

namespace AutomatedUITest_DemoQA.Page_Object_Models.Elements
{
    class BrokenLinksPage
    {
        private readonly IWebDriver Driver;
        private readonly string url = "https://demoqa.com/broken";
        private readonly string mainHeader = "Broken Links - Images";

        public BrokenLinksPage(IWebDriver driver)
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

        public void VerifyValidImage()
        {
            var imageLink = Driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/img[1]"));
           
            bool isLoaded = (imageLink.GetAttribute("naturalWidth") != "0");
            if (!isLoaded)
            {
                throw new Exception($"This image from source: '{imageLink.GetAttribute("src")}' did not load properly.");
            }
        }

        public void VerifyBrokenImage()
        {
            var imageWidth = Driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/img[2]"));
            bool isNotLoaded = (imageWidth.GetAttribute("naturalWidth") == "0");
            if (!isNotLoaded)
            {
                throw new Exception($"The image with the source of: '{imageWidth.GetAttribute("src")}' loaded. This image is supposed to be broken.");
            }
        }

        public void VerifyWorkingLink()
        {
            Driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/a[1]")).Click();
            var currentUrl = Driver.Url;
            bool isWorking = (currentUrl == "https://demoqa.com");
            if (!isWorking)
            {
                throw new Exception($"The selected link is broken. The target site of https://demoqa.com was not reached.");
            }
        }

        public void VerifyBrokenLink()
        {
            Driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/a[2]")).Click();
            var currentUrl = Driver.Url;
            bool isBroken = (currentUrl != "https://demoqa.com");
            if (!isBroken)
            {
                throw new Exception($"The selected link was supposed to be broken. However it is navigating to the correct site of https://demoqa.com");
            }

        }
    }
}
