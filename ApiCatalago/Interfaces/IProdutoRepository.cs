using ApiCatalago.Models;

namespace ApiCatalago.Interfaces;

public interface IProdutoRepository : IRepository<Produto>
{
    IEnumerable<Produto> GetProdutosPorCategoria(int id);

    IEnumerable<Produto> GetProdutosPage(ProdutoParametersQuery produtoParameters);
}