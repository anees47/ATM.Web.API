using ATM.Web.API.Repositories.Interfaces;
using FluentValidation;

namespace ATM.Web.API.CQRS.Commands.Account.Delete;

public class DeleteAccountCommandHandler(
    IAccountReadRepository readRepository,
    IAccountWriteRepository writeRepository,
    IValidator<DeleteAccountCommand> validator)
{
    public async Task<DeleteAccountCommandResult> HandleAsync(DeleteAccountCommand command)
    {
        var validationResult = await validator.ValidateAsync(command);
        if (!validationResult.IsValid)
        {
            return DeleteAccountCommandResult.Failure(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));
        }

        var account = await readRepository.GetByIdAsync(command.AccountId);
        if (account == null)
        {
            return DeleteAccountCommandResult.Failure("Account not found");
        }

        if (account.Balance > 0)
        {
            return DeleteAccountCommandResult.Failure("Cannot delete account with positive balance");
        }

        var success = await writeRepository.DeleteAsync(command.AccountId);
        if (!success)
        {
            return DeleteAccountCommandResult.Failure("Failed to delete account");
        }

        return DeleteAccountCommandResult.Success();
    }
} 