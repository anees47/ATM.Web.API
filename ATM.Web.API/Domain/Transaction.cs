namespace ATM.Web.API.Domain;

public record Transaction
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid AccountId { get; init; }
    public Account? Account { get; init; }
    public decimal Amount { get; init; } = 0;
    public DateTime Timestamp { get; init; } = DateTime.UtcNow;
    public string TransactionType { get; init; } = "";
    public Guid? TransferAccountId { get; init; }
} 