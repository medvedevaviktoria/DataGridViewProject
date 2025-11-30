using Ahatornn.TestGenerator;
using DataGridViewProject.Entities.Models;
using DataGridViewProject.Manager.Contracts;
using DataGridViewProject.MemoryStorage.Contracts;
using FluentAssertions;
using Moq;
using Xunit;

namespace DataGridViewProject.Manager.Tests
{
    public class ProductManagerTests
    {
        private readonly IProductManager productManager;
        private readonly Mock<IProductStorage> storageMock;

        public ProductManagerTests()
        {
            storageMock = new Mock<IProductStorage>();
            productManager = new ProductManager(storageMock.Object);
        }

        [Fact]
        public async Task GetAllProductsShouldReturnValue()
        {
            var product1 = TestEntityProvider.Shared.Create<ProductModel>();
            var product2 = TestEntityProvider.Shared.Create<ProductModel>();
            storageMock.Setup(x => x.GetAllProducts())
                .ReturnsAsync(new[]
                {
                    product1,
                    product2,
                });

            var result = await productManager.GetAllProducts();

            result.Should().NotBeEmpty()
                .And.HaveCount(2)
                .And.ContainSingle(x => x.Id == product1.Id)
                .And.ContainSingle(x => x.Id == product2.Id);
            storageMock.Verify(x => x.GetAllProducts(), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task AddProductShouldWork()
        {
            var product1 = TestEntityProvider.Shared.Create<ProductModel>();
            
            var act = () => productManager.AddProduct(product1);

            await act.Should().NotThrowAsync();
            storageMock.Verify(x => x.AddProduct(product1), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task UpdateProductShouldWork()
        {
            var product1 = TestEntityProvider.Shared.Create<ProductModel>();

            var act = () => productManager.UpdateProduct(product1);

            await act.Should().NotThrowAsync();
            storageMock.Verify(x => x.UpdateProduct(product1), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DeleteProductShouldWork()
        {
            var product1 = TestEntityProvider.Shared.Create<ProductModel>();
            var act = () => productManager.DeleteProduct(product1.Id);

            await act.Should().NotThrowAsync();
            storageMock.Verify(x => x.DeleteProduct(product1.Id), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetProductByIdShouldReturnValue()
        {
            var product1 = TestEntityProvider.Shared.Create<ProductModel>();
            storageMock.Setup(x => x.GetProductById(product1.Id))
                .ReturnsAsync(product1);

            var result = await productManager.GetProductById(product1.Id);

            result.Should().NotBeNull();
            result.Id.Should().Be(product1.Id);
            storageMock.Verify(x => x.GetProductById(product1.Id), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        
    }
}
