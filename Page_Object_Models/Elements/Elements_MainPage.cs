/*
Name: Elements_MainPage.cs
Purpose: Contains the Page Object Model for the elements home page on www.demoqa.com. 
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

namespace AutomatedUITest_DemoQA.Page_Object_Models.Elements
{

    // Using Javascript to click links in order to avoid implicit waits from scrolling menu items into view.
    class Elements_MainPage
    {
        private readonly IWebDriver Driver;
        private readonly string url = "https://demoqa.com/elements";
        private readonly string mainHeader = "Elements";

        public Elements_MainPage(IWebDriver driver)
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

        public BrokenLinksPage NavigateToBrokenLinksPage_SideMenu()
        {
            IWebElement brokenLinksMenuItem = 
                Driver.FindElement(By.XPath("//div[contains(@class, 'element-group')][1]/div/ul/li[7]"));
            
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click()", brokenLinksMenuItem);
            
            return new BrokenLinksPage(Driver);
        }

        public ButtonsPage NavigateToButtonsPage_SideMenu()
        {
            IWebElement buttonsMenuItem = 
                Driver.FindElement(By.XPath("//div[contains(@class, 'element-group')][1]/div/ul/li[5]"));

            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click()", buttonsMenuItem);
            
            return new ButtonsPage(Driver);
        }

        public CheckBoxPage NavigateToCheckBoxPage_SideMenu()
        {
            IWebElement checkBoxMenuItem = Driver.FindElement(By.XPath("//div[contains(@class, 'element-group')][1]/div/ul/li[2]"));

            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click()", checkBoxMenuItem);

            return new CheckBoxPage(Driver);
        }

        public DynamicPropertiesPage NavigateToDynamicPropertiesPage_SideMenu()
        {
            IWebElement dynamicPropertiesMenuItem = 
                Driver.FindElement(By.XPath("//div[contains(@class, 'element-group')][1]/div/ul/li[9]"));
            
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click()", dynamicPropertiesMenuItem);
            
            return new DynamicPropertiesPage(Driver);
        }

        public LinksPage NavigateToLinksPage_SideMenu()
        {
            IWebElement linksMenuItem = 
                Driver.FindElement(By.XPath("//div[contains(@class, 'element-group')][1]/div/ul/li[6]"));

            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click()", linksMenuItem);

            return new LinksPage(Driver);
        }

        public RadioButtonPage NavigateToRadioButtonPage_SideMenu()
        {
            IWebElement radioButtonMenuItem = 
                Driver.FindElement(By.XPath("//div[contains(@class, 'element-group')][1]/div/ul/li[3]"));

            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click()", radioButtonMenuItem);

            return new RadioButtonPage(Driver);
        }

        public TextBoxPage NavigateToTextBoxPage_SideMenu()
        {
            IWebElement textBoxMenuItem = 
                Driver.FindElement(By.XPath("//div[contains(@class, 'element-group')][1]/div/ul/li[1]"));

            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click()", textBoxMenuItem);
            
            return new TextBoxPage(Driver);
        }

        public UploadDownloadPage NavigateToUploadDownloadPage_SideMenu()
        {
            IWebElement uploadDownloadMenuItem =
                Driver.FindElement(By.XPath("//div[contains(@class, 'element-group')][1]/div/ul/li[8]"));

            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click()", uploadDownloadMenuItem);

            return new UploadDownloadPage(Driver);
        }

        public WebTablesPage NavigateToWebTablesPage_SideMenu()
        {
            IWebElement webTablesMenuItem =
                Driver.FindElement(By.XPath("//div[contains(@class, 'element-group')][1]/div/ul/li[4]"));

            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click()", webTablesMenuItem);

            return new WebTablesPage(Driver);
        }
    }
}
