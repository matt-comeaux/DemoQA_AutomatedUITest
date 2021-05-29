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

        //Create instance of POM.
        public DraggablePage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        //Loads page.
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

        public void DragIcon_SimpleTab()
        {
            //Find icon to be dragged, along with its location, and store them. Then create instance of Actions.
            var targetIcon = Driver.FindElement(By.Id("dragBox"));
            var oldPosition = targetIcon.Location;
            Actions action = new Actions(Driver);

            //Drag targeted icon to new location. Store its new location.
            action.DragAndDropToOffset(targetIcon,277,208);
            action.Perform();
            var newPosition = targetIcon.Location;

            //Validate dragging of icon is working as intended.
            Assert.True(oldPosition != newPosition, "The selected icon did not change locations.");
        }

        public void DragXAxis_AxisRestrictedTab()
        {
            //Navigate to the axis restricted tab.   
            Driver.FindElement(By.Id("draggableExample-tab-axisRestriction")).Click();

            //Find icon to be dragged, along with its location, and store them. Then create instance of Actions.
            var targetIcon = Driver.FindElement(By.Id("restrictedX"));
            var oldPosition = targetIcon.Location;
            Actions action = new Actions(Driver);

            //Drag targeted icon to new location. Store its new location.
            action.DragAndDropToOffset(targetIcon, 277, 208);
            action.Perform();
            var newPosition = targetIcon.Location;

            //Validate icon was dragged only across the y-axis.
            Assert.True(oldPosition != newPosition, "The selected icon did not change locations.");
            Assert.True(oldPosition.Y == newPosition.Y, "The Y position has changed when it should be locked.");
        }

        public void DragYAxis_AxisRestrictedTab()
        {
            //Navigate to the axis restricted tab.
            Driver.FindElement(By.Id("draggableExample-tab-axisRestriction")).Click();

            //Find icon to be dragged, along with its location, and store them. Then create instance of Actions.
            var targetIcon = Driver.FindElement(By.Id("restrictedY"));
            var oldPosition = targetIcon.Location;
            Actions action = new Actions(Driver);

            //Drag targeted icon to new location. Store its new location.
            action.DragAndDropToOffset(targetIcon, 277, 208);
            action.Perform();
            var newPosition = targetIcon.Location;

            //Validate icon was dragged only across the y-axis.
            Assert.True(oldPosition != newPosition, "The selected icon did not change locations.");
            Assert.True(oldPosition.X == newPosition.X, "The X position has changed when it should be locked.");
        }

        public void DragBoxIcon_ContainerRestricedTab()
        {
            //Navigate to the container restriced tab.
            Driver.FindElement(By.Id("draggableExample-tab-containerRestriction")).Click();

            //Find icon to be dragged and its location.Then find an invalid location and create instance of Actions.
            var targetIcon = Driver.FindElement(By.XPath("//*[@id='draggableExample-tabpane-containerRestriction']/div/div"));
            var oldPosition = targetIcon.Location;
            var invalidLocation = Driver.FindElement(By.XPath("//*[@id='draggableExample-tabpane-containerRestriction']/div[2]/span"));
            Actions action = new Actions(Driver);

            //Drag targeted icon to invalid location. Store its new location.
            action.DragAndDrop(targetIcon, invalidLocation);
            action.Perform();
            var newPosition = targetIcon.Location;

            //Validate icon was dragged, but remained in its container.
            Assert.True(oldPosition != newPosition, "The selected icon did not change locations.");
            Assert.True(newPosition != invalidLocation.Location, "The selected icon left its container and was moved to an ivalid location.");
        }

        public void DragParentIcon_ContainerRestricedTab()
        {
            //Navigate to the container restriced tab.
            Driver.FindElement(By.Id("draggableExample-tab-containerRestriction")).Click();

            //Find icon to be dragged and its location.Then find an invalid location and create instance of Actions.
            var targetIcon = Driver.FindElement(By.XPath("//*[@id='draggableExample-tabpane-containerRestriction']/div[2]/span"));
            var oldPosition = targetIcon.Location;
            var invalidLocation = Driver.FindElement(By.XPath("//*[@id='draggableExample-tabpane-containerRestriction']/div/div"));
            Actions action = new Actions(Driver);

            //Drag targeted icon to invalid location. Store its new location.
            action.DragAndDrop(targetIcon, invalidLocation);
            action.Perform();
            var newPosition = targetIcon.Location;

            //Validate icon was dragged, but remained in its container.
            Assert.True(oldPosition != newPosition, "The selected box did not change locations.");
            Assert.True(newPosition != invalidLocation.Location, "The selected box left its container and was moved to an ivalid location.");
        }

        public void DragCenterIcon_CursorStyleTab()
        {
            //Go to cursor style tab.
            Driver.FindElement(By.Id("draggableExample-tab-cursorStyle")).Click();

            //Find icon to be dragged, along with its location, and store them. Then create instance of Actions.
            var targetIcon = Driver.FindElement(By.Id("cursorCenter"));
            var oldPosition = targetIcon.Location;
            Actions action = new Actions(Driver);

            //Drag target icon to new location and store its location.
            action.DragAndDropToOffset(targetIcon, 277, 208);
            action.Perform();
            var newPosition = targetIcon.Location;

            //Validate dragging of icon is working as intended.
            Assert.True(oldPosition != newPosition, "The selected icon did not change locations.");
        }

        public void DragTopLeftIcon_CursorStyleTab()
        {
            //Go to cursor style tab.
            Driver.FindElement(By.Id("draggableExample-tab-cursorStyle")).Click();

            //Find icon to be dragged, along with its location, and store them. Then create instance of Actions.
            var targetIcon = Driver.FindElement(By.Id("cursorTopLeft"));
            var oldPosition = targetIcon.Location;
            Actions action = new Actions(Driver);

            //Drag target icon to new location and store its location.
            action.DragAndDropToOffset(targetIcon, 277, 208);
            action.Perform();
            var newPosition = targetIcon.Location;

            //Check dragging of icon is working as intended.
            Assert.True(oldPosition != newPosition, "The selected icon did not change locations.");
        }

        public void DragBottomIcon_CursorStyleTab()
        {
            //Go to cursor style tab.
            Driver.FindElement(By.Id("draggableExample-tab-cursorStyle")).Click();

            //Find icon to be dragged, along with its location, and store them. Then create instance of Actions.
            var targetIcon = Driver.FindElement(By.Id("cursorBottom"));
            var targetLocation = Driver.FindElement(By.Id("cursorTopLeft")); //Have to use this element as target location as putting in a valid offset is throwing out of bounds error.
            var oldPositon = targetIcon.Location;
            Actions action = new Actions(Driver);

            //Drag target icon to new location and store its location.
            action.DragAndDrop(targetIcon, targetLocation);
            action.Perform();
            var newPosition = targetIcon.Location;

            //Check dragging of icon is working as intended.
            Assert.True(oldPositon != newPosition, "The selected icon did not change locations.");
        }
    }
}
