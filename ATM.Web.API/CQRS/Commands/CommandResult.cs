namespace ATM.Web.API.CQRS.Commands;

public record CommandResult : ICommandResult
{
    public bool IsSuccess { get; init; }
    public string? ErrorMessage { get; init; }

    public static CommandResult Success() => new() { IsSuccess = true };
    public static CommandResult Failure(string errorMessage) => new() { IsSuccess = false, ErrorMessage = errorMessage };
} 