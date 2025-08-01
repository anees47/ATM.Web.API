namespace ATM.Web.API.CQRS.Queries;

public interface IQueryResult
{
    bool IsSuccess { get; }
    string? ErrorMessage { get; }
} 