using AutoMapper;
using EC.Api.Calculator.Application.Calculators.Commands.SquareRoots;
using EC.Api.Calculator.Application.Exceptions;
using EC.Api.Calculator.Application.Journals;
using EC.Api.Calculator.Application.Journals.Queries.GetByTrackingId;
using EC.Api.Calculator.Domain.Abstractions.Persistence.Repositories;
using EC.Api.Calculator.Domain.Entities;
using EC.Api.Calculator.Domain.Services.CalculationFormatters.SquareRoots;
using EC.Api.Calculator.Domain.Services.OperationFormatters.SquareRoots;
using EC.Api.Calculator.Domain.ValueObjects.Operations;
using EC.Api.Calculator.Test.Helpers;
using Microsoft.Extensions.Logging;
using Moq;

namespace EC.Api.Calculator.Test.Application.Journals.Queries.GetByTrackingId
{
    public class GetJournalByTrackingIdQueryHandlerTests
    {
        private GetJournalByTrackingIdQueryHandler _handler;
        private Mock<IJournalEntryRepository> _repositoryMock;
        private Mock<IMapper> _mapperMock;
        private Mock<ILogger<GetJournalByTrackingIdQueryHandler>> _loggerMock;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<IJournalEntryRepository>();
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<ILogger<GetJournalByTrackingIdQueryHandler>>();

            _handler = new GetJournalByTrackingIdQueryHandler(_repositoryMock.Object, _mapperMock.Object, _loggerMock.Object);
        }

        [Test]
        public void Handle_Null_Throws_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _handler.Handle(null, default));
        }

        [Test]
        public void Handle_TrackingId_WhiteSpace()
        {
            Assert.Throws<ArgumentException>(() => _handler.Handle(new GetJournalByTrackingIdQuery("  "), default));
        }


        [Test]
        public void Handle_Calls_Mapper_Map_Over_JournalEntries()
        {
            var command = new GetJournalByTrackingIdQuery("trackingId");

            _handler.Handle(command, default);

            _mapperMock.Verify(x => x.Map<IEnumerable<JournalOperation>>(It.IsAny<IEnumerable<JournalEntry>>()));
        }

        

        [Test]
        public async Task Handle_Returns_Mapped_JournalOperations()
        {
            var command = new GetJournalByTrackingIdQuery("trackingId");
            var journalOperation = new JournalOperation("operation", "calculation", DateTime.Now);
            var journalOperations = new List<JournalOperation> { journalOperation };
            var response = new GetJournalByTrackingIdQueryResponse(new List<JournalOperation> { journalOperation });

            _mapperMock.Setup(x => x.Map<IEnumerable<JournalOperation>>(It.IsAny<IEnumerable<JournalEntry>>())).Returns(journalOperations);
            
            var result = await _handler.Handle(command, default);

            Assert.That(result.Operations, Is.EquivalentTo(response.Operations));
        }

        [Test]
        public async Task Handle_Logs_Information_Success()
        {
            var command = new GetJournalByTrackingIdQuery("trackingId");

            await _handler.Handle(command, default);

            _loggerMock.VerifyLogContains(LogLevel.Information, "successfully retrieved");
        }

        
       
        [Test]
        public async Task Handle_Calls_Repository_GetTrackingId()
        {
            var trackingId = "trackingId";
            var command = new GetJournalByTrackingIdQuery(trackingId);

            var result = await _handler.Handle(command, default);

            _repositoryMock.Verify(x => x.GetByTrackingId(trackingId));
        }
        
        [Test]
        public void Handle_With_Repository_Throwing_Throws_UnexpectedApplicationException()
        {
            var trackingId = "trackingId";
            var command = new GetJournalByTrackingIdQuery(trackingId);

            _repositoryMock.Setup(x => x.GetByTrackingId(trackingId)).Throws<Exception>();

            Assert.ThrowsAsync<UnexpectedApplicationException>(() => _handler.Handle(command, default));
        }

        [Test]
        public async Task Handle_With_TrackingId_And_Repository_Throwing_Logs_Error()
        {
            var trackingId = "trackingId";
            var command = new GetJournalByTrackingIdQuery(trackingId);


            _repositoryMock.Setup(x => x.GetByTrackingId(trackingId)).Throws<Exception>();

            try
            {
                await _handler.Handle(command, default);
            }
            catch {  }

            _loggerMock.VerifyLogContains(LogLevel.Error, "Couldn't");
        }
        


    }
}

