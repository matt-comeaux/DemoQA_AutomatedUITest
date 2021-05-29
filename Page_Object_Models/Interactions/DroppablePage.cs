/*
Name: Droppable.cs
Purpose: Contains the Page Object Model for the droppable page on www.demoqa.com. 
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

namespace AutomatedUITest_DemoQA.Page_Object_Models.Interactions
{
    class DroppablePage
    {
        private readonly IWebDriver Driver;
        private readonly string url = "https://demoqa.com/droppable";
        private readonly string mainHeader = "Droppable";

        //Use whenever WebDriverWait is needed.
        private WebDriverWait Wait()
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        //Creates instance of POM.
        public DroppablePage(IWebDriver driver)
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

        public void DropIcon_SimpleTab()
        {

            //Find target icon and drop box. Then create instance of Actions.
            var icon = Driver.FindElement(By.Id("draggable"));
            var dropBox = Driver.FindElement(By.Id("droppable"));
            Actions action = new Actions(Driver);

            action.DragAndDrop(icon, dropBox);
            action.Perform();

            bool wasDropped = (dropBox.Text == "Dropped!");
            Assert.True(wasDropped, "The selected icon never made it to the drop box");
        }

        public void DropAcceptableIcon_AcceptTab()
        {
            //Switch to accept tab
            Driver.FindElement(By.Id("droppableExample-tab-accept")).Click();

            //Find target icon and drop box. Then create instance of Actions.
            var icon = Driver.FindElement(By.Id("acceptable"));
            //Using XPath as the webdev gave each dropbox the same id...
            var dropBox = Driver.FindElement(By.XPath("//*[@id='acceptDropContainer']/div[@id='droppable']"));
            Actions action = new Actions(Driver);

            action.DragAndDrop(icon, dropBox);
            action.Perform();

            bool wasDropped = (dropBox.Text == "Dropped!");
            Assert.True(wasDropped, "The selected icon never made it to the drop box");
        }

        public void DropNotAcceptableIcon_AcceptTab()
        {
            //Switch to accept tab
            Driver.FindElement(By.Id("droppableExample-tab-accept")).Click();

            //Find target icon and drop box. Then create instance of Actions.
            var icon = Driver.FindElement(By.Id("notAcceptable"));
            //Using XPath as the webdev gave dropbox the same id as the one on the simpletab.
            var dropBox = Driver.FindElement(By.XPath("//*[@id='acceptDropContainer']/div[@id='droppable']"));
            Actions action = new Actions(Driver);

            action.DragAndDrop(icon, dropBox);
            action.Perform();

            bool wasDropped = (dropBox.Text == "Dropped!");
            Assert.False(wasDropped, "The selected icon was dropped when it shouldn't have been!");
        }

        public void DropGreedyIcon_PropogationTab()
        {
            //Switch to propogation tab
            Driver.FindElement(By.Id("droppableExample-tab-preventPropogation")).Click();

            //Find target icon and drop boxes. Then create instance of Actions.
            var icon = Driver.FindElement(By.Id("dragBox"));
            var outerDropBox = Driver.FindElement(By.Id("greedyDropBox"));
            var innerDropBox = Driver.FindElement(By.Id("greedyDropBoxInner"));
            Actions action = new Actions(Driver);

            action.DragAndDrop(icon, innerDropBox);
            action.Perform();

            bool wasDroppedOuter = (outerDropBox.Text == "Dropped!");
            bool wasDroppedInner = (innerDropBox.Text == "Dropped!");
            Assert.False(wasDroppedOuter, "The selected icon's drop was registered by the outer drop box when it shouldn't have been.");
            Assert.True(wasDroppedInner, "The selected icon's drop was not registered by the inner drop box.");

        }

        public void DropNotGreedyIcon_PropogationTab()
        {
            //Switch to propogation tab
            Driver.FindElement(By.Id("droppableExample-tab-preventPropogation")).Click();

            //Find target icon and drop boxes. Then create instance of Actions.
            var icon = Driver.FindElement(By.Id("dragBox"));
            var outerDropBox = Driver.FindElement(By.Id("notGreedyDropBox"));
            var innerDropBox = Driver.FindElement(By.Id("notGreedyInnerDropBox"));
            Actions action = new Actions(Driver);

            action.DragAndDrop(icon, innerDropBox);
            action.Perform();

            //!!Keep remove method as the outer drop box text repeats 'Dropped!' multiple times with page break. No idea why, as it doesn't show this way in developer tools.
            bool wasDroppedInner = (innerDropBox.Text == "Dropped!");
            bool wasDroppedOuter = (outerDropBox.Text.Remove(8) == "Dropped!");

            Assert.True(wasDroppedOuter, "The selected icon's drop was not registered by the outer drop box.");
            Assert.True(wasDroppedInner, "The selected icon's drop was not registered by the inner drop box.");
        }

        public void DropRevertIcon_RevertTab()
        {
            //Switch to revert tab
            Driver.FindElement(By.Id("droppableExample-tab-revertable")).Click();

            //Find target icon, its location, and drop box. Then create instance of Actions.
            var icon = Driver.FindElement(By.Id("revertable"));
            var defaultPosition = icon.Location;
            //Using XPath as the webdev gave dropbox the same id as the one on the simpletab.
            var dropBox = Driver.FindElement(By.XPath("//*[@id='revertableDropContainer']/div[@id='droppable']"));
            Actions action = new Actions(Driver);

            //Drag icon to dropbox.
            action.DragAndDrop(icon, dropBox);
            action.Perform();

            //Wait for travel animation to finish and stor the icons location.
            Wait().Until((d) => icon.Location == defaultPosition);
            var newPosition = icon.Location;           

            //Validate that the icon was dragged to the drop box and then returned to its original location.
            Assert.True(dropBox.Text == "Dropped!", "The selected icon was not dropped.");
            Assert.True(newPosition == defaultPosition, "The selected icon did not revert to its original location.");
        }

        public void DropNonRevertIcon_RevertTab()
        {
            //Switch to revert tab
            Driver.FindElement(By.Id("droppableExample-tab-revertable")).Click();

            //Find target icon, its location, and drop box. Then create instance of Actions.
            var icon = Driver.FindElement(By.Id("notRevertable"));
            var oldPosition = icon.Location;
            //Using XPath as the webdev gave dropbox the same id as the one on the simpletab.
            var dropBox = Driver.FindElement(By.XPath("//*[@id='revertableDropContainer']/div[@id='droppable']"));
            Actions action = new Actions(Driver);

            //Drag icon to dropbox and store icon's location.
            action.DragAndDrop(icon, dropBox);
            action.Perform();
            var newPosition = icon.Location;

            //Validate the icon was dropped into box and that it didn't revert to original location.
            Assert.True(dropBox.Text == "Dropped!", "The selected icon was not dropped.");
            Assert.True(oldPosition != newPosition, "The selected icon reverted to its original location. It should have remained in drop box.");
        }
    }
}
