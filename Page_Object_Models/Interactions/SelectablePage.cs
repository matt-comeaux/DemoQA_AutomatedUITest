/*
Name: Selectable.cs
Purpose: Contains the Page Object Model for the selectable page on www.demoqa.com. 
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
using Xunit;

namespace AutomatedUITest_DemoQA.Page_Object_Models.Interactions
{
    class SelectablePage
    {
        private readonly IWebDriver Driver;
        private readonly string url = "https://demoqa.com/selectable";
        private readonly string mainHeader = "Selectable";

        public SelectablePage(IWebDriver driver)
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

        public void SelectAllFromList()
        {
            //Find list and its items.
            var list = Driver.FindElement(By.Id("verticalListContainer"));
            var listItems = list.FindElements(By.TagName("li"));
  
            //Select every list item and verify they were selected.
            for (int i = 0; i < listItems.Count; i++)
            {
                //Select item.
                listItems[i].Click();
                
                //Verify item was selected.
                bool isSelected = (listItems[i].GetAttribute("Class").Contains("active"));
                Assert.True(isSelected, "The list item number: " + i + " was not selected when clicked");
            } 
        }

        public void DeselectAllFromList()
        {
            //Select all list items.
            SelectAllFromList();

            //Find list and its items.
            var list = Driver.FindElement(By.Id("verticalListContainer"));
            var listItems = list.FindElements(By.TagName("li"));

            //Deselected all items.
            for (int i = 0; i < listItems.Count; i++)
            {
                //Deselect item.
                listItems[i].Click();

                //Verify list item was deselected.
                bool isActive = (listItems[i].GetAttribute("Class").Contains("active"));
                Assert.False(isActive, "The list item number: " + i + " was not deselected when clicked");
            }
        }

        public void SelectAllFromGrid()
        {
            //Switch to grid tab.
            Driver.FindElement(By.Id("demo-tab-grid")).Click();

            //Find grid and grid rows.
            var grid = Driver.FindElement(By.Id("gridContainer"));
            var gridRows = grid.FindElements(By.TagName("div"));

            //Select every grid item.
            for (int i = 0; i < gridRows.Count; i++)
            {
                //Get current row and its items.
                var currentRow = gridRows[i];
                var currentRowListItems = currentRow.FindElements(By.TagName("li"));
                
                //Select every item in current grid row.
                for (int j = 0; j < currentRowListItems.Count; j++)
                {
                    //Select grid item.
                    currentRowListItems[j].Click();

                    //Verify item is selected.
                    bool isSelected = (currentRowListItems[j].GetAttribute("Class").Contains("active"));
                    Assert.True(isSelected, "The item of grid row: " + i + " list item number: " + j + " was not selected when clicked");
                }

            }
        }


        public void DeselectAllFromGrid()
        {
            //Select all items from grid.
            SelectAllFromGrid();

            //Find grid and grid rows.
            var grid = Driver.FindElement(By.Id("gridContainer"));
            var gridRows = grid.FindElements(By.TagName("div"));

            //Deselect all grid items.
            for (int i = 0; i < gridRows.Count; i++)
            {
                //Get current row and its items.
                var currentRow = gridRows[i];
                var currentRowListItems = currentRow.FindElements(By.TagName("li"));

                //Deselect every item in current grid row.
                for (int j = 0; j < currentRowListItems.Count; j++)
                {
                    //Click item in current grid row.
                    currentRowListItems[j].Click();

                    //Verify item was deselected.
                    bool isSelected = (currentRowListItems[j].GetAttribute("Class").Contains("active"));
                    Assert.False(isSelected, "The item of grid row: " + i + " list item number: " + j + " was not deselected when clicked");
                }

            }
        }
    }
}
