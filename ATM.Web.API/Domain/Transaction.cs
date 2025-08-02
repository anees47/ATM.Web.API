namespace ATM.Web.API.Domain;

public class Transaction
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string AccountId { get; set; } = "";
    public Account? Account { get; set; }
    public decimal Amount { get; set; } = 0;
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public string TransactionType { get; set; } = "";
    public string? TransferAccountId { get; set; }
} 