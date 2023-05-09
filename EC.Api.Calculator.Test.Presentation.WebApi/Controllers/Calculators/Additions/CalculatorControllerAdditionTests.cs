using AutoMapper;
using EC.Api.Calculator.Application.Calculators.Commands.Additions;
using EC.Api.Calculator.Application.Exceptions;
using EC.Api.Calculator.Presentation.WebApi.Common.Errors;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Additions.Dtos;
using EC.Api.Calculator.Test.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace EC.Api.Calculator.Test.Presentation.WebApi.Controllers.Calculators.Additions
{
    [TestFixture]
    [Category(Category.Unit)]
    public class CalculatorControllerAdditionTests
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
        public async Task Addition_Calls_Mediator_With_AdditionCommand_With_Same_Arguments()
        {
            var addends = new List<int> { 1, 2, 3 };
            var requestDto = new CalculatorAdditionRequestDto(addends);
            var trackingId = "trackingId";

            await _controller.Addition(requestDto, trackingId);

            _mediatorMock.Verify(x => x.Send(It.Is<AdditionCommand>(x => x.TrackingId == trackingId && x.Addends == addends), default));
        }

        [Test]
        public async Task Addition_Calls_Map_With_Response_Of_Mediator()
        {
            var addends = new List<int> { 1, 2, 3 };
            var requestDto = new CalculatorAdditionRequestDto(addends);
            var trackingId = "trackingId";

            var additionCommandResponse = new AdditionCommandResponse(6);

            _mediatorMock.Setup(x => x.Send(It.IsAny<AdditionCommand>(), default)).ReturnsAsync(additionCommandResponse);

            await _controller.Addition(requestDto, trackingId);

            _mapperMock.Verify(x => x.Map<CalculatorAdditionResponseDto>(additionCommandResponse));
        }

        [Test]
        public async Task Addition_Returns_OkObjectResult()
        {
            var addends = new List<int> { 1, 2, 3 };
            var requestDto = new CalculatorAdditionRequestDto(addends);
            var trackingId = "trackingId";

            var result = await _controller.Addition(requestDto, trackingId);

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task Addition_Returns_Ok_With_Mapped_Response()
        {
            var addends = new List<int> { 1, 2, 3 };
            var requestDto = new CalculatorAdditionRequestDto(addends);
            var trackingId = "trackingId";

            var responseDto = new CalculatorAdditionResponseDto(5);

            _mapperMock.Setup(x => x.Map<CalculatorAdditionResponseDto>(It.IsAny<object>())).Returns(responseDto);
            var result = await _controller.Addition(requestDto, trackingId);
            var body = ((OkObjectResult)result).Value;

            Assert.That(body, Is.EqualTo(responseDto));
        }

        [Test]
        public async Task Addition_Throwing_UnexpectedApplicationException_Returns_Proper_InternalServerError()
        {
            var addends = new List<int> { 1, 2, 3 };
            var requestDto = new CalculatorAdditionRequestDto(addends);
            var trackingId = "trackingId";

            _mediatorMock.Setup(x => x.Send(It.IsAny<AdditionCommand>(), It.IsAny<CancellationToken>())).Throws<UnexpectedApplicationException>();

            var result = await _controller.Addition(requestDto, trackingId);

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
