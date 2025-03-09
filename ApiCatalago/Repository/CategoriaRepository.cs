using ApiCatalago.Context;
using ApiCatalago.Interfaces;
using ApiCatalago.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalago.Repository;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}