using Microsoft.EntityFrameworkCore;
using ATM.Web.API.Data;
using ATM.Web.API.Domain;
using ATM.Web.API.Repositories.Interfaces;

namespace ATM.Web.API.Repositories;

public class TransactionRepository(ATMDbContext context) : ITransactionRepository
{
    public async Task<Transaction> CreateAsync(Transaction transaction)
    {
        context.Transactions.Add(transaction);
        await context.SaveChangesAsync();
        return transaction;
    }

    public async Task<IEnumerable<Transaction>> GetByAccountIdAsync(string accountId)
    {
        return await context.Transactions
            .Where(t => t.AccountId == accountId)
            .OrderByDescending(t => t.Timestamp)
            .ToListAsync();
    }

    public async Task<IEnumerable<Transaction>> GetAllAsync()
    {
        return await context.Transactions
            .OrderByDescending(t => t.Timestamp)
            .ToListAsync();
    }
} 