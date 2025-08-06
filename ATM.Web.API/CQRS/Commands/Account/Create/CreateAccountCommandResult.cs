namespace ATM.Web.API.CQRS.Commands.Account.Create;

public record CreateAccountCommandResult : ICommandResult
{
    public bool IsSuccess { get; set; }
    public string? ErrorMessage { get; set; }
    public Domain.Account? Account { get; set; }

    public static CreateAccountCommandResult Success(Domain.Account account) => new()
    {
        IsSuccess = true,
        Account = account
    };

    public static CreateAccountCommandResult Failure(string errorMessage) => new()
    {
        IsSuccess = false,
        ErrorMessage = errorMessage
    };
} 