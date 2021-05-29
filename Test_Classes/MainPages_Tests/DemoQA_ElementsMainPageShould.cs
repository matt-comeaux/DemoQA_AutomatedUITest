/*
Name: DemoQaElementsPagesShould.cs
Purpose: Contains the test class for the elements pages on www.demoqa.com. This includes testing for all element pages under the elements section. 
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
using AutomatedUITest_DemoQA.Page_Object_Models.Elements;
using Xunit;

namespace AutomatedUITest_DemoQA.Test_Classes.MainPages_Test
{
    public class DemoQA_ElementsMainPageShould
    {

        [Fact]
        [Trait("Category", "Smoke")]
        public void Load()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var elementsPage = new Elements_MainPage(driver);
                elementsPage.LoadPage();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToBrokenLinksPage_SideMenu()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var elementsPage = new Elements_MainPage(driver);
                elementsPage.LoadPage();
                BrokenLinksPage brokenLinksPage = elementsPage.NavigateToBrokenLinksPage_SideMenu();
                brokenLinksPage.EnsurePageLoaded();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToButtonsPage_SideMenu()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var elementsPage = new Elements_MainPage(driver);
                elementsPage.LoadPage();
                ButtonsPage buttonsPage = elementsPage.NavigateToButtonsPage_SideMenu();
                buttonsPage.EnsurePageLoaded();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToCheckBoxPage_SideMenu()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var elementsPage = new Elements_MainPage(driver);
                elementsPage.LoadPage();
                CheckBoxPage checkBoxPage = elementsPage.NavigateToCheckBoxPage_SideMenu();
                checkBoxPage.EnsurePageLoaded();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToDynamicPropertiesPage_SideMenu()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var elementsPage = new Elements_MainPage(driver);
                elementsPage.LoadPage();
                DynamicPropertiesPage dynamicPropertiesPage = elementsPage.NavigateToDynamicPropertiesPage_SideMenu();
                dynamicPropertiesPage.EnsurePageLoaded();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToLinksPage_SideMenu()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var elementsPage = new Elements_MainPage(driver);
                elementsPage.LoadPage();
                LinksPage linksPage = elementsPage.NavigateToLinksPage_SideMenu();
                linksPage.EnsurePageLoaded();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToRadioButtonPage_SideMenu()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var elementsPage = new Elements_MainPage(driver);
                elementsPage.LoadPage();
                RadioButtonPage radioButtonPage = elementsPage.NavigateToRadioButtonPage_SideMenu();
                radioButtonPage.EnsurePageLoaded();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToTextBoxPage_SideMenu()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var elementsPage = new Elements_MainPage(driver);
                elementsPage.LoadPage();
                TextBoxPage textBoxPage = elementsPage.NavigateToTextBoxPage_SideMenu();
                textBoxPage.EnsurePageLoaded();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToUploadDownloadPage_SideMenu()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var elementsPage = new Elements_MainPage(driver);
                elementsPage.LoadPage();
                UploadDownloadPage uploadDownloadPage = elementsPage.NavigateToUploadDownloadPage_SideMenu();
                uploadDownloadPage.EnsurePageLoaded();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigateToWebTablesPage_SideMenu()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var elementsPage = new Elements_MainPage(driver);
                elementsPage.LoadPage();
                WebTablesPage webTablesPage = elementsPage.NavigateToWebTablesPage_SideMenu();
                webTablesPage.EnsurePageLoaded();
            }
        }

    }
}
