using ApiCatalago.Context;
using ApiCatalago.Interfaces;
using ApiCatalago.Models;
using ApiCatalago.Pagination;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using X.PagedList.Extensions;

namespace ApiCatalago.Repository;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IPagedList<Categoria>> GetCategoriasAsync(CategoriaParametersQuery categoriaParameters)
    {
        var categorias = (await GetAllAsync())
            .OrderBy(c => c.Nome)
            .AsQueryable();

        return categorias.ToPagedList(categoriaParameters.Pagina, categoriaParameters.Quantidade);

    }
}