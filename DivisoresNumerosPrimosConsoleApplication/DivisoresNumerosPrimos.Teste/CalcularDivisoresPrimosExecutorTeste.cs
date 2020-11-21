using DivisoresNumerosPrimos.Executor;
using DivisoresNumerosPrimos.Fronteiras.CalcularDivisoresPrimosExecutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DivisoresNumerosPrimos.Teste
{
    [TestClass]
    public class CalcularDivisoresPrimosExecutorTeste
    {
        [TestMethod]
        public void CalcularDivisoresPrimos_ComSucesso()
        {
            var resultadosEsperados = new List<int> { 2, 5 };
            var requisicao = new CalcularDivisoresPrimosRequisicao { NumeroEscolhido = 100 };
            CalcularDivisoresPrimosResultado resultado = new CalcularDivisoresPrimosExecutor().Executar(requisicao);

            Assert.IsNotNull(resultado);
            Assert.AreEqual(2, resultado.DivisoresPrimosDoNumeroEscolhido.Count);
            Assert.IsTrue(resultado.DivisoresPrimosDoNumeroEscolhido.Except(resultadosEsperados).Count() == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalcularDivisoresPrimos_ErroNaRequisicao()
        {
            var requisicao = new CalcularDivisoresPrimosRequisicao { NumeroEscolhido = -100 };
            new CalcularDivisoresPrimosExecutor().Executar(requisicao);
        }
    }
}
