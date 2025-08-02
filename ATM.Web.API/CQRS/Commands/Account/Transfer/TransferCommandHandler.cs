using ATM.Web.API.Repositories;
using ATM.Web.API.Domain;
using FluentValidation;

namespace ATM.Web.API.CQRS.Commands.Account.Transfer;

public class TransferCommandHandler(
    IAccountReadRepository readRepository,
    IAccountWriteRepository writeRepository,
    ITransactionRepository transactionRepository,
    IValidator<TransferCommand> validator)
{
    public async Task<TransferCommandResult> HandleAsync(TransferCommand command)
    {
        var validationResult = await validator.ValidateAsync(command);
        if (!validationResult.IsValid)
        {
            return TransferCommandResult.Failure(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));
        }

        var fromAccount = await readRepository.GetByIdAsync(command.FromAccountId);
        if (fromAccount == null)
        {
            return TransferCommandResult.Failure("From account not found");
        }

        var toAccount = await readRepository.GetByIdAsync(command.ToAccountId);
        if (toAccount == null)
        {
            return TransferCommandResult.Failure("To account not found");
        }

        if (fromAccount.Balance < command.Amount)
        {
            return TransferCommandResult.Failure("Not enough funds in from account");
        }

        fromAccount.Balance -= command.Amount;
        toAccount.Balance += command.Amount;

        var fromAccountSuccess = await writeRepository.UpdateAsync(fromAccount);
        if (!fromAccountSuccess)
        {
            return TransferCommandResult.Failure("Failed to update from account");
        }

        var toAccountSuccess = await writeRepository.UpdateAsync(toAccount);
        if (!toAccountSuccess)
        {
            return TransferCommandResult.Failure("Failed to update to account");
        }

        var fromTransaction = new Transaction
        {
            AccountId = command.FromAccountId,
            Amount = -command.Amount,
            TransactionType = "Transfer Out",
            Timestamp = DateTime.UtcNow,
            TransferAccountId = command.ToAccountId
        };

        var toTransaction = new Transaction
        {
            AccountId = command.ToAccountId,
            Amount = command.Amount,
            TransactionType = "Transfer In",
            Timestamp = DateTime.UtcNow,
            TransferAccountId = command.FromAccountId
        };

        await transactionRepository.CreateAsync(fromTransaction);
        await transactionRepository.CreateAsync(toTransaction);

        return TransferCommandResult.Success(fromAccount.Balance, toAccount.Balance);
    }
} 