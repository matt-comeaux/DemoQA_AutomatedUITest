/*
Name: ProgressBar.cs
Purpose: Contains the Page Object Model for the progress bar page on www.demoqa.com. 
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

namespace AutomatedUITest_DemoQA.Page_Object_Models.Widgets
{
    class ProgressBarPage
    {
        private readonly IWebDriver Driver;
        private readonly string url = "https://demoqa.com/progress-bar";
        private readonly string mainHeader = "Progress Bar";

        //Use whenever WebDriverWait is needed.
        private WebDriverWait Wait()
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        //Create instance of POM.
        public ProgressBarPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        //Load page.
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

        public void StartProgressBar()
        {
            //Find the start/stop button and the progress bar visual.
            var trigger = Driver.FindElement(By.Id("startStopButton")); //This is the start/stop button
            var progressBar = Driver.FindElement(By.ClassName("progress-bar")); //This is container for the progress bar percentage.

            //Click the start button and wait 150 miliseconds. This is to give the progress bar time to update.
            trigger.Click();
            Thread.Sleep(150);

            //Validate that the progress bar was started.
            bool wasActivated = (progressBar.GetAttribute("aria-valuenow") != "0");
            Assert.True(wasActivated, "The progress bar was not activated.");
        }

        public void StopProgressBar()
        {
            //Find the start/stop button and the progress bar visual.
            var trigger = Driver.FindElement(By.Id("startStopButton")); //This is the start/stop button
            var progressBar = Driver.FindElement(By.ClassName("progress-bar")); //This is container for the progress bar percentage.

            //Start the progress bar and then stop it.
            trigger.Click();//Start
            trigger.Click(); //Stop

            //Validate that the progress bar was stopped.
            var progress1 = progressBar.GetAttribute("aria-valuenow");
            var progress2 = progressBar.GetAttribute("aria-valuenow");
            Assert.True(progress1 == progress2, "The progress bar was not stopped!");
        }

        public void StopProgressBarOnSpecificPercent()
        {
            //Find the start/stop button and the progress bar visual.
            var trigger = Driver.FindElement(By.Id("startStopButton")); //This is the start/stop button
            var progressBar = Driver.FindElement(By.ClassName("progress-bar")); //This is container for the progress bar percentage.

            //Start progress bar, wait until it reaches 25%, and then stop the progress bar.
            trigger.Click(); //Start
            Wait().Until((d) => progressBar.GetAttribute("aria-valuenow") == "25");
            trigger.Click(); //Stop

            //Validate the status bar is displaying the correct percent.
            var displayedCorrectly = (progressBar.GetAttribute("aria-valuenow") == "25");
            Assert.True(displayedCorrectly);
        }
    }
}
