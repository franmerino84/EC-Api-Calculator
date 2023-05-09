using AutoMapper;
using EC.Api.Calculator.Application.Calculators.Commands.Divisions;
using EC.Api.Calculator.Application.Exceptions;
using EC.Api.Calculator.Presentation.WebApi.Common.Errors;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Divisions.Dtos;
using EC.Api.Calculator.Test.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace EC.Api.Calculator.Test.Presentation.WebApi.Controllers.Calculators.Divisions
{
    [TestFixture]
    [Category(Category.Unit)]
    public class CalculatorControllerDivisionTests
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
        public async Task Division_Calls_Mediator_With_DivisionCommand_With_Same_Arguments()
        {
            var dividend = 5;
            var divisor = 2;
            var requestDto = new CalculatorDivisionRequestDto(dividend, divisor);
            var trackingId = "trackingId";

            await _controller.Division(requestDto, trackingId);

            _mediatorMock.Verify(x => x.Send(It.Is<DivisionCommand>(x => x.TrackingId == trackingId && x.Divisor == divisor && x.Dividend == dividend), default));
        }

        [Test]
        public async Task Division_Calls_Map_With_Response_Of_Mediator()
        {
            var dividend = 5;
            var divisor = 2;
            var requestDto = new CalculatorDivisionRequestDto(dividend, divisor);
            var trackingId = "trackingId";

            var divisionCommandResponse = new DivisionCommandResponse(2, 1);

            _mediatorMock.Setup(x => x.Send(It.IsAny<DivisionCommand>(), default)).ReturnsAsync(divisionCommandResponse);

            await _controller.Division(requestDto, trackingId);

            _mapperMock.Verify(x => x.Map<CalculatorDivisionResponseDto>(divisionCommandResponse));
        }

        [Test]
        public async Task Division_Returns_OkObjectResult()
        {
            var dividend = 5;
            var divisor = 2;
            var requestDto = new CalculatorDivisionRequestDto(dividend, divisor);
            var trackingId = "trackingId";

            var result = await _controller.Division(requestDto, trackingId);

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task Division_Returns_Ok_With_Mapped_Response()
        {
            var dividend = 5;
            var divisor = 2;
            var requestDto = new CalculatorDivisionRequestDto(dividend, divisor);
            var trackingId = "trackingId";

            var responseDto = new CalculatorDivisionResponseDto(2,1);

            _mapperMock.Setup(x => x.Map<CalculatorDivisionResponseDto>(It.IsAny<object>())).Returns(responseDto);
            var result = await _controller.Division(requestDto, trackingId);
            var body = ((OkObjectResult)result).Value;

            Assert.That(body, Is.EqualTo(responseDto));
        }

        [Test]
        public async Task Division_Throwing_UnexpectedApplicationException_Returns_Proper_InternalServerError()
        {
            var dividend = 5;
            var divisor = 2;
            var requestDto = new CalculatorDivisionRequestDto(dividend, divisor);
            var trackingId = "trackingId";

            _mediatorMock.Setup(x => x.Send(It.IsAny<DivisionCommand>(), It.IsAny<CancellationToken>())).Throws<UnexpectedApplicationException>();

            var result = await _controller.Division(requestDto, trackingId);

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
