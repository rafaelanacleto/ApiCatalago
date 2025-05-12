using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCatalago.Context;
using ApiCatalago.Dtos;
using ApiCatalago.Filters;
using ApiCatalago.Interfaces;
using ApiCatalago.Interfaces.Auxiliar;
using ApiCatalago.Models;
using ApiCatalago.Pagination;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
        public async Task<ActionResult<IEnumerable<Categoria>>> GetAsync()
        {
            // throw new Exception("Rafael");
            _logger.LogInformation("### Acessando o CategoriasController ###");

            var categorias = await _uof.CategoriaRepository.GetAllAsync();

            //Exemplo de leitura do appSettings Json.    
            var tes = _configuration.GetValue<string>("Chave");

            if (categorias.Count() == 0)
            {
                return NoContent();
            }

            return Ok(categorias);
        }

        [HttpGet("Pagination")] // GET: api/categorias
        [ServiceFilter(typeof(ApiLoggingFilter))]
        public async Task<ActionResult<IEnumerable<Categoria>>> CategoriaPagination([FromQuery] CategoriaParametersQuery parametersQuery)
        {            
            _logger.LogInformation("### Acessando CategoriaPaginationAsync ...");
            var categorias = await _uof.CategoriaRepository.GetCategoriasAsync(parametersQuery);

            var metadata = new
            {
                categorias.TotalItemCount,
                categorias.PageSize,
                categorias.PageNumber,
                categorias.Count,
                categorias.HasNextPage,
                categorias.HasPreviousPage
            };

            Response.Headers.Append("x-pagination", JsonConvert.SerializeObject(metadata));

            //Exemplo de leitura do appSettings Json.    
            //var tes = _configuration.GetValue<string>("Chave");
            if (!categorias.Any()) return NoContent();

            return Ok(categorias);
        }

        private ActionResult<IEnumerable<CategoriaDTO>> ObterCategorias(PagedList<Categoria> categorias)
        {
            var metadata = new
            {
                categorias.TotalCount,
                categorias.PageSize,
                categorias.CurrentPage,
                categorias.TotalPages,
                categorias.HasNext,
                categorias.HasPrevious
            };

            Response.Headers.Append("x-pagination", JsonConvert.SerializeObject(metadata));
            var categoriasResult = _mapper.Map<List<CategoriaDTO>>(categorias);
            return Ok(categoriasResult);
        }

        [HttpGet("{id}", Name = "ObterCategoriaAsync")]
        public async Task<ActionResult<Categoria>> GetCategoriasAsync(int id)
        {
            var categoria = await _uof.CategoriaRepository.GetAsync(c => c.Id == id);

            if (categoria == null)
            {
                return null;
            }

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Categoria categoria)
        {
            _uof.CategoriaRepository.Create(categoria);
            await _uof.CommitAsync();
            return new CreatedAtRouteResult("ObterCategoriaAsync", new { id = categoria.Id }, categoria);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult<Categoria>> Delete(int id)
        {
            var categoria = await _uof.CategoriaRepository.GetAsync(c => c.Id == id);
            var cat = _uof.CategoriaRepository.Delete(categoria);
            await _uof.CommitAsync();

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest();
            }

            _uof.CategoriaRepository.Update(categoria);
            await _uof.CommitAsync();
            return Ok();
        }
    }
}