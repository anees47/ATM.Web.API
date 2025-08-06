using ATM.Web.API.CQRS.Commands.Account.Deposit;
using ATM.Web.API.Domain;
using ATM.Web.API.Repositories;
using ATM.Web.API.Repositories.Interfaces;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Moq;

namespace ATM.Web.API.Tests;

public class DepositCommandHandlerTests
{
    [Fact]
    public async Task HandleAsync_ShouldDepositAmount_WhenCommandIsValidAndAccountExists()
    {
        // Arrange
        var mockValidator = new Mock<IValidator<DepositCommand>>();
        var mockReadRepo = new Mock<IAccountReadRepository>();
        var mockWriteRepo = new Mock<IAccountWriteRepository>();
        var mockTransactionRepo = new Mock<ITransactionRepository>();

        var command = new DepositCommand
        {
            AccountId = "acc123",
            Amount = 500
        };

        var account = new Account
        {
            Id = "acc123",
            Name = "Test Account",
            Balance = 1000,
            CreatedAt = DateTime.UtcNow
        };

        mockValidator
            .Setup(v => v.ValidateAsync(command, default))
            .ReturnsAsync(new ValidationResult());

        mockReadRepo
            .Setup(r => r.GetByIdAsync(command.AccountId))
            .ReturnsAsync(account);

        mockWriteRepo
            .Setup(r => r.UpdateAsync(account))
            .ReturnsAsync(true);

        mockTransactionRepo
            .Setup(r => r.CreateAsync(It.IsAny<Transaction>()))
            .ReturnsAsync(new Transaction());
        
        var handler = new DepositCommandHandler(
            mockReadRepo.Object,
            mockWriteRepo.Object,
            mockTransactionRepo.Object,
            mockValidator.Object
        );

        // Act
        var result = await handler.HandleAsync(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.NewBalance.Should().Be(1500);

        mockTransactionRepo.Verify(r => r.CreateAsync(It.Is<Transaction>(t =>
            t.AccountId == command.AccountId &&
            t.Amount == command.Amount &&
            t.TransactionType == "Deposit"
        )), Times.Once);
    }
}
