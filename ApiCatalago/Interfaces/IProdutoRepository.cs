using ApiCatalago.Models;
using ApiCatalago.Pagination;

namespace ApiCatalago.Interfaces;

public interface IProdutoRepository : IRepository<Produto>
{
    Task<IEnumerable<Produto>> GetProdutosPorCategoriaAsync(int id);
    Task<PagedList<Produto>> GetProdutosPageAsync(ProdutoParametersQuery produtoParameters);
    Task<PagedList<Produto>> GetProdutosFiltroPrecoAsync(ProdutosFiltroPreco produtoParameters);
    
}