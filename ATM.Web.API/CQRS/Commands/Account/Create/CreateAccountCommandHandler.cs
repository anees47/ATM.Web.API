using ATM.Web.API.Repositories;
using ATM.Web.API.Domain;
using FluentValidation;
using ATM.Web.API.CQRS.Commands.Account.Create;

namespace ATM.Web.API.Commands.Account;

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

        var accountNumber = $"ACC{Random.Shared.Next(100000, 999999)}";

        var account = new ATM.Web.API.Domain.Account
        {
            AccountNumber = accountNumber,
            Balance = command.InitialBalance ?? 0
        };

        var createdAccount = await writeRepository.CreateAsync(account);
        return CreateAccountCommandResult.Success(createdAccount);
    }
} 