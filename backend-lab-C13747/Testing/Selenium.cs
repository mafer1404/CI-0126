using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;

namespace Testing
{
  public class Selenium
  {
    private IWebDriver _driver;

    [SetUp]
    public void Setup()
    {
      _driver = new EdgeDriver();
      _driver.Manage().Window.Maximize();
    }

    [TearDown]
    public void TearDown()
    {
      _driver.Quit();
    }

    [Test]
    public void Crear_Nuevo_Pais_Test()
    {
      _driver.Navigate().GoToUrl("http://localhost:8080/");

      var botonAgregar = _driver.FindElement(By.XPath("//a[@href='/pais']"));
      botonAgregar.Click();

      WebDriverWait waitForm = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
      waitForm.Until(d => d.FindElement(By.Id("name")));

      _driver.FindElement(By.Id("name")).SendKeys("Estados Unidos");
      _driver.FindElement(By.Id("continente")).SendKeys("América");
      _driver.FindElement(By.Id("idioma")).SendKeys("Inglés");

      var botonGuardar = _driver.FindElement(By.XPath("//button[contains(text(),'Guardar')]"));
      botonGuardar.Click();

      WebDriverWait waitMessage = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
      var mensaje = waitMessage.Until(driver =>
      {
        try
        {
          var el = driver.FindElement(By.XPath("//*[contains(text(),'País agregado correctamente')]"));
          return el.Displayed ? el : null;
        }
        catch (NoSuchElementException)
        {
          return null;
        }
      });

      Assert.IsNotNull(mensaje, "El mensaje de confirmación no apareció.");
      Assert.IsTrue(mensaje.Text.Contains("País agregado correctamente"));
    }
  }
}