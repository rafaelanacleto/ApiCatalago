using ApiCatalago.Models;

namespace ApiCatalago.Interfaces
{
    public interface ICatalagoRepository
    {
        Task<Categoria[]> GetAllCategoriasAsync(bool incluirProdutos);
        Task<Categoria> GetCategoriaAsyncById(int categoriaId, bool incluirProdutos);
        void Add(Categoria categoria);
        void Update(Categoria categoria);
        void Delete(int id);
    }
}
