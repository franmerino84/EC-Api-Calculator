using AutoMapper;
using EC.Api.Calculator.Application.Calculators.Commands.Multiplications;
using EC.Api.Calculator.Application.Calculators.Commands.Multiplications;
using EC.Api.Calculator.Application.Exceptions;
using EC.Api.Calculator.Domain.Abstractions.Persistence.Repositories;
using EC.Api.Calculator.Domain.Entities;
using EC.Api.Calculator.Domain.Services.CalculationFormatters.Multiplications;
using EC.Api.Calculator.Domain.Services.OperationFormatters.Multiplications;
using EC.Api.Calculator.Domain.ValueObjects.Operations;
using EC.Api.Calculator.Test.Helpers;
using Microsoft.Extensions.Logging;
using Moq;

namespace EC.Api.Calculator.Test.Application.Calculators.Commands.Multiplications
{
    public class MultiplicationCommandHandlerTests
    {
        private MultiplicationCommandHandler _handler;
        private Mock<IJournalEntryRepository> _repositoryMock;
        private Mock<IMapper> _mapperMock;
        private Mock<ILogger<MultiplicationCommandHandler>> _loggerMock;
        private Mock<IMultiplicationOperationFormatter> _operationFormatterMock;
        private Mock<IMultiplicationCalculationFormatter> _calculationFormatterMock;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<IJournalEntryRepository>();
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<ILogger<MultiplicationCommandHandler>>();
            _operationFormatterMock = new Mock<IMultiplicationOperationFormatter>();
            _calculationFormatterMock = new Mock<IMultiplicationCalculationFormatter>();

            _handler = new MultiplicationCommandHandler(_repositoryMock.Object, _mapperMock.Object, _loggerMock.Object, _operationFormatterMock.Object,
                _calculationFormatterMock.Object);
        }

        [Test]
        public void Handle_Null_Throws_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _handler.Handle(null, default));
        }

        [Test]
        public void Handle_Addends_Null_Throws_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _handler.Handle(new MultiplicationCommand(null), default));
        }

        [Test]
        public void Handle_Addends_Less_Than_2_Elements_Throws_NotEnoughOperandsException()
        {
            Assert.Throws<NotEnoughOperandsException>(() => _handler.Handle(new MultiplicationCommand(new List<int> { 1 }), default));
        }

        [Test]
        public void Handle_Calls_Mapper_Map_Over_Multiplication()
        {
            var command = new MultiplicationCommand(new List<int> { 1, 2, 3 });

            _handler.Handle(command, default);

            _mapperMock.Verify(x => x.Map<MultiplicationCommandResponse>(It.IsAny<Multiplication>()));
        }

        [Test]
        public async Task Handle_Returns_Mapped_Multiplication()
        {
            var command = new MultiplicationCommand(new List<int> { 1, 2, 3 });
            var response = new MultiplicationCommandResponse(6);

            _mapperMock.Setup(x => x.Map<MultiplicationCommandResponse>(It.IsAny<Multiplication>())).Returns(response);
            var result = await _handler.Handle(command, default);

            Assert.That(result, Is.EqualTo(response));
        }

        [Test]
        public async Task Handle_Logs_Information_Success()
        {
            var command = new MultiplicationCommand(new List<int> { 1, 2, 3 });

            await _handler.Handle(command, default);

            _loggerMock.VerifyLogContains(LogLevel.Information, "successfully calculated");
        }

        [Test]
        public async Task Handle_Without_TrackingId_Doesnt_Insert_JournalEntry()
        {
            var command = new MultiplicationCommand(new List<int> { 1, 2, 3 });
            var response = new MultiplicationCommandResponse(6);

            var result = await _handler.Handle(command, default);

            _repositoryMock.Verify(x => x.Insert(It.IsAny<JournalEntry>()), Times.Never());
        }

        [Test]
        public async Task Handle_With_TrackingId_Does_Insert_JournalEntry_Containing_TrackingId()
        {
            var trackingId = "trackingId";
            var command = new MultiplicationCommand(new List<int> { 1, 2, 3 }, trackingId);
            var response = new MultiplicationCommandResponse(6);

            var result = await _handler.Handle(command, default);

            _repositoryMock.Verify(x => x.Insert(It.Is<JournalEntry>(x => x.TrackingId == trackingId)));
        }

        [Test]
        public async Task Handle_With_TrackingId_Calls_OperationFormatter_FormatOperatorName()
        {
            var trackingId = "trackingId";
            var command = new MultiplicationCommand(new List<int> { 1, 2, 3 }, trackingId);
            var response = new MultiplicationCommandResponse(6);

            var result = await _handler.Handle(command, default);

            _operationFormatterMock.Verify(x => x.FormatOperatorName());
        }

        [Test]
        public async Task Handle_With_TrackingId_Calls_CalculationFormatter_FormatCalculation()
        {
            var trackingId = "trackingId";
            var command = new MultiplicationCommand(new List<int> { 1, 2, 3 }, trackingId);
            var response = new MultiplicationCommandResponse(6);

            var result = await _handler.Handle(command, default);

            _calculationFormatterMock.Verify(x => x.FormatCalculation(It.IsAny<Multiplication>()));
        }

        [Test]
        public async Task Handle_With_TrackingId_Logs_Information_Stored_Success()
        {
            var trackingId = "trackingId";
            var command = new MultiplicationCommand(new List<int> { 1, 2, 3 }, trackingId);

            await _handler.Handle(command, default);

            _loggerMock.VerifyLogContains(LogLevel.Information, "successfully stored");
        }

        [Test]
        public void Handle_With_TrackingId_And_Repository_Throwing_Throws_UnexpectedApplicationException()
        {
            var trackingId = "trackingId";
            var command = new MultiplicationCommand(new List<int> { 1, 2, 3 }, trackingId);
            var response = new MultiplicationCommandResponse(6);

            _repositoryMock.Setup(x => x.Insert(It.IsAny<JournalEntry>())).Throws<Exception>();

            Assert.ThrowsAsync<UnexpectedApplicationException>(() => _handler.Handle(command, default));
        }

        [Test]
        public async Task Handle_With_TrackingId_And_Repository_Throwing_Logs_Error()
        {
            var trackingId = "trackingId";
            var command = new MultiplicationCommand(new List<int> { 1, 2, 3 }, trackingId);
            var response = new MultiplicationCommandResponse(6);

            _repositoryMock.Setup(x => x.Insert(It.IsAny<JournalEntry>())).Throws<Exception>();

            try
            {
                await _handler.Handle(command, default);
            }
            catch { /**/ }

            _loggerMock.VerifyLogContains(LogLevel.Error, "Couldn't");
        }


    }
}

