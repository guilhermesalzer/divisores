using DivisoresNumerosPrimosApi.Fronteiras;
using DivisoresNumerosPrimosApi.Fronteiras.CalcularDivisoresExecutor;
using DivisoresNumerosPrimosApi.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DivisoresNumerosPrimosApi.Executor
{
    public class CalcularDivisoresExecutor : ICalcularDivisoresExecutor
    {
        public CalcularDivisoresResultado Executar(CalcularDivisoresRequisicao requisicao)
        {
            if (!ValidarRequisicao(requisicao))
            {
                throw new ArgumentException("requisicao inválida");
            }

            List<int> divisoresDoNumeroEscolhido = Util.Util.CalcularTodosDivisores(requisicao.NumeroEscolhido);
            
            if (divisoresDoNumeroEscolhido.Any() && divisoresDoNumeroEscolhido.Count > 0)
            {
                return new CalcularDivisoresResultado { DivisoresDoNumeroEscolhido = divisoresDoNumeroEscolhido };
            }
            else
            {
                return new CalcularDivisoresResultado();
            }
        }

        private bool ValidarRequisicao(CalcularDivisoresRequisicao requisicao)
        {
            return requisicao != null && requisicao.NumeroEscolhido > 0;
        }
    }
}
