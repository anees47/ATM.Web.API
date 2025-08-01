using ATM.Web.API.Repositories;

namespace ATM.Web.API.CQRS.Queries.Account.GetAll;

public class GetAllAccountsQueryHandler(IAccountReadRepository readRepository)
{
    public async Task<GetAllAccountsQueryResult> HandleAsync(GetAllAccountsQuery query)
    {
        var accounts = await readRepository.GetAllAsync();
        return GetAllAccountsQueryResult.Success(accounts);
    }
} 