using ApiCatalago.Models;

namespace ApiCatalago.Interfaces
{
    public interface ICatalagoRepository
    {
        Task<Categoria[]> GetAllCategoriasAsync(bool incluirProdutos);
        Task<Categoria> GetCategoriaAsyncById(int categoriaId, bool incluirProdutos);
        Task<Produto[]> GetAllProdutosByCategoriaIdAsync(int categoriaId, bool incluirCategoria);
        Task<Produto> GetProdutoByIdAsync(int categoriaId, int produtoId, bool incluirCategoria);
    }
}
