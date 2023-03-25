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

namespace JobOffice.ApplicationServices.API.Tests.Handlers
{
    public class PutProductHandlerTests
    {
        private readonly Mock<ICommandExecutor> commandExecutorMock;
        private readonly Mock<IQueryExecutor> queryExecutorMock;
        private readonly Mock<IMapper> mapperMock;
        private readonly PutProductHandler handler;

        public PutProductHandlerTests()
        {
            commandExecutorMock = new Mock<ICommandExecutor>();
            queryExecutorMock = new Mock<IQueryExecutor>();
            mapperMock = new Mock<IMapper>();
            handler = new PutProductHandler(
                commandExecutorMock.Object,
                queryExecutorMock.Object,
                mapperMock.Object
            );
        }

        [Fact]
        public async void Handle_ShouldReturnUnauthorized_WhenRoleIsDeveloper()
        {
            // Arrange
            var request = new PutProductRequest
            {
                AuthenticationRole = "Developer"
            };

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(response.Error);
            Assert.Equal(ErrorType.Unauthorized, response.Error.Error);
        }

        [Fact]
        public async void Handle_ShouldReturnNotFound_WhenProductDoesNotExist()
        {
            // Arrange
            var request = new PutProductRequest
            {
                AuthenticationRole = "User",
                Id = 1,
                ProductName = "Product 1"
            };
            queryExecutorMock
                .Setup(x => x.Execute(It.IsAny<GetProductQuery>()))
                .ReturnsAsync((Product)null);

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(response.Error);
            Assert.Equal(ErrorType.NotFound, response.Error.Error);
        }

        [Fact]
        public async void Handle_ShouldReturnProduct_WhenProductExists()
        {
            // Arrange
            var request = new PutProductRequest
            {
                AuthenticationRole = "User",
                Id = 1,
                ProductName = "Product 1"
            };
            var productFromQuery = new Product();
            var mappedProductFromRequest = new Product();
            var productFromDb = new Product();
            queryExecutorMock
                .Setup(x => x.Execute(It.IsAny<GetProductQuery>()))
                .ReturnsAsync(productFromQuery);
            mapperMock
                .Setup(x => x.Map<Product>(request))
                .Returns(mappedProductFromRequest);
            commandExecutorMock
                .Setup(x => x.Execute(It.IsAny<PutProductCommand>()))
                .ReturnsAsync(productFromDb);
            mapperMock
                .Setup(x => x.Map<Domain.Models.Product>(productFromDb))
                .Returns(new Domain.Models.Product());

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Null(response.Error);
            Assert.NotNull(response.Data);
            mapperMock.Verify(x => x.Map<Product>(request), Times.Once);
            commandExecutorMock.Verify(x => x.Execute(It.IsAny<PutProductCommand>()), Times.Once);
            mapperMock.Verify(x => x.Map<Domain.Models.Product>(productFromDb), Times.Once);
        }
    }
}