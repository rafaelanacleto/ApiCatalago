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

    }

}