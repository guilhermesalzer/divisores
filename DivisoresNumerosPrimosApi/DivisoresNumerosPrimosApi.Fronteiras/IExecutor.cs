namespace DivisoresNumerosPrimosLocalizaApi.Fronteiras
{
    public interface IExecutor<Tin, Tout>
    {
        Tout Executar(Tin requisicao);
    }
}
