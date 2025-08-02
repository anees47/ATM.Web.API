namespace ATM.Web.API.CQRS.Commands.Account.Withdraw;

public class WithdrawCommand : ICommand<WithdrawCommandResult>
{
    public string AccountId { get; set; } = "";
    public decimal Amount { get; set; }
} 