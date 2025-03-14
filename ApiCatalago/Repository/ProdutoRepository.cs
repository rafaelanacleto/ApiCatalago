using System.Linq.Expressions;
using ApiCatalago.Context;
using ApiCatalago.Interfaces;
using ApiCatalago.Models;
using ApiCatalago.Pagination;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalago.Repository;

public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{
    public ProdutoRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public PagedList<Produto> GetProdutosPage(ProdutoParametersQuery produtoParameters)
    {
        var produtos = GetAll()
            .OrderBy(p => p.Id)
            .AsQueryable();
        
        return PagedList<Produto>.Create(produtos, produtoParameters.Pagina, produtoParameters.Quantidade);
    }

    public PagedList<Produto> GetProdutosFiltroPreco(ProdutoParametersQuery produtoParameters)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Produto> GetProdutosPorCategoria(int id)
    {
        return GetAll().Where(p => p.CategoriaId == id); 
    }
}
