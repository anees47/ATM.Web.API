namespace ATM.Web.API.CQRS.Commands.Account.Create;

public class CreateAccountCommand : ICommand<CreateAccountCommandResult>
{
    public decimal? InitialBalance { get; set; }
} 