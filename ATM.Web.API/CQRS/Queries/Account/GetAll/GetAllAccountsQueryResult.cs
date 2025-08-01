using ATM.Web.API.Domain;

namespace ATM.Web.API.CQRS.Queries.Account.GetAll;

public record GetAllAccountsQueryResult : IQueryResult
{
    public bool IsSuccess { get; init; }
    public string? ErrorMessage { get; init; }
    public IEnumerable<Domain.Account>? Accounts { get; init; }

    public static GetAllAccountsQueryResult Success(IEnumerable<Domain.Account> accounts) => new()
    {
        IsSuccess = true,
        Accounts = accounts
    };

    public static GetAllAccountsQueryResult Failure(string errorMessage) => new()
    {
        IsSuccess = false,
        ErrorMessage = errorMessage
    };
} 