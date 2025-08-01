namespace ATM.Web.API.CQRS.Queries;

public record QueryResult : IQueryResult
{
    public bool IsSuccess { get; init; }
    public string? ErrorMessage { get; init; }

    public static QueryResult Success() => new() { IsSuccess = true };
    public static QueryResult Failure(string errorMessage) => new() { IsSuccess = false, ErrorMessage = errorMessage };
} 