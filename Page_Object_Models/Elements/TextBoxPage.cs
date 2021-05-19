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

namespace AutomatedUITest_DemoQA.Page_Object_Models.Elements
{
    class TextBoxPage
    {
        private readonly IWebDriver Driver;
        private readonly string url = "https://demoqa.com/text-box";
        private readonly string mainHeader = "Text Box";

        private WebDriverWait Wait()
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }
        public TextBoxPage(IWebDriver driver)
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
            var name = "John Wick";
            var email = "Random@random.com";
            var currentAddress = "123 No Where Fast";
            var permanentAddress = "123 Super Secret Hideout";

            //Fill Out Form
            Driver.FindElement(By.Id("userName")).SendKeys(name);
            Driver.FindElement(By.Id("userEmail")).SendKeys(email);
            Driver.FindElement(By.Id("currentAddress")).SendKeys(currentAddress);
            Driver.FindElement(By.Id("permanentAddress")).SendKeys(permanentAddress);
            //Submit Form
            Driver.FindElement(By.Id("submit")).Click();
            //Wait for verification table.
            Wait().Until((d) => Driver.FindElement(By.Id("name")));

            //Verify results match submission.
            bool nameCorrect = (Driver.FindElement(By.Id("name")).Text == "Name:" + name);
            //WebDev used same id as text box. Using Xpath.
            bool emailCorrect = (Driver.FindElement(By.XPath("//*[@id='output']/div/p[2]")).Text == "Email:" + email);
            //WebDev used same id as text box. Using Xpath.
            bool currentAddressCorrect = (Driver.FindElement(By.XPath("//*[@id='output']/div/p[3]")).Text == "Current Address :" + currentAddress);
            //WebDev used same id as text box. Using Xpath.
            bool permanentAddressCorrect = (Driver.FindElement(By.XPath("//*[@id='output']/div/p[4]")).Text == "Permananet Address :" + permanentAddress);

            if (!nameCorrect)
            {
                throw new Exception($"The name: '{name}' was not validated properly");
            }
            else if (!emailCorrect)
            {
                throw new Exception($"The email: '{email}' was not validated properly");
            }
            else if (!currentAddressCorrect)
            {
                throw new Exception($"The current address: '{currentAddress}' was not validated properly");
            }
            else if (!permanentAddressCorrect){
                throw new Exception($"The permanent address: '{permanentAddress}' was not validated properly");
            }
        }


        public void VerifyInvalidFormsAreNotSubmitted()
        {
            var name = "John Wick";
            var email = "R"; //invalid email
            var currentAddress = "123 No Where Fast";
            var permanentAddress = "123 Super Secret Hideout";

            //Fill Out Form
            Driver.FindElement(By.Id("userName")).SendKeys(name);
            Driver.FindElement(By.Id("userEmail")).SendKeys(email);
            Driver.FindElement(By.Id("currentAddress")).SendKeys(currentAddress);
            Driver.FindElement(By.Id("permanentAddress")).SendKeys(permanentAddress);
            //Submit Form
            Driver.FindElement(By.Id("submit")).Click();
            //Check that form was not submitted
            bool submissionStopped = Driver.FindElement(By.ClassName("field-error")).Displayed;
            if (!submissionStopped)
            {
                throw new Exception($"A form with an invalid email was allowed to be submitted.");
            }
        }
    }
}
