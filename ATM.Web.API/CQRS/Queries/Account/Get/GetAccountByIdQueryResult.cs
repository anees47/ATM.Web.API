using ATM.Web.API.Domain;

namespace ATM.Web.API.CQRS.Queries.Account.Get;

public record GetAccountByIdQueryResult : IQueryResult
{
    public bool IsSuccess { get; init; }
    public string? ErrorMessage { get; init; }
    public Domain.Account? Account { get; init; }

    public static GetAccountByIdQueryResult Success(Domain.Account account) => new()
    {
        IsSuccess = true,
        Account = account
    };

    public static GetAccountByIdQueryResult Failure(string errorMessage) => new()
    {
        IsSuccess = false,
        ErrorMessage = errorMessage
    };
} 