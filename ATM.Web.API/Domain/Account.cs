namespace ATM.Web.API.Domain;

public class Account
{
    public string Id { get; init; } = "";
    public string Name { get; init; } = "";
    public decimal Balance { get; set; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public ICollection<Transaction>? Transactions { get; init; } = [];
}

