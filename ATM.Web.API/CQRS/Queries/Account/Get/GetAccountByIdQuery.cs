using ATM.Web.API.Domain;

namespace ATM.Web.API.CQRS.Queries.Account.Get;

public record GetAccountByIdQuery : IQuery<GetAccountByIdQueryResult>
{
    public Guid AccountId { get; init; }
} 