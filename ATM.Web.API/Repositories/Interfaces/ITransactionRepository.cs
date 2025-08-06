using ATM.Web.API.Domain;

namespace ATM.Web.API.Repositories.Interfaces;

public interface ITransactionRepository
{
    Task<Transaction> CreateAsync(Transaction transaction);
    Task<IEnumerable<Transaction>> GetByAccountIdAsync(string accountId);
    Task<IEnumerable<Transaction>> GetAllAsync();
} 