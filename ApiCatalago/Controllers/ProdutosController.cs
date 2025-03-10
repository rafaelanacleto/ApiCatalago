using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCatalago.Context;
using ApiCatalago.Interfaces;
using ApiCatalago.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalago.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IRepository<Produto> _repository;

        public ProdutosController(IProdutoRepository produtoRepository, IRepository<Produto> repository)
        {
            _produtoRepository = produtoRepository;
            _repository = repository;
        }

        [HttpGet] // GET: api/produtos
        public ActionResult<IEnumerable<Produto>> Get() ///Nunca retorne todos os registros, use Take(10) por exemplo
        {
            return _repository.GetAll().ToList();
        }

        [HttpGet("{id}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _repository.Get(p => p.Id == id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Produto produto)
        {
            _repository.Create(produto);
            return new CreatedAtRouteResult("ObterProduto", new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }
            
            _repository.Update(produto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Produto> Delete(int id)
        {            
            return _repository.Delete(_repository.Get(p => p.Id == id));
        }

    }
}