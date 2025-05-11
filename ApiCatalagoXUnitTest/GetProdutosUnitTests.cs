using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ApiCatalagoXUnitTest
{
    public class GetProdutosUnitTests : IClassFixture<ProdutosUnitTestController>
    {
        private readonly ProdutosUnitTestController _produtosUnitTestController;

        public GetProdutosUnitTests(ProdutosUnitTestController produtosUnitTestController)
        {
            _produtosUnitTestController = produtosUnitTestController;
        }

        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }

    }

}