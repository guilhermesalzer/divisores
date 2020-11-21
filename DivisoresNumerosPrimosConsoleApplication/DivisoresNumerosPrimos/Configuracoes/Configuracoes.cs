using DivisoresNumerosPrimos.Executor;
using DivisoresNumerosPrimos.Fronteiras;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DivisoresNumerosPrimos.Configuracoes
{
    public static class Configuracoes
    {
        public static void ConfiguracoesServico(IServiceCollection services)
        {
            services.AddScoped<ICalcularDivisoresExecutor, CalcularDivisoresExecutor>();
            services.AddScoped<ICalcularDivisoresPrimosExecutor, CalcularDivisoresPrimosExecutor>();
        }
    }
}
