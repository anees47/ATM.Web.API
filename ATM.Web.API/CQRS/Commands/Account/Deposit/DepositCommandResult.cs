using ATM.Web.API.CQRS.Commands;

namespace ATM.Web.API.CQRS.Commands.Account.Deposit;

public record DepositCommandResult : ICommandResult
{
    public bool IsSuccess { get; init; }
    public string? ErrorMessage { get; init; }
    public decimal? NewBalance { get; init; }

    public static DepositCommandResult Success(decimal newBalance)
    {
        return new DepositCommandResult
        {
            IsSuccess = true,
            NewBalance = newBalance
        };
    }

    public static DepositCommandResult Failure(string errorMessage)
    {
        return new DepositCommandResult
        {
            IsSuccess = false,
            ErrorMessage = errorMessage
        };
    }
} 