using ApiCatalago.Models;
using ApiCatalago.Pagination;

namespace ApiCatalago.Interfaces;

public interface IProdutoRepository : IRepository<Produto>
{
    IEnumerable<Produto> GetProdutosPorCategoria(int id);
    PagedList<Produto> GetProdutosPage(ProdutoParametersQuery produtoParameters);
    PagedList<Produto> GetProdutosFiltroPreco(ProdutosFiltroPreco produtoParameters);
    
}