using ATM.Web.API.CQRS.Commands;

namespace ATM.Web.API.Commands.Account;

public record DeleteAccountCommand : ICommand<DeleteAccountCommandResult>
{
    public Guid AccountId { get; init; }
} 