using ATM.Web.API.CQRS.Commands.Account.Create;
using ATM.Web.API.Domain;
using ATM.Web.API.Repositories;
using ATM.Web.API.Repositories.Interfaces;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Moq;

namespace ATM.Web.API.Tests;

public class CreateAccountCommandHandlerTests
{
    [Fact]
    public async Task HandleAsync_ShouldCreateAccount_WhenCommandIsValid()
    {
        // Arrange
        var mockValidator = new Mock<IValidator<CreateAccountCommand>>();
        var mockRepository = new Mock<IAccountWriteRepository>();

        var command = new CreateAccountCommand
        {
            Name = "Test Account",
            InitialBalance = 1000
        };

        mockValidator
            .Setup(v => v.ValidateAsync(command, default))
            .ReturnsAsync(new ValidationResult());

        var expectedAccount = new Account
        {
            Id = "555123456",
            Name = command.Name,
            CreatedAt = DateTime.UtcNow,
            Balance = command.InitialBalance.Value
        };

        mockRepository
            .Setup(r => r.CreateAsync(It.IsAny<Account>()))
            .ReturnsAsync(expectedAccount);

        var handler = new CreateAccountCommandHandler(mockRepository.Object, mockValidator.Object);

        // Act
        var result = await handler.HandleAsync(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Account.Should().NotBeNull();
        result.Account.Name.Should().Be(command.Name);
        result.Account.Balance.Should().Be(command.InitialBalance.Value);
    }
}