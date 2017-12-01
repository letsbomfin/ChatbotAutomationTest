using OpenQA.Selenium;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SetUpChatbotTest.PageObjects
{
    class BotFlowPage : PageBase
    {
        public BotFlowPage(IWebDriver driver)
            : base(driver)
        {
        }

        //ENVIA UMA MENSGAEM PARA O BOT
        public void WelcomeToBot(string message)
        {
            var quest = _driver.FindElement(By.XPath(".//*[@aria-label = 'Digite uma mensagem...']"));
            quest.SendKeys("COMEÇAR"); //Enviar o comando para startar o fluxo do seu bot

            var enterButton = _driver.FindElement(By.XPath(".//a[contains(., 'Enviar')]"));
            enterButton.Click();

            Thread.Sleep(3000);

            var messageReceived = _driver.FindElement(By.XPath("//span[contaubs(., '"+ message + "')]"));
            messageReceived.Displayed.ShouldBe(true);
        }

        public override void GoTo()
        {
            GoToPath("/#/login");
        }
    }
}
