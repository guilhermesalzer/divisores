namespace DivisoresNumerosPrimosApi.Fronteiras
{
    public interface IExecutor<Tin, Tout>
    {
        Tout Executar(Tin requisicao);
    }
}
