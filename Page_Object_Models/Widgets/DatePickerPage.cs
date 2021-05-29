/*
Name: DatePicker.cs
Purpose: Contains the Page Object Model for the date picker page on www.demoqa.com. 
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
    class DatePickerPage
    {
        private readonly IWebDriver Driver;
        private readonly string url = "https://demoqa.com/date-picker";
        private readonly string mainHeader = "Date Picker";

        //Create instance of POM.
        public DatePickerPage(IWebDriver driver)
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

        public void AutoSelect_SelectDateField()
        {
            //Find date input field and store the unformated date we want to send it.
            var input = Driver.FindElement(By.Id("datePickerMonthYearInput"));
            var unformatedDate = "3/3/2007";

            //Send unformated date and press enter key.
            input.SendKeys(Keys.Control + "a"); //.Clear() will not work here.
            input.SendKeys(unformatedDate);
            input.SendKeys(Keys.Enter);

            //Validate that the correct date was auto-selected from the sent unformated date.
            var autoSelectedDate = input.GetAttribute("value");
            bool wasAutoCompleted = (autoSelectedDate == "03/03/2007");
            Assert.True(wasAutoCompleted, "The date 03/03/2007 was not auto selected when the text: " + unformatedDate + " was entered. The text output was: " + autoSelectedDate);

        }

        public void AutoSelect_DateAndTimeField()
        {
            //Find date-time input field and store the unformated date-time we want to send it.
            var input = Driver.FindElement(By.Id("dateAndTimePickerInput"));
            var unformatedDate = "3/3/2007 11:30";

            //Send unformated date-time and press enter.
            input.SendKeys(Keys.Control + "a"); //.Clear() will not work here.
            input.SendKeys(unformatedDate);
            input.SendKeys(Keys.Enter);

            //Validate that the correct date-time was auto-selected from the sent unformated date-time.
            var autoSelectedDate = input.GetAttribute("value");
            bool wasAutoCompleted = (autoSelectedDate == "March 3, 2007 11:30 AM");
            Assert.True(wasAutoCompleted, "The date March 3, 2007 11:30 AM was not auto selected when the text: " + unformatedDate + " was entered. The text output was: " + autoSelectedDate);
        }
    }
}
