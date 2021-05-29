/*
Name: TextBox.cs
Purpose: Contains the Page Object Model for the text box page on www.demoqa.com. 
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
    class TextBoxPage
    {
        private readonly IWebDriver Driver;
        private readonly string url = "https://demoqa.com/text-box";
        private readonly string mainHeader = "Text Box";

        //Use when WebDriverWait is needed.
        private WebDriverWait Wait()
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        //Creates instance of POM.
        public TextBoxPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        //Loads the page.
        public void LoadPage()
        {
            Driver.Navigate().GoToUrl(url);
            EnsurePageLoaded();
        }

        //Validates that the correct page loaded.
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
            //Store inputs
            const string name = "John Wick";
            const string email = "Random@random.com";
            const string currentAddress = "123 No Where Fast";
            const string permanentAddress = "123 Super Secret Hideout";

            //Fill out form and submit.
            Driver.FindElement(By.Id("userName")).SendKeys(name);
            Driver.FindElement(By.Id("userEmail")).SendKeys(email);
            Driver.FindElement(By.Id("currentAddress")).SendKeys(currentAddress);
            Driver.FindElement(By.Id("permanentAddress")).SendKeys(permanentAddress);
            Driver.FindElement(By.Id("submit")).Click();

            //Wait for verification table.
            Wait().Until((d) => Driver.FindElement(By.Id("name")));

            //Verify results match submission.
            bool nameCorrect = (Driver.FindElement(By.Id("name")).Text == "Name:" + name);
            bool emailCorrect = (Driver.FindElement(By.XPath("//*[@id='output']/div/p[2]")).Text == "Email:" + email); //WebDev used same id as text box. Using Xpath.
            bool currentAddressCorrect = (Driver.FindElement(By.XPath("//*[@id='output']/div/p[3]")).Text == "Current Address :" + currentAddress); //WebDev used same id as text box. Using Xpath.
            bool permanentAddressCorrect = (Driver.FindElement(By.XPath("//*[@id='output']/div/p[4]")).Text == "Permananet Address :" + permanentAddress); //WebDev used same id as text box. Using Xpath.

            Assert.True(nameCorrect, "The name: " + name + " was not validated properly");
            Assert.True(emailCorrect, "The email: " + email + " was not validated properly");
            Assert.True(currentAddressCorrect, "The current address: " + currentAddress + " was not validated properly");
            Assert.True(permanentAddressCorrect, "The permanent address: " + permanentAddress + " was not validated properly");
        }


        public void VerifyInvalidFormsAreNotSubmitted()
        {
            //Store inputs
            const string name = "John Wick";
            const string email = "R"; //invalid email
            const string currentAddress = "123 No Where Fast";
            const string permanentAddress = "123 Super Secret Hideout";

            //Fill out form and attempt to submit.
            Driver.FindElement(By.Id("userName")).SendKeys(name);
            Driver.FindElement(By.Id("userEmail")).SendKeys(email);
            Driver.FindElement(By.Id("currentAddress")).SendKeys(currentAddress);
            Driver.FindElement(By.Id("permanentAddress")).SendKeys(permanentAddress);
            Driver.FindElement(By.Id("submit")).Click();

            //Verify that the form was NOT submitted.
            Assert.True(Driver.FindElement(By.ClassName("field-error")).Displayed, "A form with an invalid email was allowed to be submitted.");
        }
    }
}
