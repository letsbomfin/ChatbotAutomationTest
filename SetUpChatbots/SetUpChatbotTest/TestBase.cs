using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetUpChatbotTest
{
    public abstract class TestBase
    {
        protected IWebDriver driver;
        protected string botName = "Nome do bot a ser pesquisado";
        protected string userName = "Nome de usuário no Facebook";
        protected string loginName = "usuario Login";
        protected string password = "senha Login";

        public object LogPath { get; private set; }

        [SetUp]
        public virtual void TestInitialize()
        {
            driver = GlobalSetup.Driver;
            botName = GlobalSetup.BotName;
            userName = GlobalSetup.UserName;
            loginName = GlobalSetup.LoginName;
            password = GlobalSetup.Password;
        }

        [TearDown]
        public void Teardown()
        {
            if (GlobalSetup.EnableLog && TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var guid = Guid.NewGuid();
                var filePath = $"{LogPath}{TestContext.CurrentContext.Test.FullName}-{DateTime.Today.ToString("yyyy-MM-dd")}";
                TakeScrenshot($"{filePath}_{guid}");
                using (var writer = File.AppendText($"{filePath}.txt"))
                {
                    writer.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\t{guid}\t{TestContext.CurrentContext.Result.Message}");
                }
            }
        }
        protected void TakeScrenshot(string filename)
        {
            var screenshotter = ((ITakesScreenshot)driver).GetScreenshot();
            var format = ScreenshotImageFormat.Jpeg;
            screenshotter.SaveAsFile($"{filename}.{format.ToString().ToLower()}", format);
        }
        protected string GetCurrentPath()
        {
            return new Uri(driver.Url).AbsolutePath;
        }
    }
    }
