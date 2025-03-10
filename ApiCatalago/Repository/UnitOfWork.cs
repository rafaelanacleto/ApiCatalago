using ApiCatalago.Context;
using ApiCatalago.Interfaces;
using ApiCatalago.Interfaces.Auxiliar;
using Microsoft.EntityFrameworkCore.Storage;

namespace ApiCatalago.Repository
{
    public class UnitOfWork : IDbUnitOfWork
    {
        private readonly AppDbContext _context;

        public IProdutoRepository ProdutoRepository => throw new NotImplementedException();

        public ICategoriaRepository CategoriaRepository => throw new NotImplementedException();

        public void Commit()
        {
            throw new NotImplementedException();
        }
    }
}
