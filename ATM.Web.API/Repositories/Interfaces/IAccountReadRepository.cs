using ATM.Web.API.Domain;

namespace ATM.Web.API.Repositories;

public interface IAccountReadRepository
{
    Task<Account?> GetByIdAsync(Guid id);
    Task<Account?> GetByAccountNumberAsync(string accountNumber);
    Task<IEnumerable<Account>> GetAllAsync();
} 