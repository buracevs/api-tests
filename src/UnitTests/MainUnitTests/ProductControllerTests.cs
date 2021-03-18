using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_api.BL;
using web_api.Controllers;
using web_api.ViewModels;
using Xunit;

namespace MainUnitTests
{
    public class ProductControllerTests
    {
        private readonly Mock<IDatabaseManager> databaseManagerMock;
        private readonly ProductController productController;

        public ProductControllerTests()
        {
            databaseManagerMock = new Mock<IDatabaseManager>(MockBehavior.Loose);
            productController = new ProductController(databaseManagerMock.Object);
        }

        [Fact]
        public async Task GetProductReturns_StatusOk_CorrectProduct()
        {
            //Arrange
            Product product = new Product()
            {
                Id = 1234,
                Title = "Product shmoduct"
            };
            databaseManagerMock.Setup(x => x.GetProduct(It.IsAny<int>())).Returns(product);

            //Act

            var result = await productController.Details(1);

            //Assert
            Assert.NotNull(result);
            var statusCode = result as OkObjectResult;
            Assert.Equal(200, statusCode.StatusCode);
            var productFromResult = result as Product;
            Assert.Equal(1234, productFromResult.Id);
            Assert.Equal("Product shmoduct", productFromResult.Title);
        }

        [Fact]
        public async Task GetProductReturns_StatusNotFound_NulltProduct()
        {
            //Arrange
            Product product = null;
            databaseManagerMock.Setup(x => x.GetProduct(It.IsAny<int>())).Returns(product);

            //Act

            var result = await productController.Details(1);

            //Assert
            Assert.NotNull(result);
            var statusCode = result as BadRequestObjectResult; //https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.objectresult?view=aspnetcore-5.0
            Assert.Equal(400, statusCode.StatusCode);
            var productFromResult = result as Product;
            Assert.Null(productFromResult);
        }
    }
}
