/*
Name: DemoQA_DynamicPropertiesPageShould.cs
Purpose: Contains the tests for the dynamic properties page on demoqa.com
Author: Matthew Comeaux. Github: https://www.github.com/matt-comeaux Linkedin: https://www.linkedin.com/in/matthew-comeaux
Created On: 5/6/2021
First Uploaded To Github On: 5/6/2021

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

using AutomatedUITest_DemoQA.Page_Object_Models.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace AutomatedUITest_DemoQA.Test_Classes.ElementPages_Tests
{
    public class DemoQA_DynamicPropertiesPageShould
    {
        [Fact]
        public void ClickButton_WillEnableAfter5Seconds()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var buttonPage = new DynamicPropertiesPage(driver);
                buttonPage.LoadPage();
                buttonPage.ClickButton_EnabledAfter5Seconds();
            }
        }

        [Fact]
        public void VerifyColorChangeOnButton_ColorChange()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var buttonPage = new DynamicPropertiesPage(driver);
                buttonPage.LoadPage();
                buttonPage.VerifyButtonColorChange();
            }
        }

        [Fact]
        public void ClickButton_VisibleAfter5Seconds()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var buttonPage = new DynamicPropertiesPage(driver);
                buttonPage.LoadPage();
                buttonPage.ClickButton_VisibleAfter5Seconds();
            }
        }
    }
}
