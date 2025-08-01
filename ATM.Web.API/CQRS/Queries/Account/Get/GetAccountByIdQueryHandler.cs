using ATM.Web.API.Repositories;

namespace ATM.Web.API.CQRS.Queries.Account.Get;

public class GetAccountByIdQueryHandler(IAccountReadRepository readRepository)
{
    public async Task<GetAccountByIdQueryResult> HandleAsync(GetAccountByIdQuery query)
    {
        var account = await readRepository.GetByIdAsync(query.AccountId);
        
        if (account == null)
        {
            return GetAccountByIdQueryResult.Failure("Account not found");
        }

        return GetAccountByIdQueryResult.Success(account);
    }
} 