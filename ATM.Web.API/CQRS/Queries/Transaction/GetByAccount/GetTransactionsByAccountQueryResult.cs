using ATM.Web.API.CQRS.Queries;
using ATM.Web.API.Domain;

namespace ATM.Web.API.CQRS.Queries.Transaction.GetByAccount;

public record GetTransactionsByAccountQueryResult : IQueryResult
{
    public bool IsSuccess { get; init; }
    public string? ErrorMessage { get; init; }
    public IEnumerable<Domain.Transaction>? Transactions { get; init; }

    public static GetTransactionsByAccountQueryResult Success(IEnumerable<Domain.Transaction> transactions)
    {
        return new GetTransactionsByAccountQueryResult
        {
            IsSuccess = true,
            Transactions = transactions
        };
    }

    public static GetTransactionsByAccountQueryResult Failure(string errorMessage)
    {
        return new GetTransactionsByAccountQueryResult
        {
            IsSuccess = false,
            ErrorMessage = errorMessage
        };
    }
} 