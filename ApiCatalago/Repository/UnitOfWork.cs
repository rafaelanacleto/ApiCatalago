﻿using ApiCatalago.Context;
using ApiCatalago.Interfaces;
using ApiCatalago.Interfaces.Auxiliar;
using Microsoft.EntityFrameworkCore.Storage;

namespace ApiCatalago.Repository
{
    public class UnitOfWork : IDbUnitOfWork
    {
        public AppDbContext _context;

        private IProdutoRepository? _produtoRepo;

        private ICategoriaRepository? _categoriaRepo;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IProdutoRepository ProdutoRepository
        {
            get
            {
                return _produtoRepo ??= new ProdutoRepository(_context);
            }
        }

        public ICategoriaRepository CategoriaRepository
        {
            get
            {
                return _categoriaRepo ??= new CategoriaRepository(_context);
            }
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }  
        
    }
}
