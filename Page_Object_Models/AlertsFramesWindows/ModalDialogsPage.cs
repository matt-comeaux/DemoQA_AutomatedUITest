/*
Name: ModalDialogs.cs
Purpose: Contains the Page Object Model for the modal dialogs page on www.demoqa.com. 
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
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace AutomatedUITest_DemoQA.Page_Object_Models.AlertsFramesWindows
{
    class ModalDialogsPage
    {
        private readonly IWebDriver Driver;
        private readonly string url = "https://demoqa.com/modal-dialogs";
        private readonly string mainHeader = "Modal Dialogs";

        private WebDriverWait Wait()
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        public ModalDialogsPage(IWebDriver driver)
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

        public void SelectSmallModal()
        {
            //Click show small modal button, wait for it to appear, store header and body text.
            Driver.FindElement(By.Id("showSmallModal")).Click();
            var modal = Wait().Until((d) => Driver.FindElement(By.ClassName("modal-content")));
            var modalHeader = Driver.FindElement(By.Id("example-modal-sizes-title-sm")).Text;
            var modalText = Driver.FindElement(By.ClassName("modal-body")).Text;

            //Validate small modal.
            Assert.True(modalHeader == "Small Modal", "The small modal did not load properly on button click.");
            Assert.True(modalText == "This is a small modal. It has very less content", "The small modal did not load properly on button click.");

            //TODO: Verify close button works.
        }

        public void SelectLargeModal()
        {
            //Click show large modal button, wait for it to appear, store header and body text.
            Driver.FindElement(By.Id("showLargeModal")).Click();
            var modal = Wait().Until((d) => Driver.FindElement(By.ClassName("modal-content")));
            var modalHeader = Driver.FindElement(By.Id("example-modal-sizes-title-lg")).Text;
            var modalText = Driver.FindElement(By.ClassName("modal-body")).Text;

            //Storing expected modal text in own variable as it is very long.
            var expectedModalText = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
            //Validate large modal.
            Assert.True(modalHeader == "Large Modal", "The large modal did not load properly on button click.");
            Assert.True(modalText == expectedModalText, "The large modal did not load properly on button click.");

            //TODO: Verify close button works.
        }
    }
}
