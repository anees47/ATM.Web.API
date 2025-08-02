using ATM.Web.API.CQRS.Commands;

namespace ATM.Web.API.CQRS.Commands.Account.Transfer;

public class TransferCommandResult : ICommandResult
{
    public bool IsSuccess { get; init; }
    public string? ErrorMessage { get; init; }
    public decimal? NewFromAccountBalance { get; init; }
    public decimal? NewToAccountBalance { get; init; }

    public static TransferCommandResult Success(decimal newFromAccountBalance, decimal newToAccountBalance)
    {
        return new TransferCommandResult
        {
            IsSuccess = true,
            NewFromAccountBalance = newFromAccountBalance,
            NewToAccountBalance = newToAccountBalance
        };
    }

    public static TransferCommandResult Failure(string errorMessage)
    {
        return new TransferCommandResult
        {
            IsSuccess = false,
            ErrorMessage = errorMessage
        };
    }
} 