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

        public async Task<Categoria> GetCategoriaAsyncById(int categoriaId, bool incluirProdutos)
        {
            return await _context.Categorias.FindAsync(categoriaId);
        }

        public void Add(Categoria categoria)
        {
            if (categoria == null)
            {
                throw new ArgumentNullException(nameof(categoria));
            }

            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        public void Update(Categoria categoria)
        {
            if (categoria == null)
            {
                throw new ArgumentNullException(nameof(categoria));
            }

            _context.Categorias.Update(categoria);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            if (_context.Categorias.Find(id) != null)
            {
                _context.Categorias.Remove(_context.Categorias.Find(id));
                _context.SaveChanges();
            }
        }
    }
}