using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ZooApi_Mediator.Application.DTOs;
using ZooApi_Mediator.Application.Features.Bird.Commands;
using ZooApi_Mediator.Application.Features.Bird.Queries;
using ZooApi_Mediator.WebAPI.Controllers;

namespace ZooApi_Mediator.Tests.Controllers
{
    public class BirdControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly BirdController _controller;

        public BirdControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new BirdController(_mediatorMock.Object);
        }

        [Test]
        public async Task GetAll_ShouldReturnOkResult_WithListOfBirds()
        {
            // Arrange
            var birds = new List<BirdSingleDto> { new() { Id = 1, Name = "Parrot" } };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetBirdQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(birds);

            // Act
            var result = await _controller.GetAll();

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult!.Value, Is.EqualTo(birds));
        }

        [Test]
        public async Task GetById_ReturnsOkResult_WhenBirdExists()
        {
            // Arrange
            var bird = new BirdSingleDto { Id = 1, Name = "Parrot" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetBirdByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(bird);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult!.Value, Is.EqualTo(bird));
        }

        [Test]
        public async Task GetById_ReturnsNotFound_WhenBirdDoesNotExist()
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetBirdByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((BirdSingleDto)null);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            var notFoundResult = result as NotFoundObjectResult;
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.InstanceOf<NotFoundObjectResult>());
                Assert.That(notFoundResult, Is.Not.Null);
            });
            Assert.That(notFoundResult!.Value, Is.InstanceOf<string>());
            var value = notFoundResult.Value as string;
            Assert.That(value, Is.Not.Null);
            Assert.That(value!.ToLower(), Does.Contain("not found"));
        }

        [Test]
        public async Task Create_ReturnsOkResult_WithCreatedBird()
        {
            // Arrange
            var birdDto = new BirdDto { Name = "Eagle" };
            var createdBird = new BirdDto { Id = 2, Name = "Eagle" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateBirdCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(createdBird);

            // Act
            var result = await _controller.Create(birdDto);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult!.Value, Is.EqualTo(createdBird));
        }

        [Test]
        public async Task Delete_ReturnsNoContent_WhenBirdDeleted()
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteBirdCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.Delete(1);

            // Assert
            Assert.That(result, Is.InstanceOf<NoContentResult>());
        }

        [Test]
        public async Task Delete_ReturnsNotFound_WhenBirdDoesNotExist()
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteBirdCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            // Act
            var result = await _controller.Delete(1);

            // Assert
            var notFoundResult = result as NotFoundObjectResult;
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.InstanceOf<NotFoundObjectResult>());
                Assert.That(notFoundResult, Is.Not.Null);
            });
            Assert.That(notFoundResult!.Value, Is.InstanceOf<string>());
            var value = notFoundResult.Value as string;
            Assert.That(value, Is.Not.Null);
            Assert.That(value!.ToLower(), Does.Contain("not found"));
        }

        [Test]
        public async Task Update_ReturnsNoContent_WhenBirdUpdated() 
        {
            // Arrange
            var bird  = new BirdDto { Id = 1, Name = "Updated Bird" };
            var updatedBird = new BirdDto { Id = 1, Name = "Updated Bird" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateBirdCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(updatedBird);

            // Act
            var result = await _controller.Update(1, bird);

            // Assert
            Assert.That(result, Is.InstanceOf<NoContentResult>());
        }

        [Test]
        public async Task Update_ReturnsNotFound_WhenBirdDoesNotExist()
        {
            // Arrange
            var bird = new BirdDto { Id = 1, Name = "Updated Bird" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateBirdCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((BirdDto)null);

            // Act
            var result = await _controller.Update(1, bird);

            // Assert
            var notFoundResult = result as NotFoundObjectResult;
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.InstanceOf<NotFoundObjectResult>());
                Assert.That(notFoundResult, Is.Not.Null);
            });
            Assert.That(notFoundResult!.Value, Is.InstanceOf<string>());
            var value = notFoundResult.Value as string;
            Assert.That(value, Is.Not.Null);
            Assert.That(value!.ToLower(), Does.Contain("not found"));
        }
    }
}
