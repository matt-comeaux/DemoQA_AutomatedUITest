/*
Name: CheckBox.cs
Purpose: Contains the Page Object Model for the check box page on www.demoqa.com. 
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

namespace AutomatedUITest_DemoQA.Page_Object_Models.Elements
{
    class CheckBoxPage
    {
        private readonly IWebDriver Driver;
        private readonly string url = "https://demoqa.com/checkbox";
        private readonly string mainHeader = "Check Box";

        //Use whenever WebDriverWait is needed.
        private WebDriverWait Wait()
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        //Creates instance of POM.
        public CheckBoxPage(IWebDriver driver)
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

        public void SelectAllFiles()
        {
            //Select all files and wait for confirmation message to appear.
            var selectAllFilesButton = Driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/ol/li/span/label/span[1]"));
            selectAllFilesButton.Click();
            var results = Wait().Until((d) => Driver.FindElements(By.ClassName("text-success")));

            //Store the expected results. These must be in order of selection.
            string[] expectedResults = 
                { "home","desktop","notes","commands","documents","workspace","react","angular","veu","office","public","private","classified","general","downloads","wordFile","excelFile" };

            //Validate results.
            for (int i = 0; i < expectedResults.Length; i++)
            {
                Assert.True(expectedResults[i] == results[i].Text, "The file/folder: " + expectedResults[i] + " did not load.");
            }
        }
    }
}
