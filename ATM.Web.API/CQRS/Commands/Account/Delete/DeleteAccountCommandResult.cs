using ATM.Web.API.CQRS.Commands;

namespace ATM.Web.API.Commands.Account;

public record DeleteAccountCommandResult : ICommandResult
{
    public bool IsSuccess { get; init; }
    public string? ErrorMessage { get; init; }

    public static DeleteAccountCommandResult Success() => new() { IsSuccess = true };
    public static DeleteAccountCommandResult Failure(string errorMessage) => new() { IsSuccess = false, ErrorMessage = errorMessage };
} 