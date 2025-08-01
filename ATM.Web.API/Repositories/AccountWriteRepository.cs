using Microsoft.EntityFrameworkCore;
using ATM.Web.API.Data;
using ATM.Web.API.Domain;

namespace ATM.Web.API.Repositories;

public class AccountWriteRepository : IAccountWriteRepository
{
    private readonly ATMDbContext _context;

    public AccountWriteRepository(ATMDbContext context)
    {
        _context = context;
    }

    public async Task<Account> CreateAsync(Account account)
    {
        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();
        return account;
    }

    public async Task<bool> UpdateAsync(Account account)
    {
        _context.Accounts.Update(account);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var account = await _context.Accounts.FindAsync(id);
        if (account == null)
            return false;

        _context.Accounts.Remove(account);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
} 