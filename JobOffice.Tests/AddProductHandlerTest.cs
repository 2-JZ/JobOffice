using AutoMapper;
using FluentAssertions;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.ErrorHandling;
using JobOffice.ApplicationServices.API.Handlers;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Commands;
using JobOffice.DataAcces.Entities;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace JobOffice.Tests
{
    public class AddProductHandlerTests
    {
        [Fact]
        public async Task Handle_WithDeveloperRole_ReturnsUnauthorizedError()
        {
            // Arrange
            var mockCommandExecutor = new Mock<ICommandExecutor>();
            var mockMapper = new Mock<IMapper>();
            var handler = new AddProductHandler(mockCommandExecutor.Object, mockMapper.Object);
            var request = new AddProductRequest { AuthenticationRole = "Developer" };

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(response.Error);
            Assert.IsType<ErrorModel>(response.Error);
            Assert.True(response.Error.Error == ErrorType.Unauthorized);
        }

        [Fact]
        public async Task Handle_WithValidRequest_ReturnsProduct()
        {
            // Arrange
            var mockCommandExecutor = new Mock<ICommandExecutor>();
            var mockMapper = new Mock<IMapper>();
            var handler = new AddProductHandler(mockCommandExecutor.Object, mockMapper.Object);

            var request = new AddProductRequest
            {
                AuthenticationRole = "Admin",
                ProductName = "Test Product",
                UnitPriceNetto = 10.99m,
                Discount = 4
            };

            var expectedProductFromDb = new DataAcces.Entities.Product
            {
                ProductName = "Test Product",
                UnitPriceNetto = 10.99m,
                Discount = 4
            };

            var expectedMappedDomainProduct = new JobOffice.ApplicationServices.API.Domain.Models.Product
            {
                ProductName = "Test Product",
                UnitPriceNetto = 10.99m,
                Discount = 4
            };


            mockMapper.Setup(x => x.Map<DataAcces.Entities.Product>(It.IsAny<JobOffice.ApplicationServices.API.Domain.Models.Product>())).Returns(expectedProductFromDb);
            mockMapper.Setup(x => x.Map<JobOffice.ApplicationServices.API.Domain.Models.Product>(It.IsAny<DataAcces.Entities.Product>())).Returns(expectedMappedDomainProduct);

            mockCommandExecutor.Setup(x => x.Execute(It.IsAny<AddProductCommand>()))
                               .ReturnsAsync(expectedProductFromDb);

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert

            response.Should().NotBeNull();
            response.Data.Discount.Should().Be(request.Discount);

            Assert.Null(response.Error);
            Assert.NotNull(response.Data);
            Assert.IsType<JobOffice.ApplicationServices.API.Domain.Models.Product>(response.Data);
            Assert.Equal(expectedProductFromDb.Id, response.Data.Id);
            Assert.Equal(expectedProductFromDb.ProductName, response.Data.ProductName);
            Assert.Equal(expectedProductFromDb.UnitPriceNetto, response.Data.UnitPriceNetto);
            Assert.Equal(expectedProductFromDb.Discount, response.Data.Discount);

            mockMapper.Verify(x => x.Map<DataAcces.Entities.Product>(request), Times.Once);
        }
    }
}
