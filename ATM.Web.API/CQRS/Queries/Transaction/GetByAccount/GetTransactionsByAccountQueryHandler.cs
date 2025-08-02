using ATM.Web.API.Repositories;
using ATM.Web.API.CQRS.Queries.Transaction.GetByAccount;

namespace ATM.Web.API.CQRS.Queries.Transaction.GetByAccount;

public class GetTransactionsByAccountQueryHandler(ITransactionRepository transactionRepository)
{
    public async Task<GetTransactionsByAccountQueryResult> HandleAsync(GetTransactionsByAccountQuery query)
    {
        try
        {
            var transactions = await transactionRepository.GetByAccountIdAsync(query.AccountId);
            return GetTransactionsByAccountQueryResult.Success(transactions);
        }
        catch (Exception ex)
        {
            return GetTransactionsByAccountQueryResult.Failure($"Failed to retrieve transactions: {ex.Message}");
        }
    }
} 