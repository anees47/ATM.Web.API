namespace ATM.Web.API.Domain;

public class Account
{
    public string Id { get; set; } = "";
    public decimal Balance { get; set; } = 0;
    public ICollection<Transaction>? Transactions { get; set; } = [];
}