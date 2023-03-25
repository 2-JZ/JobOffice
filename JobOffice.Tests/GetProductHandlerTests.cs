using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.ErrorHandling;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Queries;
using MediatR;
using Moq;
using Xunit;

namespace JobOffice.ApplicationServices.API.Handlers.Tests
{
    public class GetProductHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_ReturnsGetProductResponseWithData()
        {
            // Arrange
            var expectedProductEntity = new DataAcces.Entities.Product { Id = 1, ProductName = "Test Product" };
            var expectedProductDomain = new JobOffice.ApplicationServices.API.Domain.Models.Product { Id = 1, ProductName = "Test Product" };
            var queryExecutorMock = new Mock<IQueryExecutor>();
            queryExecutorMock.Setup(x => x.Execute(It.IsAny<GetProductQuery>()))
                .ReturnsAsync(expectedProductEntity);
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<DataAcces.Entities.Product>(It.IsAny<JobOffice.ApplicationServices.API.Domain.Models.Product>())).Returns(expectedProductEntity);
            mapperMock.Setup(x => x.Map<JobOffice.ApplicationServices.API.Domain.Models.Product>(It.IsAny<DataAcces.Entities.Product>())).Returns(expectedProductDomain);
            var handler = new GetProductHandler(queryExecutorMock.Object, mapperMock.Object);
            var request = new GetProductRequest { Id = 1 };

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(response.Data);
            Assert.Null(response.Error);
            Assert.Equal(expectedProductEntity.Id, response.Data.Id);
            Assert.Equal(expectedProductEntity.ProductName, response.Data.ProductName);
        }

        [Fact]
        public async Task Handle_InvalidRequest_ReturnsGetProductResponseWithError()
        {
            // Arrange
            var queryExecutorMock = new Mock<IQueryExecutor>();
            queryExecutorMock.Setup(x => x.Execute(It.IsAny<GetProductQuery>()))
                .ReturnsAsync((DataAcces.Entities.Product)null);
            var mapperMock = new Mock<IMapper>();
            var handler = new GetProductHandler(queryExecutorMock.Object, mapperMock.Object);
            var request = new GetProductRequest { Id = 1 };

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Null(response.Data);
            Assert.NotNull(response.Error);
            Assert.Equal(ErrorType.NotFound, response.Error.Error);
        }
    }
}
