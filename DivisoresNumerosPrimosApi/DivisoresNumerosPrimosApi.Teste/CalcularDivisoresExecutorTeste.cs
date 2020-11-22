using DivisoresNumerosPrimosApi.Executor;
using DivisoresNumerosPrimosApi.Fronteiras.CalcularDivisoresExecutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DivisoresNumerosPrimosApi.Teste
{
    [TestClass]
    public class CalcularDivisoresExecutorTeste
    {
        [TestMethod]
        public void CalcularDivisores_ComSucesso()
        {
            var resultadosEsperados = new List<int> { 1, 2, 4, 5, 10, 20, 25, 50, 100 };
            var requisicao = new CalcularDivisoresRequisicao { NumeroEscolhido = 100 };
            CalcularDivisoresResultado resultado = new CalcularDivisoresExecutor().Executar(requisicao);

            Assert.IsNotNull(resultado);
            Assert.AreEqual(9, resultado.DivisoresDoNumeroEscolhido.Count);
            Assert.IsTrue(resultado.DivisoresDoNumeroEscolhido.Except(resultadosEsperados).Count() == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalcularDivisores_ErroNaRequisicao()
        {
            var requisicao = new CalcularDivisoresRequisicao { NumeroEscolhido = -100 };
            new CalcularDivisoresExecutor().Executar(requisicao);
        }
    }
}
