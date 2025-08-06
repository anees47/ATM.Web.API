using Microsoft.EntityFrameworkCore;
using ATM.Web.API.Data;
using ATM.Web.API.Domain;
using ATM.Web.API.Repositories.Interfaces;

namespace ATM.Web.API.Repositories;

public class AccountReadRepository(ATMDbContext context) : IAccountReadRepository
{
    public async Task<Account?> GetByIdAsync(string id)
    {
        return await context.Accounts
            .Include(a => a.Transactions)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<Account>> GetAllAsync()
    {
        return await context.Accounts
            .Include(a => a.Transactions)
            .ToListAsync();
    }
} 