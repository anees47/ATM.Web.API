namespace ATM.Web.API.CQRS.Commands.Account.Transfer;

public class TransferCommand : ICommand<TransferCommandResult>
{
    public string FromAccountId { get; set; } = "";
    public string ToAccountId { get; set; } = "";
    public decimal Amount { get; set; }
} 