namespace ATM.Web.API.CQRS.Commands;

public interface ICommandResult
{
    bool IsSuccess { get; }
    string? ErrorMessage { get; }
} 