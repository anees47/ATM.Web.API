using ATM.Web.API.Repositories;
using ATM.Web.API.Repositories.Interfaces;

namespace ATM.Web.API.CQRS.Queries.Account.GetAll;

public class GetAllAccountsQueryHandler(IAccountReadRepository readRepository)
{
    public async Task<GetAllAccountsQueryResult> HandleAsync(GetAllAccountsQuery query)
    {
        var accounts = await readRepository.GetAllAsync();
        return GetAllAccountsQueryResult.Success(accounts);
    }
} 