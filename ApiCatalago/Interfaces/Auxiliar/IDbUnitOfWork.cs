namespace ApiCatalago.Interfaces.Auxiliar
{
    public interface IDbUnitOfWork
    {
        IProdutoRepository ProdutoRepository { get; }
        ICategoriaRepository CategoriaRepository { get; }
        Task CommitAsync();


    }
}
