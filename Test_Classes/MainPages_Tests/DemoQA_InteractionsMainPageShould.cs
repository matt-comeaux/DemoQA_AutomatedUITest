/*
Name: DemoQaInteractionsPagesShould.cs
Purpose: Contains the test class for the interaction pages on www.demoqa.com. This includes testing for all interaction pages under the interactions section. 
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

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AutomatedUITest_DemoQA.Page_Object_Models.Interactions;
using Xunit;

namespace AutomatedUITest_DemoQA.Test_Classes.MainPages_Test
{
    public class DemoQA_InteractionsMainPageShould
    {
        [Fact]
        [Trait("Category", "Smoke")]
        public void Load()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var interactionsMainPage = new Interactions_MainPage(driver);
                interactionsMainPage.LoadPage();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToDraggablePage_SideMenu()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var interactionsMainPage = new Interactions_MainPage(driver);
                interactionsMainPage.LoadPage();
                DraggablePage draggablePage = interactionsMainPage.NavigateToDraggablePage_SideMenu();
                draggablePage.EnsurePageLoaded();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToDroppablePage_SideMenu()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var interactionsMainPage = new Interactions_MainPage(driver);
                interactionsMainPage.LoadPage();
                DroppablePage droppablePage = interactionsMainPage.NavigateToDroppablePage_SideMenu();
                droppablePage.EnsurePageLoaded();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToResizablePage_SideMenu()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var interactionsMainPage = new Interactions_MainPage(driver);
                interactionsMainPage.LoadPage();
                ResizablePage resizablePage = interactionsMainPage.NavigateToResizablePage_SideMenu();
                resizablePage.EnsurePageLoaded();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToSelectablePage_SideMenu()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var interactionsMainPage = new Interactions_MainPage(driver);
                interactionsMainPage.LoadPage();
                SelectablePage selectablePage = interactionsMainPage.NavigateToSelectablePage_SideMenu();
                selectablePage.EnsurePageLoaded();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToSortablePage_SideMenu()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var interactionsMainPage = new Interactions_MainPage(driver);
                interactionsMainPage.LoadPage();
                SortablePage sortablePage = interactionsMainPage.NavigateToSortablePage_SideMenu();
                sortablePage.EnsurePageLoaded();
            }
        }
    }
}
