using Microsoft.EntityFrameworkCore;
using ATM.Web.API.Domain;

namespace ATM.Web.API.Data;

public class ATMDbContext(DbContextOptions<ATMDbContext> options) : DbContext(options)
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.AccountNumber).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Balance).HasPrecision(18, 2);
            entity.HasIndex(e => e.AccountNumber).IsUnique();
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Amount).HasPrecision(18, 2);
            entity.Property(e => e.TransactionType).IsRequired().HasMaxLength(50);
            entity.HasOne(e => e.Account)
                  .WithMany(e => e.Transactions)
                  .HasForeignKey(e => e.AccountId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
} 