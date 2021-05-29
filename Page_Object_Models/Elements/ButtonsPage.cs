/*
Name: Buttons.cs
Purpose: Contains the Page Object Model for the buttons page on www.demoqa.com. 
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
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace AutomatedUITest_DemoQA.Page_Object_Models.Elements
{
    class ButtonsPage
    {
        private readonly IWebDriver Driver;
        private readonly string url = "https://demoqa.com/buttons";
        private readonly string mainHeader = "Buttons";

        //Use whenever WebDriverWait is needed.
        private WebDriverWait Wait()
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        //Creates instance of POM.
        public ButtonsPage(IWebDriver driver)
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

        public void ClickButton_DoubleClickMe()
        {
            //Double click button.
            Actions action = new Actions(Driver);
            var button = Driver.FindElement(By.Id("doubleClickBtn"));
            action.MoveToElement(button);
            action.DoubleClick();
            action.Perform();

            //Wait for confirmation text to appear.
            var confirmationText = Wait().Until((d) => Driver.FindElement(By.Id("doubleClickMessage"))).Text;

            //Validate that double click button was clicked.
            Assert.True(confirmationText == "You have done a double click", "The button titled 'Double Click Me' is not working properly.");
        }

        public void ClickButton_RightClickMe()
        {
            //Right click button.
            Actions action = new Actions(Driver);
            var button = Driver.FindElement(By.Id("rightClickBtn"));
            action.MoveToElement(button);
            action.ContextClick();
            action.Perform();

            //Wait for confirmation text.
            var confirmationText = Wait().Until((d) => Driver.FindElement(By.Id("rightClickMessage"))).Text;

            //Validate right click button was right clicked.
            Assert.True(confirmationText == "You have done a right click", "The button titled 'Right Click Me' is not working properly.");
         }

        public void ClickButton_ClickMe()
        {

            //Click button
            Actions action = new Actions(Driver);
            var button = Driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div[3]/button")); //Button has dynamic Id thus xpath.
            action.MoveToElement(button);
            action.Click();
            action.Perform();

            //Wait for confirmation text.
            var confirmationText = Wait().Until((d) => Driver.FindElement(By.Id("dynamicClickMessage"))).Text;

            //Validate button was clicked.
            Assert.True(confirmationText == "You have done a dynamic click", "The button titled 'Click Me' is not working properly.");
        }

    }
}
