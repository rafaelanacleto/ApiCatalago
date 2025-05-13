using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCatalago.Controllers;
using ApiCatalago.Models;
using Xunit;

namespace ApiCatalagoXUnitTest
{
    public class PostProdutoUnitTests : IClassFixture<ProdutosUnitTestController>
    {

        private readonly ProdutosController _controller;

        public PostProdutoUnitTests(ProdutosUnitTestController controller)
        {
            _controller = new ProdutosController(controller.repository, controller.mapper);
        }

        [Fact]
        public async Task PostProduto()
        {
            // Arrange
            var produto = new Produto { Nome = "Produto Teste", CategoriaId=1, DataCadastro=DateTime.Now, ImagemUrl="semiamgem", Descricao="Produto TESTE Apague", Preco = 10.0M };

            // Act
            var result = await _controller.Post(produto);
            var createdResult = result as Microsoft.AspNetCore.Mvc.CreatedAtActionResult;

            // Assert
            Assert.NotNull(createdResult);
            Assert.Equal(201, createdResult.StatusCode);
            Assert.Equal(produto, createdResult.Value);
        }

        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }
    }
}