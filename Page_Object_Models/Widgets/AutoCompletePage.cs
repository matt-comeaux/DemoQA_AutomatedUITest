/*
Name: AutoComplete.cs
Purpose: Contains the Page Object Model for the auto complete page on www.demoqa.com. 
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

namespace AutomatedUITest_DemoQA.Page_Object_Models.Widgets
{
    class AutoCompletePage
    {
        private readonly IWebDriver Driver;
        private readonly string url = "https://demoqa.com/auto-complete";
        private readonly string mainHeader = "Auto Complete";

        //Create instance of POM.
        public AutoCompletePage(IWebDriver driver)
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

        public void SelectMultipleColors()
        {
            //Find multi-color input field, store input colors, and store expected colors after auto-complete.
            var input = Driver.FindElement(By.Id("autoCompleteMultipleInput"));
            string[] inputColors = { "Re", "Blu", "Blac" }; //incomplete as the we are testing auto-complete
            string[] expectedColors = { "Red", "Blue","Black" }; //Should match order of colors array.

            //Enter partial color names and press enter.
            for (int i = 0; i < inputColors.Length; i++)
            {
                input.SendKeys(inputColors[i]);
                input.SendKeys(Keys.Enter);
            }
           
            //Validate the partial color names were correctly auto-completed.
            var autoCompleteColors = Driver.FindElements(By.ClassName("auto-complete__multi-value__label"));
            for (int i = 0; i < autoCompleteColors.Count; i++)
            {
                Assert.True(autoCompleteColors[i].Text == expectedColors[i], 
                    "The color: " + expectedColors[i] + " was not properly auto completed when the following was typed" + inputColors[i]);
            }
        }

        public void SelectSingleColor()
        {
            //Find single color input field, send partial input color name, press enter.
            var input = Driver.FindElement(By.Id("autoCompleteSingleInput"));
            input.SendKeys("Blu");
            input.SendKeys(Keys.Enter);

            //Validate that the partial color name was correctly auto-completed.
            bool wasAutoCompleted = (Driver.FindElement(By.ClassName("auto-complete__single-value")).Text == "Blue");
            Assert.True(wasAutoCompleted, "The color blue was not auto completed when 'blu' was typed.");
        }
    }
}
