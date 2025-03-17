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

    public PagedList<Produto> GetProdutosFiltroPreco(ProdutosFiltroPreco produtoParameters)
    {
        var produtos = GetAll().AsQueryable();

        if (produtoParameters.Preco.HasValue && !string.IsNullOrEmpty(produtoParameters.PrecoCriterio))
        {
            return produtoParameters.PrecoCriterio switch
            {
                "maior" => PagedList<Produto>.Create(produtos.Where(p => p.Preco > produtoParameters.Preco), 1, 10),
                "menor" => PagedList<Produto>.Create(produtos.Where(p => p.Preco < produtoParameters.Preco), 1, 10),
                _ => PagedList<Produto>.Create(produtos.Where(p => p.Preco == produtoParameters.Preco), 1, 10)
            };
        }
        else
        {
            return PagedList<Produto>.Create(produtos, 1, 10);
        }
    }

    public IEnumerable<Produto> GetProdutosPorCategoria(int id)
    {
        return GetAll().Where(p => p.CategoriaId == id); 
    }
}
