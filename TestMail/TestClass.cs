using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestMail
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.i.ua/");
            //login
            driver.FindElement(By.LinkText("Вход")).Click();
            driver.FindElement(By.XPath("//*[@id=\"FloatLogin\"]/div/div/form/fieldset/p[1]/input")).SendKeys("emailforme@i.ua");
            driver.FindElement(By.XPath("//*[@id=\"FloatLogin\"]/div/div/form/fieldset/p[2]/input")).SendKeys("testqa1");
            driver.FindElement(By.XPath("//*[@id=\"FloatLogin\"]/div/div/form/input[6]")).Click();


            //send message
            driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div[3]/div[2]/div[2]/div[3]/ul/li[1]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div[6]/div[1]/div[1]/p/a")).Click();
            driver.FindElement(By.Id("to")).SendKeys("emailforme@i.ua");
            driver.FindElement(By.
                XPath("/html/body/div[4]/div[6]/div[1]/div[1]/div[1]/div/form/div[5]/div[2]/span/input[1]")).
                SendKeys("Mail for autotest");
            driver.FindElement(By.Id("text")).SendKeys("Test Message");
            driver.FindElement(By.XPath("/html/body/div[4]/div[6]/div[1]/div[1]/p[1]/input[1]")).Click();

            //check mail
            driver.FindElement(By.XPath("/html/body/div[1]/div[6]/div[2]/div/div/div[1]/ul/li[2]/big/a")).Click();
            driver.FindElement(By.XPath("//*[@id=\"fieldset1\"]/fieldset[1]/form/span[1]/input")).
                SendKeys("Mail for autotest");
            driver.FindElement(By.XPath("//*[@id=\"fieldset1\"]/fieldset[1]/form/span[2]/i")).Click();
            Assert.AreEqual(driver.FindElement(By.
                XPath("//*[@id=\"mesgList\"]/form/div/a/span[3]/span")).Text,
                "Mail for autotest");
        }
    }
}
