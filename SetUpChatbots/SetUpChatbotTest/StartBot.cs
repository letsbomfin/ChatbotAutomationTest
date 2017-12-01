using NUnit.Framework;
using SetUpChatbotTest.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetUpChatbotTest
{
    [TestFixture]
    public class StartBot : TestBase
    {
        private BotFlowPage botFlow;

        [SetUp]
        public override void TestInitialize()
        {
            base.TestInitialize();
            botFlow = new BotFlowPage(driver);
        }

        //LOGIN E BUSCA PELO BOT SÃO FEITOS EM GLOBALSETUP
        //userName é o nome de usuário do Facebook -> passado por parâmetro
        [Test]
        public void Start()
        {
            botFlow.WelcomeToBot($"Oi {userName}, bom dia! "); //exemplo de mensagem que o bot pode receber
        }
    }
}
