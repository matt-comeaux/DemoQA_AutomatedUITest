/*
Name: PracticeForms.cs
Purpose: Contains the Page Object Model for the practice forms page on www.demoqa.com. 
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

namespace AutomatedUITest_DemoQA.Page_Object_Models.Forms
{
    class PracticeFormsPage
    {
        private readonly IWebDriver Driver;
        private readonly string url = "https://demoqa.com/automation-practice-form";
        private readonly string mainHeader = "Practice Form";

        //Use for waits.
        private WebDriverWait Wait(int seconds)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
        }

        public PracticeFormsPage(IWebDriver driver)
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

        public void SubmitValidForm()
        {
            //Set input values.
            const string firstName = "John";
            const string lastname = "Smith";
            const string email = "JohnSmith@random.com";
            const string mobileNumber = "1234567899";
            const string dateOfBirth = "10 March 1990";
            const string subject1 = "Maths";
            const string subject2 = "Arts";
            const string currentAddress = "101 Schoolyard Ave";
            const string state = "Haryana";
            const string city = "Karnal";
            
            //Enter form info and submit
            Driver.FindElement(By.Id("firstName")).SendKeys(firstName);
            Driver.FindElement(By.Id("lastName")).SendKeys(lastname);
            Driver.FindElement(By.Id("userEmail")).SendKeys(email);
            Driver.ExecuteJavaScript("document.getElementById('gender-radio-1').click()"); //Male
            Driver.FindElement(By.Id("userNumber")).SendKeys(mobileNumber);
            Driver.FindElement(By.Id("dateOfBirthInput")).SendKeys(Keys.Control + 'a'); // Select all. The '.clear()' method doesn't work here. 
            Driver.FindElement(By.Id("dateOfBirthInput")).SendKeys(dateOfBirth);
            Driver.FindElement(By.Id("subjectsInput")).SendKeys(subject1);
            Wait(5).Until((d) => Driver.FindElement(By.Id("react-select-2-option-0"))).Click();
            Driver.FindElement(By.Id("subjectsInput")).SendKeys(subject2);
            Wait(5).Until((d) => Driver.FindElement(By.Id("react-select-2-option-0"))).Click();
            Driver.ExecuteJavaScript("document.getElementById('hobbies-checkbox-1').click()"); //Sports checkbox
            Driver.ExecuteJavaScript("document.getElementById('hobbies-checkbox-2').click()"); //Reading checkbox
            Driver.ExecuteJavaScript("document.getElementById('hobbies-checkbox-3').click()"); //Music checkbox
            Driver.FindElement(By.Id("currentAddress")).SendKeys(currentAddress);
            Driver.FindElement(By.Id("react-select-3-input")).SendKeys(state);
            Wait(5).Until((d) => Driver.FindElement(By.Id("react-select-3-option-2"))).Click();
            Driver.FindElement(By.Id("react-select-4-input")).SendKeys(city);
            Wait(5).Until((d) => Driver.FindElement(By.Id("react-select-4-option-0"))).Click();
            Driver.FindElement(By.Id("submit")).Click();

            //Collect Submitted Form Info
            Wait(5).Until((d) => Driver.FindElement(By.Id("example-modal-sizes-title-lg"))); //Wait until submitted results are displayed.
            var studentNameValue = 
                Driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/table/tbody/tr[1]/td[2]")).Text;
            var studentEmailValue =
                Driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/table/tbody/tr[2]/td[2]")).Text;
            var genderValue = 
                Driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/table/tbody/tr[3]/td[2]")).Text;
            var mobileNumberValue = 
                Driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/table/tbody/tr[4]/td[2]")).Text;
            var dateOfBirthValue = 
                Driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/table/tbody/tr[5]/td[2]")).Text;
            var subjectsValue = 
                Driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/table/tbody/tr[6]/td[2]")).Text;
            var hobbyValue = 
                Driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/table/tbody/tr[7]/td[2]")).Text;
            var currentAddressValue = 
                Driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/table/tbody/tr[9]/td[2]")).Text;
            var stateAndCityValue = 
                Driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/table/tbody/tr[10]/td[2]")).Text;

            //Create Truth Statements.
            bool studentNameCorrect = (studentNameValue == firstName + " " + lastname);
            bool emailCorrect = (studentEmailValue == email);
            bool genderCorrect = (genderValue == "Male");
            bool mobileNumberCorrect = (mobileNumberValue == mobileNumber);
            bool dateOfBirthCorrect = (dateOfBirthValue == "10 March,1990"); //can't use DOB const as the submitted value will change format
            bool subjectsCorrect = (subjectsValue == subject1 + ", " + subject2); //Add comma and space after each subject
            bool hobbiesCorrect = (hobbyValue == "Sports, Reading, Music");
            bool currentAddressCorrect = (currentAddressValue == currentAddress);
            bool stateAndCityCorrect = (stateAndCityValue == state + " " + city);

            Assert.True(studentNameCorrect, 
                "The student name was not submitted properly. Submitted name:" + firstName + " " + lastname + " Actual Result:" + studentNameValue);
            Assert.True(emailCorrect, 
                "The email was not submitted properly. Submitted email:" + email + " Actual Result: " + studentEmailValue);
            Assert.True(genderCorrect, 
                "The gender was not submitted properly.Submitted gender: 'Male' " + " Actual Result: " + genderValue);
            Assert.True(mobileNumberCorrect, 
                "The mobile number was not submitted properly. Submitted number: " + mobileNumber + " Actual Result: " + mobileNumberValue);
            Assert.True(dateOfBirthCorrect,
                "The date of birth was not submitted properly. Submitted DOB: " + dateOfBirth + " Actual Result: " + dateOfBirthValue);
            Assert.True(subjectsCorrect,
                "The subjects were not submitted properly. Submitted subjects: " + subject1 +" "+ subject2 + " Actual Result: " + subjectsValue);
            Assert.True(hobbiesCorrect,
                "The hobbies were not submitted properly. Submitted hobbies: Sports, Reading, Music. Actual Result: " + hobbyValue);
            Assert.True(currentAddressCorrect,
                "The current address was not submitted properly. Submitted address: " + currentAddress + " Actual Result: " + currentAddressValue);
            Assert.True(stateAndCityCorrect,
                "The state and city were not submitted properly. Submitted info: " + state + " " + city + " Actual Result: " + stateAndCityValue);
        }

        public void SubmitInvalidForm()
        {
            //Set input values.
            const string firstName = "John";
            const string lastname = "Smith";
            const string email = "JohnSmith"; //Invalid email
            const string mobileNumber = "1234567899";
            const string dateOfBirth = "10 March 1990";
            const string subject1 = "Maths";
            const string subject2 = "Arts";
            const string currentAddress = "101 Schoolyard Ave";
            const string state = "Haryana";
            const string city = "Karnal";

            //Enter form info and submit
            Driver.FindElement(By.Id("firstName")).SendKeys(firstName);
            Driver.FindElement(By.Id("lastName")).SendKeys(lastname);
            Driver.FindElement(By.Id("userEmail")).SendKeys(email);
            Driver.ExecuteJavaScript("document.getElementById('gender-radio-1').click()"); //Male
            Driver.FindElement(By.Id("userNumber")).SendKeys(mobileNumber);
            Driver.FindElement(By.Id("dateOfBirthInput")).SendKeys(Keys.Control + 'a'); // Select all. The '.clear()' method doesn't work here. 
            Driver.FindElement(By.Id("dateOfBirthInput")).SendKeys(dateOfBirth);
            Driver.FindElement(By.Id("subjectsInput")).SendKeys(subject1);
            Wait(5).Until((d) => Driver.FindElement(By.Id("react-select-2-option-0"))).Click();
            Driver.FindElement(By.Id("subjectsInput")).SendKeys(subject2);
            Wait(5).Until((d) => Driver.FindElement(By.Id("react-select-2-option-0"))).Click();
            Driver.ExecuteJavaScript("document.getElementById('hobbies-checkbox-1').click()"); //Sports checkbox
            Driver.ExecuteJavaScript("document.getElementById('hobbies-checkbox-2').click()"); //Reading checkbox
            Driver.ExecuteJavaScript("document.getElementById('hobbies-checkbox-3').click()"); //Music checkbox
            Driver.FindElement(By.Id("currentAddress")).SendKeys(currentAddress);
            Driver.FindElement(By.Id("react-select-3-input")).SendKeys(state);
            Wait(5).Until((d) => Driver.FindElement(By.Id("react-select-3-option-2"))).Click();
            Driver.FindElement(By.Id("react-select-4-input")).SendKeys(city);
            Wait(5).Until((d) => Driver.FindElement(By.Id("react-select-4-option-0"))).Click();
            Driver.FindElement(By.Id("submit")).Click();

            //Verify form didn't submit
            bool formSubmitted;
            try
            {
                Driver.FindElement(By.Id("example-modal-sizes-title-lg"));
                formSubmitted = true;
            }
            catch (NoSuchElementException)
            {
                formSubmitted = false;
            }

            Assert.False(formSubmitted, "The form submitted with an invalid email");
        }
    }
}
