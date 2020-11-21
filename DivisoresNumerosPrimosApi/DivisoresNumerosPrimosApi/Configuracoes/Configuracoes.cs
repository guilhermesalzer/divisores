using DivisoresNumerosPrimosLocalizaApi.Executor;
using DivisoresNumerosPrimosLocalizaApi.Fronteiras;
using Microsoft.Extensions.DependencyInjection;

namespace DivisoresNumerosPrimosLocalizaApi.Configuracoes
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
