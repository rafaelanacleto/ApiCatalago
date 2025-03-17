using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCatalago.Context;
using ApiCatalago.Dtos;
using ApiCatalago.Interfaces;
using ApiCatalago.Interfaces.Auxiliar;
using ApiCatalago.Models;
using ApiCatalago.Pagination;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ApiCatalago.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IDbUnitOfWork _uof;
        private readonly IRepository<Produto> _repository;
        private readonly IMapper _mapper;

        public ProdutosController(IDbUnitOfWork produtoRepository, IRepository<Produto> repository, IMapper mapper)
        {
            _uof = produtoRepository;
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet("filter/preco/pagination")]
        public ActionResult<IEnumerable<ProdutoDTO>> GetProdutosFilterPreco([FromQuery] ProdutosFiltroPreco filtro)
        {
            var produtos = _uof.ProdutoRepository.GetProdutosFiltroPreco(filtro);
            return ObterProdutos(produtos);
        }


        private ActionResult<IEnumerable<ProdutoDTO>> ObterProdutos(PagedList<Produto> produtos)
        {
            var metadata = new
            {
                produtos.TotalCount,
                produtos.PageSize,
                produtos.CurrentPage,
                produtos.TotalPages,
                produtos.HasNext,
                produtos.HasPrevious
            };
            Response.Headers.Append("x-pagination", JsonConvert.SerializeObject(metadata));
            var produtosResult = _mapper.Map<List<ProdutoDTO>>(produtos);
            return Ok(produtosResult);
        }

        [HttpGet] // GET: api/produtos
        public ActionResult<IEnumerable<ProdutoDTO>> Get() ///Nunca retorne todos os registros, use Take(10) por exemplo
        {
            return _mapper.Map<List<ProdutoDTO>>(_uof.ProdutoRepository.GetAll().ToList());
        }

        [HttpGet("Pagination")] // GET: api/produtos
        public ActionResult<IEnumerable<ProdutoDTO>>
            Get([FromQuery] ProdutoParametersQuery produtoParameters) ///Nunca retorne todos os registros, use Take(10) por exemplo
        {
            var produtos = _uof.ProdutoRepository.GetProdutosPage(produtoParameters);
            var metadata = new
            {
                produtos.TotalCount,
                produtos.PageSize,
                produtos.CurrentPage,
                produtos.TotalPages,
                produtos.HasNext,
                produtos.HasPrevious
            };
            Response.Headers.Append("x-pagination", JsonConvert.SerializeObject(metadata));
            var produtosResult = _mapper.Map<List<ProdutoDTO>>(produtos);
            return Ok(produtosResult);
        }


        [HttpGet("{id}", Name = "ObterProduto")]
        public ActionResult<ProdutoDTO> Get(int id)
        {
            var produto = _uof.ProdutoRepository.Get(p => p.Id == id);

            if (produto == null)
            {
                return NotFound();
            }

            return _mapper.Map<ProdutoDTO>(produto);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Produto produto)
        {
            _uof.ProdutoRepository.Create(produto);
            _uof.Commit();
            return new CreatedAtRouteResult("ObterProduto", new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            _uof.ProdutoRepository.Update(produto);
            _uof.Commit();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Produto> Delete(int id)
        {
            var produto = _uof.ProdutoRepository.Get(p => p.Id == id);
            _uof.ProdutoRepository.Delete(produto);
            _uof.Commit();
            return produto;
        }
    }
}