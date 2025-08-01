namespace ATM.Web.API.Domain;

public record Account
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string AccountNumber { get; init; } = "";
    public decimal Balance { get; init; } = 0;
    public ICollection<Transaction>? Transactions { get; init; } = [];
} 