using DivisoresNumerosPrimos.Fronteiras;
using DivisoresNumerosPrimos.Fronteiras.CalcularDivisoresPrimosExecutor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DivisoresNumerosPrimos.Executor
{
    public class CalcularDivisoresPrimosExecutor : ICalcularDivisoresPrimosExecutor
    {
        public CalcularDivisoresPrimosResultado Executar(CalcularDivisoresPrimosRequisicao requisicao)
        {
            if (!ValidarRequisicao(requisicao))
            {
                throw new ArgumentException("requisicao invalida!");
            }

            List<int> divisoresDoNumeroEscolhido = Util.Util.CalcularTodosDivisores(requisicao.NumeroEscolhido);
            var divisoresPrimosDoNumeroEscolhido = new List<int>();

            if (divisoresDoNumeroEscolhido.Any() && divisoresDoNumeroEscolhido.Count > 0)
            {
                divisoresPrimosDoNumeroEscolhido = divisoresDoNumeroEscolhido.Where(divisor => Util.Util.EhNumeroPrimo(divisor) && divisor != 1).ToList();
                return new CalcularDivisoresPrimosResultado { DivisoresPrimosDoNumeroEscolhido = divisoresPrimosDoNumeroEscolhido };
            }
            else
            {
                return new CalcularDivisoresPrimosResultado();
            }
        }

        private bool ValidarRequisicao(CalcularDivisoresPrimosRequisicao requisicao)
        {
            return requisicao != null && requisicao.NumeroEscolhido > 0;
        }
    }
}
