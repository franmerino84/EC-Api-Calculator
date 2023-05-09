using AutoMapper;
using EC.Api.Calculator.Application.Exceptions;
using EC.Api.Calculator.Application.Journals;
using EC.Api.Calculator.Application.Journals.Queries.GetByTrackingId;
using EC.Api.Calculator.Presentation.WebApi.Common.Errors;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Journals;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Journals.Query.Dtos;
using EC.Api.Calculator.Test.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace EC.Api.Journal.Test.Presentation.WebApi.Controllers.Journals
{
    [TestFixture]
    [Category(Category.Unit)]
    public class JournalControllerQueryTests
    {
        private JournalController _controller;
        private Mock<IMapper> _mapperMock;
        private Mock<IMediator> _mediatorMock;

        [SetUp]
        public void Setup()
        {
            _mapperMock = new Mock<IMapper>();
            _mediatorMock = new Mock<IMediator>();
            _controller = new JournalController(_mapperMock.Object, _mediatorMock.Object);
        }

        [Test]
        public async Task Query_Calls_Mediator_With_GetJournalByTrackingIdQuery_With_Same_Arguments()
        {
            var id = "id";
            var requestDto = new JournalQueryRequestDto(id);

            await _controller.Query(requestDto);

            _mediatorMock.Verify(x => x.Send(It.Is<GetJournalByTrackingIdQuery>(x => x.TrackingId == id), default));
        }

        [Test]
        public async Task Query_Calls_Map_With_Response_Of_Mediator()
        {
            var id = "id";
            var requestDto = new JournalQueryRequestDto(id);

            var operations = new List<JournalOperation> {
                new JournalOperation("operation1", "calculation1", DateTime.Now) ,
                new JournalOperation("operation2", "calculation2", DateTime.Now) ,
            };
            var queryCommandResponse = new GetJournalByTrackingIdQueryResponse(operations);

            _mediatorMock.Setup(x => x.Send(It.IsAny<GetJournalByTrackingIdQuery>(), default)).ReturnsAsync(queryCommandResponse);

            await _controller.Query(requestDto);

            _mapperMock.Verify(x => x.Map<JournalQueryResponseDto>(queryCommandResponse));
        }

        [Test]
        public async Task Query_Returns_OkObjectResult()
        {
            var id = "id";
            var requestDto = new JournalQueryRequestDto(id);

            var result = await _controller.Query(requestDto);

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task Query_Returns_Ok_With_Mapped_Response()
        {
            var id = "id";
            var requestDto = new JournalQueryRequestDto(id);
            var operations = new List<JournalQueryOperationDto> {
                new JournalQueryOperationDto("operation1", "calculation1", DateTime.Now) ,
                new JournalQueryOperationDto("operation2", "calculation2", DateTime.Now) ,
            };
            var responseDto = new JournalQueryResponseDto(operations);

            _mapperMock.Setup(x => x.Map<JournalQueryResponseDto>(It.IsAny<object>())).Returns(responseDto);
            var result = await _controller.Query(requestDto);
            var body = ((OkObjectResult)result).Value;

            Assert.That(body, Is.EqualTo(responseDto));
        }

        [Test]
        public async Task Query_Throwing_UnexpectedApplicationException_Returns_Proper_InternalServerError()
        {
            var id = "id";
            var requestDto = new JournalQueryRequestDto(id);

            _mediatorMock.Setup(x => x.Send(It.IsAny<GetJournalByTrackingIdQuery>(), It.IsAny<CancellationToken>())).Throws<UnexpectedApplicationException>();

            var result = await _controller.Query(requestDto);

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
