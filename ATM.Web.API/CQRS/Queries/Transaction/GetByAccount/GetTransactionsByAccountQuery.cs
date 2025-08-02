namespace ATM.Web.API.CQRS.Queries.Transaction.GetByAccount;

public class GetTransactionsByAccountQuery : IQuery<GetTransactionsByAccountQueryResult>
{
    public string AccountId { get; set; } = "";
} 