using DivisoresNumerosPrimos.Fronteiras;
using DivisoresNumerosPrimos.Fronteiras.CalcularDivisoresExecutor;
using DivisoresNumerosPrimos.Fronteiras.CalcularDivisoresPrimosExecutor;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DivisoresNumerosPrimos
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            Configuracoes.Configuracoes.ConfiguracoesServico(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            Console.WriteLine("Digite um número: ");
            var numeroEscolhido = Console.ReadLine();
            try
            {
                var requisicaoCalcularDivisores = new CalcularDivisoresRequisicao { NumeroEscolhido = Convert.ToInt32(numeroEscolhido) };
                var requisicaoCalcularPrimosDivisores = new CalcularDivisoresPrimosRequisicao { NumeroEscolhido = Convert.ToInt32(numeroEscolhido) };

                var calcularDivisoresExecutor = serviceProvider.GetService<ICalcularDivisoresExecutor>();
                var calcularDivisoresPrimosExecutor = serviceProvider.GetService<ICalcularDivisoresPrimosExecutor>();

                CalcularDivisoresResultado resultadoCalcularDivisores = calcularDivisoresExecutor.Executar(requisicaoCalcularDivisores);
                CalcularDivisoresPrimosResultado resultadoCalcularDivisoresPrimos = calcularDivisoresPrimosExecutor.Executar(requisicaoCalcularPrimosDivisores);

                Console.WriteLine("Todos divisores encontrados: ");
                resultadoCalcularDivisores.DivisoresDoNumeroEscolhido.ForEach(divisor => Console.WriteLine(divisor));

                Console.WriteLine("Todos divisores primos encontrados: ");
                resultadoCalcularDivisoresPrimos.DivisoresPrimosDoNumeroEscolhido.ForEach(divisor => Console.WriteLine(divisor));
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Apenas números maiores que zero são aceitos");
            }
            catch (Exception)
            {
                Console.WriteLine("Apenas números naturais são aceitos");
            }            
        }
    }
}
