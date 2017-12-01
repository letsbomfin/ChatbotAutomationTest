using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SetUpChatbotTest.PageObjects
{
    class SearchBotPage : PageBase
    {
        public SearchBotPage(IWebDriver driver)
            : base(driver)
        {
        }

        //PESQUISA O BOT PELO NOME NO CAMPO DE BUSCA DA PAGINA DO MESSENGER
        public void SearchBot(string botName)
        {

            var newMessageBtn = _driver.FindElement(By.XPath(".//*[@id='u_0_0']/div/div/div[1]/div/div[1]/a"));
            newMessageBtn.Click();

            var sendMessageTo = _driver.FindElement(By.XPath(".//input[@placeholder = 'Digite o nome de uma pessoa ou grupo']"));
            sendMessageTo.SendKeys(botName);

            Thread.Sleep(2000);
            var selectBot = _driver.FindElement(By.XPath("//*[contains(@id, 'js')]/div/div/div/div/ul/li/a/div/div[2]/div/div"));
            selectBot.Click();
        }


        public override void GoTo()
        {
            GoToPath("t/1309695952404736");
        }
    }
}
