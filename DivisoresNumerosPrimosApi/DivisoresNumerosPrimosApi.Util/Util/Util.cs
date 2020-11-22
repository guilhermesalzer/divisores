using System.Collections.Generic;

namespace DivisoresNumerosPrimosApi.Util
{
    public static class Util
    {
        public static bool EhNumeroPrimo(int numero)
        {
            for (int i = 2; i <= numero/2; i++)
            {
                if (numero % i == 0)
                {
                    return false;
                }
            }
            return true;            
        }

        public static List<int> CalcularTodosDivisores(int numero)
        {
            List<int> divisoresDoNumeroEscolhido;

            if (numero != 1)
            {
                divisoresDoNumeroEscolhido = new List<int> { 1 };
            }
            else
            {
                divisoresDoNumeroEscolhido = new List<int>();
            }

            int divisorMaximo = numero / 2;

            for (int i = 2; i <= divisorMaximo; i++)
            {
                if (numero % i == 0)
                {
                    divisoresDoNumeroEscolhido.Add(i);
                }
            }
            divisoresDoNumeroEscolhido.Add(numero);
            return divisoresDoNumeroEscolhido;
        }
    }
}
