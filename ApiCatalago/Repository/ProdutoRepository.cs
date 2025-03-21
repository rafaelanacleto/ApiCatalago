using System.Linq;
using System.Linq.Expressions;
using ApiCatalago.Context;
using ApiCatalago.Dtos;
using ApiCatalago.Interfaces;
using ApiCatalago.Models;
using ApiCatalago.Pagination;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using X.PagedList.Extensions;

namespace ApiCatalago.Repository;

public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{
    public ProdutoRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IPagedList<Produto>> GetProdutosPageAsync(ProdutoParametersQuery produtoParameters)
    {   
        var produtos = await GetAllAsync();

        var retorno = produtos.ToPagedList(produtoParameters.Pagina, produtoParameters.Quantidade);

        return retorno;
    }

    public async Task<IPagedList<Produto>> GetProdutosFiltroPrecoAsync(ProdutosFiltroPreco produtoParameters)
    {   
        var produtos = await GetAllAsync();

        if (produtoParameters.Preco.HasValue && !string.IsNullOrEmpty(produtoParameters.PrecoCriterio))
        {
            if(produtoParameters.PrecoCriterio.Equals("maior"))
            {
                produtos =  produtos.Where(p => p.Preco > produtoParameters.Preco.Value).OrderBy(p => p.Preco);
            }
            else if (produtoParameters.PrecoCriterio.Equals("menor"))
            {
                produtos = produtos.Where(p => p.Preco < produtoParameters.Preco.Value).OrderBy(p => p.Preco);
            }
            else
            {
                produtos = produtos.Where(p => p.Preco == produtoParameters.Preco.Value).OrderBy(p => p.Preco);
            }
        }

        return produtos.ToPagedList(produtoParameters.Pagina, produtoParameters.Quantidade);
    }

    public async Task<IEnumerable<Produto>> GetProdutosPorCategoriaAsync(int id)
    {
        return (await GetAllAsync()).Where(p => p.CategoriaId == id);
    }

}
