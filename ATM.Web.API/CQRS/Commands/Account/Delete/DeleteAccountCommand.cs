using ATM.Web.API.CQRS.Commands;

namespace ATM.Web.API.Commands.Account;

public class DeleteAccountCommand : ICommand<DeleteAccountCommandResult>
{
    public string AccountId { get; set; } = "";
} 