# ChatbotAutomationTest
SetUp para automacao em Chatbot no Facebook Messenger Web. Visual Studio, Nunit e Selenium.

# O projeto é um Class Library

# Pacotes
 "NUnit" version="3.9.0"
 "NUnit3TestAdapter" version="3.9.0"
 "Selenium.Chrome.WebDriver" version="2.33" 
 "Selenium.Support" version="3.7.0"
 "Selenium.WebDriver" version="3.7.0"
 "Shouldly" version="2.8.3"


# TestBase e # GlobalSetup
Comportamento do teste início-
  - Durante a execução do projeto de teste:
     - A página é aberta somente uma vez;
     - Login é realizado somente uma vez;
	 - Todos os testes são executados;
	 - Teste encerrado e página web fechada.
Para alterar esse comportamento, as alterações serão feitas em GlobalSetup 
[OneTimeSetUp] e OneTimeTearDown]

#PageObjects
- As classes devem ser criadas dentro do folder.
- PageBase: podem ser acrescentados métodos que são comuns a todos os testes.
- Contém os 'TestCases' do bot.

#[Test]
- TestCases do bot;
