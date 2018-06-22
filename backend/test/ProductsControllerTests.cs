using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using backend.Models;
using web.Controllers;
using Xunit;

namespace test
{
    public class ProductsControllerTests
    {
        [Fact]
        public async Task Test()
        {
            using (var context = Helpers.GetDbContext())
            {
                //arrange
                var controller = new ProductsController(context);

                //act
                var result = await controller.GetProducts();

                //assert
                Assert.NotNull(result);
            }
        }
    }
}
