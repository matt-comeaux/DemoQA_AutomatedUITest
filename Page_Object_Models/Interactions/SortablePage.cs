/*
Name: Sortable.cs
Purpose: Contains the Page Object Model for the sortable page on www.demoqa.com. 
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
    class SortablePage
    {
        private readonly IWebDriver Driver;
        private readonly string url = "https://demoqa.com/sortable";
        private readonly string mainHeader = "Sortable";

        //Creates instance of POM.
        public SortablePage(IWebDriver driver)
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

        public void SortItems_List()
        {
            //Find list and its items.
            var listContainer = Driver.FindElement(By.Id("demo-tabpane-list"));
            var listItems = listContainer.FindElements(By.ClassName("list-group-item"));

            //Reverse order of list.
            for (int i = 0; i < listItems.Count; i++)
            {
                //Find text of the item in place i. Create instance of Actions.
                var textOfItemsPlace = listItems[i].Text;
                Actions action = new Actions(Driver);
                
                //Drag each item to bottom of list.
                action.DragAndDropToOffset(listItems[0], 15, 312);
                action.Perform();

                //Verify list item was moved.
                var newTextOfItemsPlace = listItems[i].Text;
                bool wasResorted = (textOfItemsPlace != newTextOfItemsPlace);
                Assert.True(wasResorted, "The selected list item number: " + i + " was not sorted");
            }
        }

        public void SortItems_Grid()
        {
            //Navigate to grid tab
            Driver.FindElement(By.Id("demo-tab-grid")).Click();

            //Collect grid items
            var gridContainer = Driver.FindElement(By.Id("demo-tabpane-grid"));
            var gridItems = gridContainer.FindElements(By.ClassName("list-group-item"));

            //Reverse order of grid items.
            for (int i = 0; i < gridItems.Count; i++)
            {
                //Get text of item in place i. Create instance of Actions.
                var textOfItemsPlace = gridItems[i].Text;
                Actions action = new Actions(Driver);

                //Drag each item to bottom of grid.
                action.DragAndDropToOffset(gridItems[0], 235, 266);
                action.Perform();

                //Verify grid item was moved.
                var newTextOfItemsPlace = gridItems[i].Text;
                bool wasResorted = (textOfItemsPlace != newTextOfItemsPlace);
                Assert.True(wasResorted, "The selected grid item: " + gridItems[i].Text + " was not sorted");
            }
        }
    }
}
