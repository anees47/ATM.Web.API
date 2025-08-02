using ATM.Web.API.Repositories;
using ATM.Web.API.Domain;
using FluentValidation;

namespace ATM.Web.API.CQRS.Commands.Account.Create;

public class CreateAccountCommandHandler(
    IAccountWriteRepository writeRepository,
    IValidator<CreateAccountCommand> validator)
{
    public async Task<CreateAccountCommandResult> HandleAsync(CreateAccountCommand command)
    {
        var validationResult = await validator.ValidateAsync(command);
        if (!validationResult.IsValid)
        {
            return CreateAccountCommandResult.Failure(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));
        }

        var accountNumber = $"555{Random.Shared.Next(100000, 999999)}";

        var account = new Domain.Account
        {
            Id = accountNumber,
            Balance = command.InitialBalance ?? 0
        };

        var createdAccount = await writeRepository.CreateAsync(account);
        return CreateAccountCommandResult.Success(createdAccount);
    }
} 