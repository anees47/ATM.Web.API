using ATM.Web.API.Domain;

namespace ATM.Web.API.Repositories;

public interface IAccountWriteRepository
{
    Task<Account> CreateAsync(Account account);
    Task<bool> UpdateAsync(Account account);
    Task<bool> DeleteAsync(Guid id);
} 