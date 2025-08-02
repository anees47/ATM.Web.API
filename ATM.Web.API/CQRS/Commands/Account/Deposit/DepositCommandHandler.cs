using ATM.Web.API.Repositories;
using ATM.Web.API.Domain;
using FluentValidation;

namespace ATM.Web.API.CQRS.Commands.Account.Deposit;

public class DepositCommandHandler(
    IAccountReadRepository readRepository,
    IAccountWriteRepository writeRepository,
    ITransactionRepository transactionRepository,
    IValidator<DepositCommand> validator)
{
    public async Task<DepositCommandResult> HandleAsync(DepositCommand command)
    {
        var validationResult = await validator.ValidateAsync(command);
        if (!validationResult.IsValid)
        {
            return DepositCommandResult.Failure(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));
        }

        var account = await readRepository.GetByIdAsync(command.AccountId);
        if (account == null)
        {
            return DepositCommandResult.Failure("Account not found");
        }

        account.Balance += command.Amount;
        var success = await writeRepository.UpdateAsync(account);
        
        if (!success)
        {
            return DepositCommandResult.Failure("Failed to update account balance");
        }

        var transaction = new Transaction
        {
            AccountId = command.AccountId,
            Amount = command.Amount,
            TransactionType = "Deposit",
            Timestamp = DateTime.UtcNow
        };

        await transactionRepository.CreateAsync(transaction);

        return DepositCommandResult.Success(account.Balance);
    }
} 