using Microsoft.EntityFrameworkCore;
using ATM.Web.API.Data;
using ATM.Web.API.Domain;

namespace ATM.Web.API.Repositories;

public class AccountWriteRepository(ATMDbContext context) : IAccountWriteRepository
{
    public async Task<Account> CreateAsync(Account account)
    {
        context.Accounts.Add(account);
        await context.SaveChangesAsync();
        return account;
    }

    public async Task<bool> UpdateAsync(Account account)
    {
        context.Accounts.Update(account);
        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var account = await context.Accounts.FindAsync(id);
        if (account == null)
            return false;

        context.Accounts.Remove(account);
        var result = await context.SaveChangesAsync();
        return result > 0;
    }
} 