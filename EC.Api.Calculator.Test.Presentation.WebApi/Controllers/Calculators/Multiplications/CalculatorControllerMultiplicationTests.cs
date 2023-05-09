using AutoMapper;
using EC.Api.Calculator.Application.Calculators.Commands.Multiplications;
using EC.Api.Calculator.Application.Exceptions;
using EC.Api.Calculator.Presentation.WebApi.Common.Errors;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Multiplications.Dtos;
using EC.Api.Calculator.Test.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace EC.Api.Calculator.Test.Presentation.WebApi.Controllers.Calculators.Multiplications
{
    [TestFixture]
    [Category(Category.Unit)]
    public class CalculatorControllerMultiplicationTests
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
        public async Task Multiplication_Calls_Mediator_With_MultiplicationCommand_With_Same_Arguments()
        {
            var factors = new List<int> { 1, 2, 3 };
            var requestDto = new CalculatorMultiplicationRequestDto(factors);
            var trackingId = "trackingId";

            await _controller.Multiplication(requestDto, trackingId);

            _mediatorMock.Verify(x => x.Send(It.Is<MultiplicationCommand>(x => x.TrackingId == trackingId && x.Factors == factors), default));
        }

        [Test]
        public async Task Multiplication_Calls_Map_With_Response_Of_Mediator()
        {
            var factors = new List<int> { 1, 2, 3 };
            var requestDto = new CalculatorMultiplicationRequestDto(factors);
            var trackingId = "trackingId";

            var multiplicationCommandResponse = new MultiplicationCommandResponse(6);

            _mediatorMock.Setup(x => x.Send(It.IsAny<MultiplicationCommand>(), default)).ReturnsAsync(multiplicationCommandResponse);

            await _controller.Multiplication(requestDto, trackingId);

            _mapperMock.Verify(x => x.Map<CalculatorMultiplicationResponseDto>(multiplicationCommandResponse));
        }

        [Test]
        public async Task Multiplication_Returns_OkObjectResult()
        {
            var factors = new List<int> { 1, 2, 3 };
            var requestDto = new CalculatorMultiplicationRequestDto(factors);
            var trackingId = "trackingId";

            var result = await _controller.Multiplication(requestDto, trackingId);

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task Multiplication_Returns_Ok_With_Mapped_Response()
        {
            var factors = new List<int> { 1, 2, 3 };
            var requestDto = new CalculatorMultiplicationRequestDto(factors);
            var trackingId = "trackingId";

            var responseDto = new CalculatorMultiplicationResponseDto(5);

            _mapperMock.Setup(x => x.Map<CalculatorMultiplicationResponseDto>(It.IsAny<object>())).Returns(responseDto);
            var result = await _controller.Multiplication(requestDto, trackingId);
            var body = ((OkObjectResult)result).Value;

            Assert.That(body, Is.EqualTo(responseDto));
        }

        [Test]
        public async Task Multiplication_Throwing_UnexpectedApplicationException_Returns_Proper_InternalServerError()
        {
            var factors = new List<int> { 1, 2, 3 };
            var requestDto = new CalculatorMultiplicationRequestDto(factors);
            var trackingId = "trackingId";

            _mediatorMock.Setup(x => x.Send(It.IsAny<MultiplicationCommand>(), It.IsAny<CancellationToken>())).Throws<UnexpectedApplicationException>();

            var result = await _controller.Multiplication(requestDto, trackingId);

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
