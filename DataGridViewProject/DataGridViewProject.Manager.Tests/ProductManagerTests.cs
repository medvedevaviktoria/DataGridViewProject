using Ahatornn.TestGenerator;
using DataGridViewProject.Constants;
using DataGridViewProject.Entities.Models;
using DataGridViewProject.Manager.Contracts;
using DataGridViewProject.MemoryStorage.Contracts;
using FluentAssertions;
using Moq;
using Xunit;

namespace DataGridViewProject.Manager.Tests
{
    /// <summary>
    /// Набор модульных тестов для проверки работы класса <see cref="ProductManager"/>
    /// </summary>
    public class ProductManagerTests
    {
        private readonly IProductManager productManager;
        private readonly Mock<IProductStorage> storageMock;

        /// <summary>
        /// Инициализирует экземпляр <see cref="ProductManagerTests"/>
        /// </summary>
        public ProductManagerTests()
        {
            storageMock = new Mock<IProductStorage>();
            productManager = new ProductManager(storageMock.Object);
        }

        /// <summary>
        /// Проверяет, что метод GetAllProducts возвращает все продукты и вызывает хранилище один раз
        /// </summary>
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

        /// <summary>
        /// Проверяет, что метод AddProduct вызывает хранилище для добавления продукта
        /// </summary>
        [Fact]
        public async Task AddProductShouldWork()
        {
            var product1 = TestEntityProvider.Shared.Create<ProductModel>();
            
            var act = () => productManager.AddProduct(product1);

            await act.Should().NotThrowAsync();
            storageMock.Verify(x => x.AddProduct(product1), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверяет, что метод UpdateProduct вызывает хранилище для обновления продукта
        /// </summary>
        [Fact]
        public async Task UpdateProductShouldWork()
        {
            var product1 = TestEntityProvider.Shared.Create<ProductModel>();

            var act = () => productManager.UpdateProduct(product1);

            await act.Should().NotThrowAsync();
            storageMock.Verify(x => x.UpdateProduct(product1), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверяет, что метод DeleteProduct вызывает хранилище для удаления продукта по Id
        /// </summary>
        [Fact]
        public async Task DeleteProductShouldWork()
        {
            var product1 = TestEntityProvider.Shared.Create<ProductModel>();

            var act = () => productManager.DeleteProduct(product1.Id);

            await act.Should().NotThrowAsync();
            storageMock.Verify(x => x.DeleteProduct(product1.Id), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверяет, что метод GetProductById возвращает правильный продукт по Id
        /// </summary>
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

        /// <summary>
        /// Проверяет, что метод GetProductTotalPriceWithoutTax возвращает корректную сумму для продукта
        /// </summary>
        [Fact]
        public async Task GetProductTotalPriceWithoutTaxShouldReturnValue()
        {
            var product1 = TestEntityProvider.Shared.Create<ProductModel>();
            var expected = 120m;
            storageMock.Setup(x => x.GetProductTotalPriceWithoutTax(product1.Id))
                .ReturnsAsync(expected);

            var result = await productManager.GetProductTotalPriceWithoutTax(product1.Id);

            result.Should().Be(expected);
            storageMock.Verify(x => x.GetProductTotalPriceWithoutTax(product1.Id), Times.Once);
            storageMock.VerifyNoOtherCalls();

        }

        /// <summary>
        /// Проверяет, что метод GetStatistics корректно считает статистику по продуктам
        /// </summary>
        [Fact]
        public async Task GetStatistics()
        {
            var product1 = TestEntityProvider.Shared.Create<ProductModel>();
            product1.PriceWithoutTax = 10m;
            product1.Quantity = 5;
            var product2 = TestEntityProvider.Shared.Create<ProductModel>();
            product2.PriceWithoutTax = 20m;
            product2.Quantity = 3;
            storageMock.Setup(x => x.GetAllProducts())
                .ReturnsAsync(new[] { product1, product2 });

            var result = await productManager.GetStatistics();

            result.ProductCount.Should().Be(2);
            result.TotalWithoutTax.Should().Be(110m);
            result.TotalWithTax.Should().Be(110m * AppConstants.TaxRate);
            storageMock.Verify(x => x.GetAllProducts(), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }
    }
}
