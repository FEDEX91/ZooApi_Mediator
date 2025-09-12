using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ZooApi_Mediator.Application.DTOs;
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
    }
}
