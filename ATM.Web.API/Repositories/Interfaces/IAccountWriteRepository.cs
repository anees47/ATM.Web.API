using ATM.Web.API.Domain;

namespace ATM.Web.API.Repositories.Interfaces;

public interface IAccountWriteRepository
{
    Task<Account> CreateAsync(Account account);
    Task<bool> UpdateAsync(Account account);
    Task<bool> DeleteAsync(string id);
} 