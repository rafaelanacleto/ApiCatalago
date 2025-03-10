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
        private readonly IConfiguration _configuration;
        private readonly IRepository<Categoria> _repo;
        private readonly ILogger _logger;

        public CategoriasController(IConfiguration configuration,
            ILogger<CategoriasController> logger, IRepository<Categoria> repository)
        {           
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
        public ActionResult<Categoria> GetCategoriasAsync(int id)
        {
            var categoria =  _repo.Get(c => c.Id == id);

            if (categoria == null)
            {
                return null;
            }

            return Ok(categoria);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Categoria categoria)
        {
            _repo.Create(categoria);
            return new CreatedAtRouteResult("ObterCategoriaAsync", new { id = categoria.Id }, categoria);
        }

        [HttpDelete("{id}")]
        public ActionResult<Categoria> Delete(int id)
        {
            var categoria = _repo.Get(c => c.Id == id);
            var cat = _repo.Delete(categoria);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
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