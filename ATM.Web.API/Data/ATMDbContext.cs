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

            entity.Property(e => e.Id)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Balance)
                .HasPrecision(18, 2);

            entity.Property(e => e.CreatedAt)
                .IsRequired();

            entity.HasIndex(e => e.Id)
                .IsUnique();
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Amount).HasPrecision(18, 2);
            entity.Property(e => e.TransactionType).IsRequired().HasMaxLength(50);
            entity.Property(e => e.AccountId).IsRequired().HasMaxLength(50);
            entity.Property(e => e.TransferAccountId).HasMaxLength(50);
            entity.HasOne(e => e.Account)
                .WithMany(e => e.Transactions)
                .HasForeignKey(e => e.AccountId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}