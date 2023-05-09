using AutoMapper;
using EC.Api.Calculator.Application.Calculators.Commands.SquareRoots;
using EC.Api.Calculator.Application.Exceptions;
using EC.Api.Calculator.Domain.Exceptions;
using EC.Api.Calculator.Presentation.WebApi.Common.Errors;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.SquareRoots.Dtos;
using EC.Api.Calculator.Test.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace EC.Api.Calculator.Test.Presentation.WebApi.Controllers.Calculators.SquareRoots
{
    [TestFixture]
    [Category(Category.Unit)]
    public class CalculatorControllerSquareRootTests
    {
        private CalculatorController _controller;
        private Mock<IMapper> _mapperMock;
        private Mock<IMediator> _mediatorMock;

        [SetUp]
        public void Setup()
        {
            _mapperMock = new Mock<IMapper>();
            _mediatorMock = new Mock<IMediator>();
            _controller = new CalculatorController(_mapperMock.Object, _mediatorMock.Object);
        }

        [Test]
        public async Task SquareRoot_Calls_Mediator_With_SquareRootCommand_With_Same_Arguments()
        {
            var number = 5;
            var requestDto = new CalculatorSquareRootRequestDto(number);
            var trackingId = "trackingId";

            await _controller.SquareRoot(requestDto, trackingId);

            _mediatorMock.Verify(x => x.Send(It.Is<SquareRootCommand>(x => x.TrackingId == trackingId && x.Number == number), default));
        }

        [Test]
        public async Task SquareRoot_Calls_Map_With_Response_Of_Mediator()
        {
            var number = 5;
            var requestDto = new CalculatorSquareRootRequestDto(number);
            var trackingId = "trackingId";

            var squareRootCommandResponse = new SquareRootCommandResponse(2);

            _mediatorMock.Setup(x => x.Send(It.IsAny<SquareRootCommand>(), default)).ReturnsAsync(squareRootCommandResponse);

            await _controller.SquareRoot(requestDto, trackingId);

            _mapperMock.Verify(x => x.Map<CalculatorSquareRootResponseDto>(squareRootCommandResponse));
        }

        [Test]
        public async Task SquareRoot_Returns_OkObjectResult()
        {
            var number = 5;
            var requestDto = new CalculatorSquareRootRequestDto(number);
            var trackingId = "trackingId";

            var result = await _controller.SquareRoot(requestDto, trackingId);

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task SquareRoot_Returns_Ok_With_Mapped_Response()
        {
            var number = 5;
            var requestDto = new CalculatorSquareRootRequestDto(number);
            var trackingId = "trackingId";

            var responseDto = new CalculatorSquareRootResponseDto(2);

            _mapperMock.Setup(x => x.Map<CalculatorSquareRootResponseDto>(It.IsAny<object>())).Returns(responseDto);
            var result = await _controller.SquareRoot(requestDto, trackingId);
            var body = ((OkObjectResult)result).Value;

            Assert.That(body, Is.EqualTo(responseDto));
        }

        [Test]
        public async Task SquareRoot_Throwing_UnexpectedApplicationException_Returns_Proper_InternalServerError()
        {
            var number = 5;
            var requestDto = new CalculatorSquareRootRequestDto(number);
            var trackingId = "trackingId";

            _mediatorMock.Setup(x => x.Send(It.IsAny<SquareRootCommand>(), It.IsAny<CancellationToken>())).Throws<UnexpectedApplicationException>();

            var result = await _controller.SquareRoot(requestDto, trackingId);

            Assert.That(result, Is.InstanceOf<ObjectResult>());

            var objectResult = (ObjectResult)result;

            Assert.Multiple(() =>
            {
                Assert.That(objectResult.StatusCode, Is.EqualTo((int)HttpStatusCode.InternalServerError));
                Assert.That(objectResult.Value, Is.InstanceOf<ApplicationErrorBody>());
            });
            var applicationErrorBody = (ApplicationErrorBody)objectResult.Value;

            Assert.Multiple(() =>
            {
                Assert.That(applicationErrorBody.HttpStatusCode, Is.EqualTo((int)HttpStatusCode.InternalServerError));
                Assert.That(applicationErrorBody.ErrorCode, Is.EqualTo("ECAC999"));
                Assert.That(applicationErrorBody.Message, Does.Contain("unexpected"));
            });
        }

        [Test]
        public async Task SquareRoot_Throwing_SquareRootNotExactException_Returns_Proper_UnprocessableEntity()
        {
            var number = 5;
            var requestDto = new CalculatorSquareRootRequestDto(number);
            var trackingId = "trackingId";

            _mediatorMock.Setup(x => x.Send(It.IsAny<SquareRootCommand>(), It.IsAny<CancellationToken>())).Throws<SquareRootNotExactException>();

            var result = await _controller.SquareRoot(requestDto, trackingId);

            Assert.That(result, Is.InstanceOf<ObjectResult>());

            var objectResult = (ObjectResult)result;

            Assert.Multiple(() =>
            {
                Assert.That(objectResult.StatusCode, Is.EqualTo((int)HttpStatusCode.UnprocessableEntity));
                Assert.That(objectResult.Value, Is.InstanceOf<ApplicationErrorBody>());
            });
            var applicationErrorBody = (ApplicationErrorBody)objectResult.Value;

            Assert.Multiple(() =>
            {
                Assert.That(applicationErrorBody.HttpStatusCode, Is.EqualTo((int)HttpStatusCode.UnprocessableEntity));
                Assert.That(applicationErrorBody.ErrorCode, Is.EqualTo("ECAC001"));
                Assert.That(applicationErrorBody.Message, Does.Contain("exact"));
            });
        }
        
    }
}
