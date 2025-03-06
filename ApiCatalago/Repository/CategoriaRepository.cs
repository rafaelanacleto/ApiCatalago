using ApiCatalago.Context;
using ApiCatalago.Interfaces;
using ApiCatalago.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalago.Repository
{
    public class CategoriaRepository : ICatalagoRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext contexto)
        {
            _context = contexto;
        }

        public async Task<Categoria[]> GetAllCategoriasAsync(bool incluirProdutos)
        {
            return await _context.Categorias.ToArrayAsync();
        }

        public Task<Produto[]> GetAllProdutosByCategoriaIdAsync(int categoriaId, bool incluirCategoria)
        {
            throw new NotImplementedException();
        }

        public Task<Categoria> GetCategoriaAsyncById(int categoriaId, bool incluirProdutos)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> GetProdutoByIdAsync(int categoriaId, int produtoId, bool incluirCategoria)
        {
            throw new NotImplementedException();
        }
    }
}
