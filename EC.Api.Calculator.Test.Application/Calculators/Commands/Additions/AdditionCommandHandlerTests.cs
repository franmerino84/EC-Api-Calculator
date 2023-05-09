using AutoMapper;
using EC.Api.Calculator.Application.Calculators.Commands.Additions;
using EC.Api.Calculator.Application.Exceptions;
using EC.Api.Calculator.Domain.Abstractions.Persistence.Repositories;
using EC.Api.Calculator.Domain.Services.CalculationFormatters.Additions;
using EC.Api.Calculator.Domain.Services.OperationFormatters.Additions;
using EC.Api.Calculator.Domain.ValueObjects.Operations;
using Microsoft.Extensions.Logging;
using Moq;

namespace EC.Api.Calculator.Test.Application.Calculators.Commands.Additions
{
    public class AdditionCommandHandlerTests
    {
        private AdditionCommandHandler _handler;
        private Mock<IJournalEntryRepository> _repositoryMock;
        private Mock<IMapper> _mapperMock;
        private Mock<ILogger<AdditionCommandHandler>> _loggerMock;
        private Mock<IAdditionOperationFormatter> _operationFormatterMock;
        private Mock<IAdditionCalculationFormatter> _calculationFormatterMock;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<IJournalEntryRepository>();
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<ILogger<AdditionCommandHandler>>();
            _operationFormatterMock = new Mock<IAdditionOperationFormatter>();
            _calculationFormatterMock = new Mock<IAdditionCalculationFormatter>();

            _handler = new AdditionCommandHandler(_repositoryMock.Object, _mapperMock.Object, _loggerMock.Object, _operationFormatterMock.Object,
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
            Assert.Throws<ArgumentException>(() => _handler.Handle(new AdditionCommand(null), default));
        }

        [Test]
        public void Handle_Addends_Less_Than_2_Elements_Throws_NotEnoughOperandsException()
        {
            Assert.Throws<NotEnoughOperandsException>(() => _handler.Handle(new AdditionCommand(new List<int> { 1 }), default));
        }

        [Test]
        public void Handle_Calls_Mapper_Map_Over_Addition()
        {
            var command = new AdditionCommand(new List<int> { 1, 2, 3 });

            _handler.Handle(command, default);

            _mapperMock.Verify(x => x.Map<AdditionCommandResponse>(It.IsAny<Addition>()));
        }

        [Test]
        public async Task Handle_Returns_Mapped_Addition()
        {
            var command = new AdditionCommand(new List<int> { 1, 2, 3 });
            var response = new AdditionCommandResponse(6);

            _mapperMock.Setup(x => x.Map<AdditionCommandResponse>(It.IsAny<Addition>())).Returns(response);
            var result = await _handler.Handle(command, default);

            Assert.That(result, Is.EqualTo(response));
        }
    }
}

