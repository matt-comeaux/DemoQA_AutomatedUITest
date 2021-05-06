/*
Name: Interactions_MainPage.cs
Purpose: Contains the Page Object Model for the interactions home page on www.demoqa.com. 
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

namespace TestAutomation_DemoQA.Page_Object_Models.Interactions
{
    class Interactions_MainPage
    {
        private readonly IWebDriver Driver;
        private readonly string url = "https://demoqa.com/interaction";
        private readonly string mainHeader = "Interactions";

        public Interactions_MainPage(IWebDriver driver)
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
                throw new Exception($"The requested page did not load correctly. The page url is: '{url}' The main header is: \r\n '{Driver.FindElement(By.ClassName("main-header")).Text}'");
            }
        }

        public DraggablePage NavigateToDraggablePage_SideMenu()
        {
            IWebElement draggableMenuItem =
                Driver.FindElement(By.XPath("//div[contains(@class, 'element-group')][5]/div/ul/li[5]"));

            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click()", draggableMenuItem);

            return new DraggablePage(Driver);
        }
        public DroppablePage NavigateToDroppablePage_SideMenu()
        {
            IWebElement droppableMenuItem =
                Driver.FindElement(By.XPath("//div[contains(@class, 'element-group')][5]/div/ul/li[4]"));

            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click()", droppableMenuItem);

            return new DroppablePage(Driver);
        }
        public ResizablePage NavigateToResizablePage_SideMenu()
        {
            IWebElement resizableMenuItem =
                Driver.FindElement(By.XPath("//div[contains(@class, 'element-group')][5]/div/ul/li[3]"));

            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click()", resizableMenuItem);

            return new ResizablePage(Driver);
        }
        public SelectablePage NavigateToSelectablePage_SideMenu()
        {
            IWebElement selectableMenuItem =
                Driver.FindElement(By.XPath("//div[contains(@class, 'element-group')][5]/div/ul/li[2]"));

            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click()", selectableMenuItem);

            return new SelectablePage(Driver);
        }
        public SortablePage NavigateToSortablePage_SideMenu()
        {
            IWebElement sortableMenuItem =
                Driver.FindElement(By.XPath("//div[contains(@class, 'element-group')][5]/div/ul/li[1]"));

            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click()", sortableMenuItem);

            return new SortablePage(Driver);
        }

    }
}
