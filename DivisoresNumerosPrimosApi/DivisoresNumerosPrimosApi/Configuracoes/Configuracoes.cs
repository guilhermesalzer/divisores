using DivisoresNumerosPrimosApi.Executor;
using DivisoresNumerosPrimosApi.Fronteiras;
using Microsoft.Extensions.DependencyInjection;

namespace DivisoresNumerosPrimosApi.Configuracoes
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
