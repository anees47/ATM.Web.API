namespace ATM.Web.API.CQRS.Commands.Account.Deposit;

public class DepositCommand : ICommand<DepositCommandResult>
{
    public string AccountId { get; set; } = "";
    public decimal Amount { get; set; }
} 