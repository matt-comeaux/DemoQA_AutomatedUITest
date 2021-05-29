/*
Name: ToolTips.cs
Purpose: Contains the Page Object Model for the tool tips page on www.demoqa.com. 
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

namespace AutomatedUITest_DemoQA.Page_Object_Models.Widgets
{
    class ToolTipsPage
    {
        private readonly IWebDriver Driver;
        private readonly string url = "https://demoqa.com/tool-tips";
        private readonly string mainHeader = "Tool Tips";

        //Use whenever WebDriverWait is needed.
        private WebDriverWait Wait()
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        //Create instance of POM.
        public ToolTipsPage(IWebDriver driver)
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

        public void DisplayToolTip_HoverOverButton()
        {
            //Find hover over me button. Create instance of Actions.
            var button = Driver.FindElement(By.Id("toolTipButton"));
            Actions action = new Actions(Driver);

            //Hover over target button and wait for tool tip to display.
            action.MoveToElement(button);
            action.Perform();
            Wait().Until((d) => Driver.FindElement(By.ClassName("tooltip-inner")).Text);

            //Validate the tooltip appeared and is displaying correct message.
            var toolTip = Driver.FindElement(By.ClassName("tooltip-inner"));
            Assert.True(toolTip.Text == "You hovered over the Button");
        }

        public void DisplayToolTip_HoverOverField()
        {
            //Find hover over me field. Create instance of Actions.
            var button = Driver.FindElement(By.Id("toolTipTextField"));
            Actions action = new Actions(Driver);

            //Hover over button and wait for tool tip to display.
            action.MoveToElement(button);
            action.Perform();
            Wait().Until((d) => Driver.FindElement(By.ClassName("tooltip-inner")).Text);

            //Validate the tooltip appeared and is displaying correct message.
            var toolTip = Driver.FindElement(By.ClassName("tooltip-inner"));
            Assert.True(toolTip.Text == "You hovered over the text field");
        }

        public void DisplayToolTip_ContraryLink()
        {
            //Find the contrary link. Create instance of Actions.
            var link = Driver.FindElement(By.Id("texToolTopContainer")).FindElement(By.LinkText("Contrary"));
            Actions action = new Actions(Driver);

            //Hover over link and wait for tool tip to display.
            action.MoveToElement(link);
            action.Perform();
            Wait().Until((d) => Driver.FindElement(By.ClassName("tooltip-inner")).Text);

            //Validate the tooltip appeared and is displaying correct message.
            var toolTip = Driver.FindElement(By.ClassName("tooltip-inner"));
            Assert.True(toolTip.Text == "You hovered over the Contrary");
        }

        public void DisplayToolTip_SectionLink()
        {
            //Find the 1.10.32 link. Create instance of Actions.
            var link = Driver.FindElement(By.Id("texToolTopContainer")).FindElement(By.LinkText("1.10.32"));
            Actions action = new Actions(Driver);

            //Hover over link and wait for tool tip to display.
            action.MoveToElement(link);
            action.Perform();
            Wait().Until((d) => Driver.FindElement(By.ClassName("tooltip-inner")).Text);

            //Validate the tooltip appeared and is displaying correct message.
            var toolTip = Driver.FindElement(By.ClassName("tooltip-inner"));
            Assert.True(toolTip.Text == "You hovered over the 1.10.32");
        }
    }
}
