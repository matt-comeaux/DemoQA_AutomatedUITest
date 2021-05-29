/*
Name: Alerts.cs
Purpose: Contains the Page Object Model for the alerts page on www.demoqa.com. 
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
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace AutomatedUITest_DemoQA.Page_Object_Models.AlertsFramesWindows
{
    class AlertsPage
    {
        private readonly IWebDriver Driver;
        private readonly string url = "https://demoqa.com/alerts";
        private readonly string mainHeader = "Alerts";
        private WebDriverWait Wait()
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        public AlertsPage(IWebDriver driver)
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

        public void OpenAlert_ClickButtonToSeeAlert()
        {
            //Click alert button, wait for it to appear, switch to it, and store the alert's text.
            Driver.FindElement(By.Id("alertButton")).Click();
            IAlert alert = Wait().Until((d) => Driver.SwitchTo().Alert());
            string alertText = alert.Text;

            //Verify the alert and accept it.
            Assert.True(alertText == "You clicked a button", "The expected alert did not open when the button with ID: 'alertButton' was clicked. ");
            alert.Accept();
        }

        public void OpenAlert_AppearAfter5Seconds()
        {
            //Click alert button, wait for it to appear, switch to it, and store the alert's text.
            Driver.FindElement(By.Id("timerAlertButton")).Click();
            IAlert alert = Wait().Until((d) => Driver.SwitchTo().Alert());
            string alertText = alert.Text;

            //Verify the alert and accept it.
            Assert.True(alertText == "This alert appeared after 5 seconds", "The expected alert did not open when the button with ID:'timerAlertButton' was clicked. ");
            alert.Accept();
        }

        public void OpenAlert_ConfirmBoxWillAppear()
        {
            //Click alert button, wait for it to appear, switch to it, and store the alert's text.
            Driver.FindElement(By.Id("confirmButton")).Click();
            IAlert alert = Wait().Until((d) => Driver.SwitchTo().Alert());
            string alertText = alert.Text;

            //Verify the alert and accept it.
            Assert.True(alertText == "Do you confirm action?", "The expected alert did not open when the button with ID:'confirmButton' was clicked. ");
            alert.Accept();

            //Wait for comfirmation message to appear and then validate the confirmation.
            var confirmationAccepted = Wait().Until((d) => Driver.FindElement(By.Id("confirmResult")));
            Assert.True(confirmationAccepted.Text == "You selected Ok", "The confirmation was accepted, but not validated.");
        }

        public void OpenAlert_PromptBoxWillAppear()
        {
            //Click alert button, wait for it to appear, switch to it, and store the alert's text.
            Driver.FindElement(By.Id("promtButton")).Click();
            IAlert alert = Wait().Until((d) => Driver.SwitchTo().Alert());
            string alertText = alert.Text;

            //Validate that the alert appeared.
            Assert.True(alertText == "Please enter your name", "The expected alert did not open when the button with ID:'promptButton' was clicked. ");

            //Send name and accept alert.
            alert.SendKeys("John");
            alert.Accept();
            
            //Validate name was sent.
            var promptValue = Wait().Until((d) => Driver.FindElement(By.Id("promptResult")).Text);
            Assert.True(promptValue == "You entered John", "The value given to the alert prompt was not successfully validated.");
        }
    }
}
