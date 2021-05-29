/*
Name: SelectMenu.cs
Purpose: Contains the Page Object Model for the select menu page on www.demoqa.com. 
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

//The actual webpage for these menus was programmed horribly. Some of the tests were limited by this.

using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace AutomatedUITest_DemoQA.Page_Object_Models.Widgets
{
    class SelectMenuPage
    {
        private readonly IWebDriver Driver;
        private readonly string url = "https://demoqa.com/select-menu";
        private readonly string mainHeader = "Select Menu";

        //Create instance of POM.
        public SelectMenuPage(IWebDriver driver)
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

        public void SelectFrom_SelectValueField()
        {
            //Find select value field and click it to activate its drop down menu.
            var field = Driver.FindElement(By.Id("withOptGroup"));
            field.Click();
            
            //Select value from drop down menu. 
            var targetValue = Driver.FindElement(By.Id("react-select-2-option-0-0")); //Group1, option 1
            targetValue.Click();

            //Find field value and validate the correct option was chosen.
            var fieldValue = Driver.FindElement(By.ClassName("css-1uccc91-singleValue"));
            Assert.True(fieldValue.Text == "Group 1, option 1", "The target value was not selected from the drop down menu");
        }

        public void SelectFrom_SelectOneField()
        {
            //NOTE: The target value and field value variables were found using methods other than id.
            //      This is because the id's for these two fields were dynamically generated for some reason.
            //      These are the only two fields like this on the entire page.

            //Find select one field and click it to activate its drop down menu.
            var field = Driver.FindElement(By.Id("selectOne"));
            field.Click();

            //Select target value from drop down menu.
            var targetValue = Driver.FindElement(By.ClassName("css-1n7v3ny-option")); //Dr.
            targetValue.Click();

            //Find field value and validate the correct option was chosen.
            var fieldValue = Driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div[4]/div/div/div/div[1]/div[1]"));
            Assert.True(fieldValue.Text == "Dr.", "The target value was not selected from the drop down menu");
        }

        public void SelectFrom_OldStyleMenu()
        {
            //Find old style menu and select the color 'yellow'.
            SelectElement field = new SelectElement(Driver.FindElement(By.Id("oldSelectMenu")));
            field.SelectByText("Yellow");
            
            //Currently no way to check to see if this was completed due to how this menu was programmed by the developer...
        }

        public void SelectFrom_MultiSelectDropDown()
        {
            //Find the multi select field. Send the colors blue and black.
            var field = Driver.FindElement(By.Id("react-select-4-input"));
            field.SendKeys("Blue");
            field.SendKeys(Keys.Enter);
            field.SendKeys("Black");
            field.SendKeys(Keys.Enter);

            //Find field values and validate the correct values were selected from drop down.
            var fieldValues = Driver.FindElements(By.ClassName("css-12jo7m5"));
            for (int i = 0; i < fieldValues.Count; i++)
            {
                string[] colors = { "Blue", "Black" }; //Must be in order entered
                Assert.True(fieldValues[i].Text == colors[i]);
            }
        }

        public void SelectFrom_StandardDropDown()
        {
            //Find the standard drop down menu and select the car 'volvo'.
            SelectElement field = new SelectElement(Driver.FindElement(By.Id("cars")));
            field.SelectByText("Volvo");

            //Currently no way to check to see if this was completed due to how this menu was programmed by the developer.
        }
    }
}
