using ATM.Web.API.Repositories;
using ATM.Web.API.Domain;
using FluentValidation;

namespace ATM.Web.API.CQRS.Commands.Account.Withdraw;

public class WithdrawCommandHandler(
    IAccountReadRepository readRepository,
    IAccountWriteRepository writeRepository,
    ITransactionRepository transactionRepository,
    IValidator<WithdrawCommand> validator)
{
    public async Task<WithdrawCommandResult> HandleAsync(WithdrawCommand command)
    {
        var validationResult = await validator.ValidateAsync(command);
        if (!validationResult.IsValid)
        {
            return WithdrawCommandResult.Failure(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));
        }

        var account = await readRepository.GetByIdAsync(command.AccountId);
        if (account == null)
        {
            return WithdrawCommandResult.Failure("Account not found");
        }

        if (account.Balance < command.Amount)
        {
            return WithdrawCommandResult.Failure("Insufficient funds");
        }

        account.Balance -= command.Amount;
        var success = await writeRepository.UpdateAsync(account);
        
        if (!success)
        {
            return WithdrawCommandResult.Failure("Failed to update account balance");
        }

        var transaction = new Transaction
        {
            AccountId = command.AccountId,
            Amount = -command.Amount,
            TransactionType = "Withdrawal",
            Timestamp = DateTime.UtcNow
        };

        await transactionRepository.CreateAsync(transaction);

        return WithdrawCommandResult.Success(account.Balance);
    }
} 