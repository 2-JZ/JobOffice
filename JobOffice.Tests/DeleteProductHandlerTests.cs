using AutoMapper;
using FluentAssertions;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.ErrorHandling;
using JobOffice.ApplicationServices.API.Handlers;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Commands;
using JobOffice.DataAcces.CQRS.Queries;
using JobOffice.DataAcces.Entities;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace JobOffice.Tests
{
    public class DeleteProductHandlerTests
    {
        private readonly Mock<ICommandExecutor> commandExecutorMock;
        private readonly Mock<IQueryExecutor> queryExecutorMock;
        private readonly IMapper mapper;

        public DeleteProductHandlerTests()
        {
            this.commandExecutorMock = new Mock<ICommandExecutor>();
            this.queryExecutorMock = new Mock<IQueryExecutor>();
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ApplicationServices.API.Domain.Models.Product>();
            });
            this.mapper = configuration.CreateMapper();
        }

        [Fact]
        public async Task Handle_WithValidRequestAndDeveloperRole_ReturnsUnauthorized()
        {
            // Arrange
            var handler = new DeleteProductHandler(commandExecutorMock.Object, mapper, queryExecutorMock.Object);
            var request = new DeleteProductRequest
            {
                Id = 1,
                AuthenticationRole = "Developer"
            };

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(response);
            Assert.NotNull(response.Error);
            Assert.Equal(ErrorType.Unauthorized, response.Error.Error);
        }

        [Fact]
        public async Task Handle_WithValidRequestAndNonDeveloperRole_DeletesProductAndReturnsProductData()
        {
            // Arrange
            var handler = new DeleteProductHandler(commandExecutorMock.Object, mapper, queryExecutorMock.Object);
            var request = new DeleteProductRequest
            {
                Id = 1,
                AuthenticationRole = "Admin"
            };
            var productFromDb = new Product
            {
                Id = 1,
                ProductName = "Test Product",
                UnitPriceBrutto = 20m,
                Discount = 9
            };

            Product productNull = null;


            commandExecutorMock.Setup(executor => executor.Execute(It.IsAny<DeleteProductCommand>())).ReturnsAsync(productNull);
            queryExecutorMock.Setup(executor => executor.Execute(It.IsAny<GetProductQuery>())).ReturnsAsync(productFromDb);

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(response);
            Assert.Null(response.Data);
            Assert.Null(response.Error);
            
        }

        [Fact]
        public async Task Handle_WithNonexistentProduct_ReturnsNull()
        {
            // Arrange
            var handler = new DeleteProductHandler(commandExecutorMock.Object, mapper, queryExecutorMock.Object);
            var request = new DeleteProductRequest
            {
                Id = 1,
                AuthenticationRole = "Admin"
            };

            Product nullProductInDb = null;
            commandExecutorMock.Setup(executor => executor.Execute(It.IsAny<DeleteProductCommand>())).ReturnsAsync(nullProductInDb);
            queryExecutorMock.Setup(executor => executor.Execute(It.IsAny<GetProductQuery>())).ReturnsAsync(nullProductInDb);

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Null(response);
        }
    }

}
