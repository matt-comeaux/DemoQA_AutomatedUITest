/*
Name: DemoQA_SliderPageShould.cs
Purpose: Contains the tests for the slider page on demoqa.com
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

/*
 
NOTES:
    - The box that contains the value of the slider doesn't allow users to change it by typing. Thus no tests for that functionality.

*/

using AutomatedUITest_DemoQA.Page_Object_Models.Widgets;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace AutomatedUITest_DemoQA.Test_Classes.WidgetPages_Test
{
    public class DemoQA_SliderPageShould
    {
        [Fact]
        public void IncreaseBySliding()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var sliderPage = new SliderPage(driver);
                sliderPage.LoadPage();
                sliderPage.Increase_Slider();
            }
        }

        [Fact]
        public void DecreaseBySliding()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var sliderPage = new SliderPage(driver);
                sliderPage.LoadPage();
                sliderPage.Decrease_Slider();
            }
        }

    }
}
