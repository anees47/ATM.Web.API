using ATM.Web.API.Domain;

namespace ATM.Web.API.CQRS.Queries.Account.Get;

public class GetAccountByIdQuery : IQuery<GetAccountByIdQueryResult>
{
    public string AccountId { get; set; } = "";
} 