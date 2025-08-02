using ATM.Web.API.Domain;

namespace ATM.Web.API.Repositories;

public interface IAccountReadRepository
{
    Task<Account?> GetByIdAsync(string id);
    Task<IEnumerable<Account>> GetAllAsync();
} 