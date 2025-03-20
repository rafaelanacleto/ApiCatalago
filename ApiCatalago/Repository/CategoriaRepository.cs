using ApiCatalago.Context;
using ApiCatalago.Interfaces;
using ApiCatalago.Models;
using ApiCatalago.Pagination;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalago.Repository;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<PagedList<Categoria>> GetCategoriasAsync(CategoriaParametersQuery categoriaParameters)
    {
        var categorias = (await GetAllAsync())
            .OrderBy(c => c.Nome)
            .AsQueryable();

        return PagedList<Categoria>.Create(categorias, categoriaParameters.Pagina, categoriaParameters.Quantidade);

    }
}