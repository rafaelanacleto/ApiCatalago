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
            var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.Id == categoriaId);
            return categoria ?? new Categoria(); // Substitua por valores padrão apropriados para 'Categoria'
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
            var categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);

            if (categoria != null)
            {                
                _context.Categorias.Remove(categoria);
                _context.SaveChanges();
            }
        }
    }
}