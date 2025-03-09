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
        private readonly ICategoriaRepository _repo;
        private readonly ILogger _logger;

        public CategoriasController(AppDbContext contexto, IConfiguration configuration,
            ILogger<CategoriasController> logger, ICategoriaRepository repository)
        {
            _context = contexto;
            _configuration = configuration;
            _logger = logger;
            _repo = repository;
        }

        [HttpGet] // GET: api/categorias
        [ServiceFilter(typeof(ApiLoggingFilter))]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            // throw new Exception("Rafael");
            _logger.LogInformation("### Acessando o CategoriasController ###");

            var categorias = _repo.GetAll();

            //Exemplo de leitura do appSettings Json.    
            var tes = _configuration.GetValue<string>("Chave");

            if (categorias.Count() == 0)
            {
                return NoContent();
            }

            return Ok(categorias);
        }

        [HttpGet("{id}", Name = "ObterCategoriaAsync")]
        public Task<ActionResult<Categoria>> GetCategoriasAsync(int id)
        {
            var categoria =  _repo.Get(c => c.Id == id);

            if (categoria == null)
            {
                return null;
            }

            return categoria.Re
        }

        [HttpPost]
        public ActionResult Post([FromBody] Categoria categoria)
        {
            _repo.Add(categoria);
            return new CreatedAtRouteResult("ObterCategoriaAsync", new { id = categoria.Id }, categoria);
        }

        [HttpDelete("{id}")]
        public ActionResult<Categoria> Delete(int id)
        {
            var categoria = _repo.GetCategoriaAsyncById(id, true);

            if (categoria == null)
            {
                return NotFound();
            }

            _repo.Delete(id);
            return categoria.Result;
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest();
            }

            _repo.Update(categoria);
            return Ok();
        }
    }
}