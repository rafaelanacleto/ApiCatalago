using System.Linq.Expressions;
using ApiCatalago.Context;
using ApiCatalago.Interfaces;
using ApiCatalago.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalago.Repository;

public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{
    public ProdutoRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public IEnumerable<Produto> GetProdutosPorCategoria(int id)
    {
        throw new NotImplementedException();
    }
}