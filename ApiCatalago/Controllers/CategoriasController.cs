using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCatalago.Context;
using ApiCatalago.Filters;
using ApiCatalago.Interfaces;
using ApiCatalago.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalago.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //rota padr�o
    public class CategoriasController : ControllerBase
    {
        //inst�ncia de contexto via inje��o de depend�ncia
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ICatalagoRepository _repo;
        private readonly ILogger _logger;

        public CategoriasController(AppDbContext contexto, IConfiguration configuration, ILogger<CategoriasController> logger, ICatalagoRepository repository)
        {
            _context = contexto;
            _configuration = configuration;
            _logger = logger;
            _repo = repository;
        }

        //M�todos Action: GET, POST, PUT, DELETE

        [HttpGet] // GET: api/categorias
        [ServiceFilter(typeof(ApiLoggingFilter))]
        public ActionResult<IEnumerable<Categoria>> Get()
        {

            // throw new Exception("Rafael");
            _logger.LogInformation("### Acessando o CategoriasController ###");

            var categorias = _repo.GetAllCategoriasAsync(true);

            //Exemplo de leitura do appSettings Json.    
            var tes = _configuration.GetValue<string>("Chave");

            if (categorias.Result.Length < 0)
            {
                return NoContent();
            }

            return Ok(categorias);
        }

        [HttpGet("{id}", Name = "ObterCategoriaAsync")]
        public async Task<ActionResult<Categoria>> GetCategoriasAsync(int id)
        {
            var categoria = await _context.Categorias.FirstOrDefaultAsync(p => p.Id == id);

            if (categoria == null)
            {
                return NotFound();
            }
            return categoria;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return new CreatedAtRouteResult("ObterCategoriaAsync", new { id = categoria.Id }, categoria);
        }
       
        [HttpDelete("{id}")]
        public ActionResult<Categoria> Delete(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(p => p.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return categoria;
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest();
            }
            _context.Entry(categoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

    }
}