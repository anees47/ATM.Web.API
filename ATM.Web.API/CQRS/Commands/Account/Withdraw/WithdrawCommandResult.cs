using ATM.Web.API.CQRS.Commands;

namespace ATM.Web.API.CQRS.Commands.Account.Withdraw;

public record WithdrawCommandResult : ICommandResult
{
    public bool IsSuccess { get; init; }
    public string? ErrorMessage { get; init; }
    public decimal? NewBalance { get; init; }

    public static WithdrawCommandResult Success(decimal newBalance)
    {
        return new WithdrawCommandResult
        {
            IsSuccess = true,
            NewBalance = newBalance
        };
    }

    public static WithdrawCommandResult Failure(string errorMessage)
    {
        return new WithdrawCommandResult
        {
            IsSuccess = false,
            ErrorMessage = errorMessage
        };
    }
} 