using AutoMapper;
using EC.Api.Calculator.Application.Calculators.Commands.Subtractions;
using EC.Api.Calculator.Application.Exceptions;
using EC.Api.Calculator.Presentation.WebApi.Common.Errors;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Subtractions.Dtos;
using EC.Api.Calculator.Test.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace EC.Api.Calculator.Test.Presentation.WebApi.Controllers.Calculators.Subtractions
{
    [TestFixture]
    [Category(Category.Unit)]
    public class CalculatorControllerSubtractionTests
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
        public async Task Subtraction_Calls_Mediator_With_SubtractionCommand_With_Same_Arguments()
        {
            var minuend = 5;
            var subtrahend = 2;
            var requestDto = new CalculatorSubtractionRequestDto(minuend, subtrahend);
            var trackingId = "trackingId";

            await _controller.Subtraction(requestDto, trackingId);

            _mediatorMock.Verify(x => x.Send(It.Is<SubtractionCommand>(x => x.TrackingId == trackingId && x.Subtrahend == subtrahend && x.Minuend == minuend), default));
        }

        [Test]
        public async Task Subtraction_Calls_Map_With_Response_Of_Mediator()
        {
            var minuend = 5;
            var subtrahend = 2;
            var requestDto = new CalculatorSubtractionRequestDto(minuend, subtrahend);
            var trackingId = "trackingId";

            var subtractionCommandResponse = new SubtractionCommandResponse(2);

            _mediatorMock.Setup(x => x.Send(It.IsAny<SubtractionCommand>(), default)).ReturnsAsync(subtractionCommandResponse);

            await _controller.Subtraction(requestDto, trackingId);

            _mapperMock.Verify(x => x.Map<CalculatorSubtractionResponseDto>(subtractionCommandResponse));
        }

        [Test]
        public async Task Subtraction_Returns_OkObjectResult()
        {
            var minuend = 5;
            var subtrahend = 2;
            var requestDto = new CalculatorSubtractionRequestDto(minuend, subtrahend);
            var trackingId = "trackingId";

            var result = await _controller.Subtraction(requestDto, trackingId);

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task Subtraction_Returns_Ok_With_Mapped_Response()
        {
            var minuend = 5;
            var subtrahend = 2;
            var requestDto = new CalculatorSubtractionRequestDto(minuend, subtrahend);
            var trackingId = "trackingId";

            var responseDto = new CalculatorSubtractionResponseDto(2);

            _mapperMock.Setup(x => x.Map<CalculatorSubtractionResponseDto>(It.IsAny<object>())).Returns(responseDto);
            var result = await _controller.Subtraction(requestDto, trackingId);
            var body = ((OkObjectResult)result).Value;

            Assert.That(body, Is.EqualTo(responseDto));
        }

        [Test]
        public async Task Subtraction_Throwing_UnexpectedApplicationException_Returns_Proper_InternalServerError()
        {
            var minuend = 5;
            var subtrahend = 2;
            var requestDto = new CalculatorSubtractionRequestDto(minuend, subtrahend);
            var trackingId = "trackingId";

            _mediatorMock.Setup(x => x.Send(It.IsAny<SubtractionCommand>(), It.IsAny<CancellationToken>())).Throws<UnexpectedApplicationException>();

            var result = await _controller.Subtraction(requestDto, trackingId);

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
    }
}
