using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SetUpChatbotTest.PageObjects;
using System;

[SetUpFixture]
class GlobalSetup
{
    //EDITAR COM NOME DO BOT, NOME DE USUÁRIO NO FACEBOOK, LOGIN E SENHA -> NESSA ORDEM
    public static TimeSpan DefaultTimeout = TimeSpan.FromSeconds(10);
    private const string BotNameParameterKey = "botName";
    private const string UserNameParameterKey = "userName";
    private const string LoginNameParameterKey = "usuario Login"; //adicionar usuario de login
    private const string PasswordParameterKey = "senha Login"; //adicionar senha de login

    private const string DefaultBotName = "Nome do bot a ser pesquisado"; //adicionar  nome do bot que quer pesquisar
    private const string DefaultUserName = "Nome de usuário no Facebook"; //adicionar nome de usuario do Facebook
    private const string DefaultLoginName = "usuario Login"; //adicionar usuario de login
    private const string DefaultPassword = "senha Login"; //adicionar senha de login

    public static IWebDriver Driver { get; private set; }
    public static string BotName { get; private set; }
    public static string UserName { get; private set; }
    public static string LoginName { get; private set; }
    public static string Password { get; private set; }
    public static bool EnableLog { get; internal set; }

    [OneTimeSetUp]
    public void Init()
    {
        BotName = GetSettings(BotNameParameterKey) ?? DefaultBotName;
        UserName = GetSettings(UserNameParameterKey) ?? DefaultUserName;
        LoginName = GetSettings(LoginNameParameterKey) ?? DefaultLoginName;
        Password = GetSettings(PasswordParameterKey) ?? DefaultPassword;

        var options = new ChromeOptions();
        options.AddArguments("--disable-infobars");
        options.AddUserProfilePreference("credentials_enable_service", false);
        options.AddUserProfilePreference("profile.password_manager_enabled", false);

        var driverService = ChromeDriverService.CreateDefaultService();
        Driver = new ChromeDriver(driverService, options);
        Driver.Manage().Window.Maximize();

        var timeouts = Driver.Manage().Timeouts();
        timeouts.ImplicitWait = DefaultTimeout;
        timeouts.PageLoad = TimeSpan.FromSeconds(15);

        Driver.Navigate().GoToUrl("https://www.messenger.com/");

        //LOGIN
        var loginPage = new LoginPage(Driver);
        loginPage.Login(LoginName, Password);

        //PESQUISA BOT PELO NOME NO CAMPO DE BUSCA DO MESSENGER
        var searchBotPage = new SearchBotPage(Driver);
        searchBotPage.SearchBot(BotName);
    }

    [OneTimeTearDown]
    public static void AssemblyCleanup()
    {
        Driver.Quit();
    }

    private bool? ParseBool(string value)
    {
        try
        {
            return bool.Parse(value);
        }
        catch
        {
            return null;
        }
    }

    private string GetSettings(string key)
           => TestContext.Parameters.Get(key);
}