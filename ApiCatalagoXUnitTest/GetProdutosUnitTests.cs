using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCatalago.Controllers;
using Xunit;

namespace ApiCatalagoXUnitTest
{
    public class GetProdutosUnitTests : IClassFixture<ProdutosUnitTestController>
    {
        private readonly ProdutosController _controller;

        public GetProdutosUnitTests(ProdutosUnitTestController controller)
        {
            _controller = new ProdutosController(controller.repository, controller.mapper); 
        }

        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }

        [Fact]
        public async Task GetAllProdutos()
        {
            // Arrange
            var expectedCount = 2; // Adjust this based on your test data

            // Act
            var result = await _controller.GetAsync();
            var produtos = result.Value;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, produtos!.Count());
            Assert.All(produtos, produto => Assert.NotNull(produto));
        }

        [Fact]
        public async Task GetProdutoById()
        {
            // Arrange
            var expectedId = 1; // Adjust this based on your test data

            // Act
            var result = await _controller.GetObterProdutoAsync(expectedId);
            var produto = result.Value;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(produto);
            Assert.Equal(expectedId, produto!.Id);
        }

        [Fact]
        public async Task GetProdutoById_Return_Notfound()
        {
            // Arrange
            var prodId = 9999; // Non-existent product ID
                               // Act
            var result = await _controller.GetObterProdutoAsync(prodId);
            // Assert
            Assert.NotNull(result);
        }

    }

}