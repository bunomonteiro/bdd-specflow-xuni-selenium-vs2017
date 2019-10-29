using BDD.Models;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace BDD.Tests
{
    [Binding]
    public class CalculadoraSteps
    {
        private Calculator _calculator;
        private int _result;

        public CalculadoraSteps()
        {
            _calculator = new Calculator();
        }

        [Given(@"Que eu informe o número (.*) na calculadora")]
        public void DadoQueEuInformeONumeroNaCalculadora(int number)
        {
            _calculator.FirstNumber = number;
        }

        [Given(@"Que eu informe também o número (.*) na calculadora")]
        public void DadoQueEuInformeTambemONumeroNaCalculadora(int number)
        {
            _calculator.SecondNumber = number;
        }

        [When(@"Eu clicar em Somar")]
        public void QuandoEuClicarEmSomar()
        {
            _result = _calculator.Add();
        }

        [Then(@"o resultado exibido deve ser (.*)")]
        public void EntaoOResultadoExibidoDeveSer(int result)
        {
            Assert.Equal(result, _result);
        }
    }
}