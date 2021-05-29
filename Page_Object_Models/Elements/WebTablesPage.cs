/*
Name: WebTables.cs
Purpose: Contains the Page Object Model for the web tables page on www.demoqa.com. 
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
    class WebTablesPage
    {
        private readonly IWebDriver Driver;
        private readonly string url = "https://demoqa.com/webtables";
        private readonly string mainHeader = "Web Tables";

        //Use when WebDriverWait is needed.
        private WebDriverWait Wait()
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        //Creates instance of POM.
        public WebTablesPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        //Loads the page.
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

        public void CreateNewEntry()
        {
            //Store inputs.
            const string firstName = "John";
            const string lastName = "Wick";
            const string email = "john@random.com";
            const string age = "40";
            const string salary = "10000";
            const string department = "sales";

            //Click add new record button and wait for registration form to appear.
            Driver.FindElement(By.Id("addNewRecordButton")).Click();
            Wait().Until((d) => Driver.FindElement(By.Id("registration-form-modal")));
            
            //Enter record details and submit registration form.
            Driver.FindElement(By.Id("firstName")).SendKeys(firstName);
            Driver.FindElement(By.Id("lastName")).SendKeys(lastName);
            Driver.FindElement(By.Id("userEmail")).SendKeys(email);
            Driver.FindElement(By.Id("age")).SendKeys(age);
            Driver.FindElement(By.Id("salary")).SendKeys(salary);
            Driver.FindElement(By.Id("department")).SendKeys(department);
            Driver.FindElement(By.Id("submit")).Click();

            //Verify record was added.
            var recordCount = Driver.FindElements(By.ClassName("rt-tr-group")).Count;
            var recordAdded = Driver.FindElements(By.ClassName("rt-tr-group"))[recordCount - 7];
            bool firstNameCorrect = (recordAdded.FindElements(By.ClassName("rt-td"))[0].Text == firstName);
            bool lastNameCorrect = (recordAdded.FindElements(By.ClassName("rt-td"))[1].Text == lastName);
            bool emailCorrect = (recordAdded.FindElements(By.ClassName("rt-td"))[3].Text == email);
            bool ageCorrect = (recordAdded.FindElements(By.ClassName("rt-td"))[2].Text == age);
            bool salaryCorrect = (recordAdded.FindElements(By.ClassName("rt-td"))[4].Text == salary);
            bool departmentCorrect = (recordAdded.FindElements(By.ClassName("rt-td"))[5].Text == department);

            Assert.True(firstNameCorrect, "The first name was not added to records correctly.");
            Assert.True(lastNameCorrect, "The last name was not added to records correctly.");
            Assert.True(emailCorrect, "The email address was not added to records correctly.");
            Assert.True(ageCorrect, "The age was not added to records correctly.");
            Assert.True(salaryCorrect, "The salary was not added to records correctly.");
            Assert.True(departmentCorrect, "The department was not added to records correctly.");

        }

        public void EditExistingEntry()
        {
            //Store inputs.
            const string firstName = "John";
            const string lastName = "Wick";
            const string age = "40";
            const string salary = "10000";
            const string department = "sales";

            //Find the first record, select edit, and wait for the registration form to appear.
            Driver.FindElement(By.Id("edit-record-1")).Click();
            Wait().Until((d) => Driver.FindElement(By.Id("registration-form-modal")));

            //Clear current information, add new record information, and then sumbit registration form.
            Driver.FindElement(By.Id("firstName")).Clear();
            Driver.FindElement(By.Id("firstName")).SendKeys(firstName);
            Driver.FindElement(By.Id("lastName")).Clear();
            Driver.FindElement(By.Id("lastName")).SendKeys(lastName);
            Driver.FindElement(By.Id("age")).Clear();
            Driver.FindElement(By.Id("age")).SendKeys(age);
            Driver.FindElement(By.Id("salary")).Clear();
            Driver.FindElement(By.Id("salary")).SendKeys(salary);
            Driver.FindElement(By.Id("department")).Clear();
            Driver.FindElement(By.Id("department")).SendKeys(department);
            Driver.FindElement(By.Id("submit")).Click();
            
            //Verify record was edited.
            var recordCount = Driver.FindElements(By.ClassName("rt-tr-group")).Count;
            var recordAdded = Driver.FindElements(By.ClassName("rt-tr-group"))[recordCount - 10];
            bool firstNameCorrect = (recordAdded.FindElements(By.ClassName("rt-td"))[0].Text == firstName);
            bool lastNameCorrect = (recordAdded.FindElements(By.ClassName("rt-td"))[1].Text == lastName);
            bool ageCorrect = (recordAdded.FindElements(By.ClassName("rt-td"))[2].Text == age);
            bool salaryCorrect = (recordAdded.FindElements(By.ClassName("rt-td"))[4].Text == salary);
            bool departmentCorrect = (recordAdded.FindElements(By.ClassName("rt-td"))[5].Text == department);

            Assert.True(firstNameCorrect, "The first name edit was not updated correctly.");
            Assert.True(lastNameCorrect, "The last name edit was not updated correctly.");
            Assert.True(ageCorrect, "The age edit was not updated correctly.");
            Assert.True(salaryCorrect, "The salary edit was not updated correctly.");
            Assert.True(departmentCorrect, "The department edit was not updated correctly.");
        }

        public void DeleteExistingEntry()
        {
            //Find first name in first record and store it.
            string firstNameInFirstRecord = Driver.FindElement(By.ClassName("rt-tr-group")).FindElement(By.XPath("div[1]/div")).Text;
            
            //Delete the first record and store the new first name in the first record.
            Driver.FindElement(By.Id("delete-record-1")).Click();
            string firstNameInNewFirstRecord = Driver.FindElement(By.ClassName("rt-tr-group")).FindElement(By.XPath("div[1]/div")).Text;

            //Validate record was deleted.            
            Assert.True(firstNameInFirstRecord != firstNameInNewFirstRecord, "The delete record button is no longer working.");
        }
    }
}
