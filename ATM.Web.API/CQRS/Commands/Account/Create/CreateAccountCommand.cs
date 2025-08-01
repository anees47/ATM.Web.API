namespace ATM.Web.API.CQRS.Commands.Account.Create;

public record CreateAccountCommand : ICommand<CreateAccountCommandResult>
{
    public decimal? InitialBalance { get; init; }
} 