namespace ATM.Web.API.CQRS.Commands.Account.Delete;

public class DeleteAccountCommand : ICommand<DeleteAccountCommandResult>
{
    public string AccountId { get; set; } = "";
} 