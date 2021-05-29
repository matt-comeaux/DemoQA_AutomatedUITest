/*
Name: RadioButton.cs
Purpose: Contains the Page Object Model for the radio button page on www.demoqa.com. 
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
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace AutomatedUITest_DemoQA.Page_Object_Models.Elements
{
    class RadioButtonPage
    {
        private readonly IWebDriver Driver;
        private readonly string url = "https://demoqa.com/radio-button";
        private readonly string mainHeader = "Radio Button";

        //Use when WebDriverWait is needed.
        private WebDriverWait Wait()
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        //Creates instance of POM.
        public RadioButtonPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        //Loads page.
        public void LoadPage()
        {
            Driver.Navigate().GoToUrl(url);
            EnsurePageLoaded();
        }

        //Validates that page loaded correctly.
        public void EnsurePageLoaded()
        {
            bool isLoaded = (Driver.Url == url) && (Driver.FindElement(By.ClassName("main-header")).Text == mainHeader);

            if (!isLoaded)
            {
                throw new Exception($"The requested page did not load correctly. The page url is: '{url}' The page source is: \r\n '{Driver.PageSource}'");
            }
        }

        public void SelectRadioButton_Yes()
        {
            //Click radio button and store the response.
            //For some reason the label for the radio button is programmed in such a way that it blocks Selenium from clicking button normally.
            Driver.ExecuteJavaScript("document.getElementById('yesRadio').click()");
            var clickConfirmation = Wait().Until((d) => Driver.FindElement(By.ClassName("text-success")).Text);

            //Validate radio button was selected.
            Assert.True(clickConfirmation == "Yes", "The selected radio button is no longer working");
        }

        public void SelectRadioButton_Impressive()
        {
            //Click radio button and store the response.
            //For some reason the label for the radio button is programmed in such a way that it blocks Selenium from clicking button normally.
            Driver.ExecuteJavaScript("document.getElementById('impressiveRadio').click()");
            var clickConfirmation = Wait().Until((d) => Driver.FindElement(By.ClassName("text-success")).Text);

            //Validate radio button was selected.
            Assert.True(clickConfirmation == "Impressive", "The selected radio button is no longer working");
        }

        public void SelectRadioButton_No()
        {
            //This radio button should be disabled.
            var radioButtonStatus = Driver.FindElement(By.Id("noRadio")).GetAttribute("disabled");

            //Validate radio button is disabled. True must be lower-case.
            Assert.True(radioButtonStatus == "true", "The referenced radio button with the id of 'noRadio' is no longer disabled.");
        }
    }
}
