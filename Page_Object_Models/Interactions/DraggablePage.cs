/*
Name: Draggable.cs
Purpose: Contains the Page Object Model for the draggable page on www.demoqa.com. 
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
using Xunit;

namespace AutomatedUITest_DemoQA.Page_Object_Models.Interactions
{
    class DraggablePage
    {
        private readonly IWebDriver Driver;
        private readonly string url = "https://demoqa.com/dragabble";
        private readonly string mainHeader = "Dragabble";

        public DraggablePage(IWebDriver driver)
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

        public void DragIcon_SimpleTab()
        {
            var targetIcon = Driver.FindElement(By.Id("dragBox"));
            var currentPosition = targetIcon.Location;
            Actions action = new Actions(Driver);

            action.DragAndDropToOffset(targetIcon,277,208);
            action.Perform();
            var newPosition = targetIcon.Location;

            //Check dragging of icon is working as intended.
            bool changedLocations = (currentPosition != newPosition);
            Assert.True(changedLocations, "The selected icon did not change locations.");
        }

        public void DragXAxis_AccessRestrictedTab()
        {
            Driver.FindElement(By.Id("draggableExample-tab-axisRestriction")).Click();
            var targetIcon = Driver.FindElement(By.Id("restrictedX"));
            var currentPosition = targetIcon.Location;
            Actions action = new Actions(Driver);

            action.DragAndDropToOffset(targetIcon, 277, 208);
            action.Perform();
            var newPosition = targetIcon.Location;

            //Check dragging of icon is working as intended.
            bool changedLocations = (currentPosition != newPosition);
            bool didNotChangeYPosition = (currentPosition.Y == newPosition.Y);
            Assert.True(changedLocations, "The selected icon did not change locations.");
            Assert.True(didNotChangeYPosition, "The Y position has changed when it should be locked.");
        }

        public void DragYAxis_AccessRestrictedTab()
        {
            Driver.FindElement(By.Id("draggableExample-tab-axisRestriction")).Click();
            var targetIcon = Driver.FindElement(By.Id("restrictedY"));
            var currentPosition = targetIcon.Location;
            Actions action = new Actions(Driver);

            action.DragAndDropToOffset(targetIcon, 277, 208);
            action.Perform();
            var newPosition = targetIcon.Location;

            //Check dragging of icon is working as intended.
            bool changedLocations = (currentPosition != newPosition);
            bool didNotChangeXPosition = (currentPosition.X == newPosition.X);
            Assert.True(changedLocations, "The selected icon did not change locations.");
            Assert.True(didNotChangeXPosition, "The X position has changed when it should be locked.");
        }

        public void DragBoxIcon_ContainerRestricedTab()
        {
            Driver.FindElement(By.Id("draggableExample-tab-containerRestriction")).Click();
            var targetIcon = Driver.FindElement(By.XPath("//*[@id='draggableExample-tabpane-containerRestriction']/div/div"));
            var currentPosition = targetIcon.Location;
            var invalidLocation = Driver.FindElement(By.XPath("//*[@id='draggableExample-tabpane-containerRestriction']/div[2]/span"));

            Actions action = new Actions(Driver);

            action.DragAndDrop(targetIcon, invalidLocation);
            action.Perform();
            var newPosition = targetIcon.Location;

            //Check dragging of icon is working as intended.
            bool changedLocations = (currentPosition != newPosition);
            bool didNotLeaveContainer = (newPosition != invalidLocation.Location);
            Assert.True(changedLocations, "The selected icon did not change locations.");
            Assert.True(didNotLeaveContainer, "The selected icon left its container and was moved to an ivalid location.");
        }

        public void DragParentIcon_ContainerRestricedTab()
        {
            Driver.FindElement(By.Id("draggableExample-tab-containerRestriction")).Click();
            var targetIcon = Driver.FindElement(By.XPath("//*[@id='draggableExample-tabpane-containerRestriction']/div[2]/span"));
            var currentPosition = targetIcon.Location;
            var invalidLocation = Driver.FindElement(By.XPath("//*[@id='draggableExample-tabpane-containerRestriction']/div/div"));

            Actions action = new Actions(Driver);

            action.DragAndDrop(targetIcon, invalidLocation);
            action.Perform();
            var newPosition = targetIcon.Location;

            //Check dragging of icon is working as intended.
            bool changedLocations = (currentPosition != newPosition);
            bool didNotLeaveContainer = (newPosition != invalidLocation.Location);
            Assert.True(changedLocations, "The selected box did not change locations.");
            Assert.True(didNotLeaveContainer, "The selected box left its container and was moved to an ivalid location.");
        }

        public void DragCenterIcon_CursorStyleTab()
        {
            //Go to cursor style tab.
            Driver.FindElement(By.Id("draggableExample-tab-cursorStyle")).Click();
            var targetIcon = Driver.FindElement(By.Id("cursorCenter"));
            var currentPosition = targetIcon.Location;
            Actions action = new Actions(Driver);

            action.DragAndDropToOffset(targetIcon, 277, 208);
            action.Perform();
            var newPosition = targetIcon.Location;

            //Check dragging of icon is working as intended.
            bool changedLocations = (currentPosition != newPosition);
            Assert.True(changedLocations, "The selected icon did not change locations.");
        }

        public void DragTopLeftIcon_CursorStyleTab()
        {
            //Go to cursor style tab.
            Driver.FindElement(By.Id("draggableExample-tab-cursorStyle")).Click();
            var targetIcon = Driver.FindElement(By.Id("cursorTopLeft"));
            var currentPosition = targetIcon.Location;
            Actions action = new Actions(Driver);

            action.DragAndDropToOffset(targetIcon, 277, 208);
            action.Perform();
            var newPosition = targetIcon.Location;

            //Check dragging of icon is working as intended.
            bool changedLocations = (currentPosition != newPosition);
            Assert.True(changedLocations, "The selected icon did not change locations.");
        }

        public void DragBottomIcon_CursorStyleTab()
        {
            //Go to cursor style tab.
            Driver.FindElement(By.Id("draggableExample-tab-cursorStyle")).Click();
            var targetIcon = Driver.FindElement(By.Id("cursorBottom"));
            var targetLocation = Driver.FindElement(By.Id("cursorTopLeft")); //Have to use this element as target location as putting in a valid offset is throwing out of bounds error.
            var currentPosition = targetIcon.Location;
            Actions action = new Actions(Driver);

            action.DragAndDrop(targetIcon, targetLocation);
            action.Perform();
            var newPosition = targetIcon.Location;

            //Check dragging of icon is working as intended.
            bool changedLocations = (currentPosition != newPosition);
            Assert.True(changedLocations, "The selected icon did not change locations.");
        }
    }
}
