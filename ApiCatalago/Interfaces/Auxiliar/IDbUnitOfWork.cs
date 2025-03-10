namespace ApiCatalago.Interfaces.Auxiliar
{
    public interface IDbUnitOfWork
    {
        IProdutoRepository ProdutoRepository { get; }
        ICategoriaRepository CategoriaRepository { get; }
        void Commit();


    }
}
