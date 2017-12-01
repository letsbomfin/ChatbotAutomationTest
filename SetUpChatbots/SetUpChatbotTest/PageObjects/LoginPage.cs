using OpenQA.Selenium;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetUpChatbotTest.PageObjects
{
    class LoginPage : PageBase
    {
        public LoginPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void Login(string login, string password)
        {
            var loginName = _driver.FindElement(By.Id("email"));
            var keyWord = _driver.FindElement(By.Id("pass"));
            var enterBtn = _driver.FindElement(By.Id("loginbutton"));

            loginName.SendKeys(login);
            keyWord.SendKeys(password);
            enterBtn.Click();

            var messenger = _driver.FindElement(By.XPath("//div[contains(., 'Messenger')]"));
            messenger.Displayed.ShouldBe(true);

        }

        public override void GoTo()
        {
            GoToPath("/#/login");
        }

    }
}
