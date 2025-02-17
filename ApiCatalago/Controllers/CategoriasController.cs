using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCatalago.Context;
using ApiCatalago.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiCatalago.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
         private readonly AppDbContext _context;

        public CategoriasController(AppDbContext contexto)
        {
            _context = contexto;
        }

        [HttpGet] // GET: api/categorias
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            return _context.Categorias.ToList();
        }
    }
}