using ApiCatalago.Models;
using ApiCatalago.Pagination;

namespace ApiCatalago.Interfaces
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<PagedList<Categoria>> GetCategoriasAsync(CategoriaParametersQuery categoriaParameters);
    }
}
