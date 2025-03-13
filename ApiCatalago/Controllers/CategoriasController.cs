using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCatalago.Context;
using ApiCatalago.Filters;
using ApiCatalago.Interfaces;
using ApiCatalago.Interfaces.Auxiliar;
using ApiCatalago.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalago.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //rota padr�o
    public class CategoriasController : ControllerBase
    {       
        private readonly IConfiguration _configuration;
        private readonly IDbUnitOfWork _uof;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public CategoriasController(IConfiguration configuration,
            ILogger<CategoriasController> logger, IDbUnitOfWork dbUnitOf, IMapper mapper)
        {
            _configuration = configuration;
            _logger = logger;
            _uof = dbUnitOf;
            _mapper = mapper;
        }

        [HttpGet] // GET: api/categorias
        [ServiceFilter(typeof(ApiLoggingFilter))]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            // throw new Exception("Rafael");
            _logger.LogInformation("### Acessando o CategoriasController ###");

            var categorias = _uof.CategoriaRepository.GetAll();

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
            var categoria = _uof.CategoriaRepository.Get(c => c.Id == id);

            if (categoria == null)
            {
                return null;
            }

            return Ok(categoria);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Categoria categoria)
        {
            _uof.CategoriaRepository.Create(categoria);
            _uof.Commit();
            return new CreatedAtRouteResult("ObterCategoriaAsync", new { id = categoria.Id }, categoria);
        }

        [HttpDelete("{id}")]
        public ActionResult<Categoria> Delete(int id)
        {
            var categoria = _uof.CategoriaRepository.Get(c => c.Id == id);
            var cat = _uof.CategoriaRepository.Delete(categoria);
            _uof.Commit();

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

            _uof.CategoriaRepository.Update(categoria);
            _uof.Commit();
            return Ok();
        }
    }
}