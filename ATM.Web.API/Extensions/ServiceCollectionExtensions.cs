using Microsoft.EntityFrameworkCore;
using ATM.Web.API.Data;
using ATM.Web.API.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using ATM.Web.API.CQRS.Queries.Account.GetAll;
using ATM.Web.API.CQRS.Queries.Account.Get;
using ATM.Web.API.CQRS.Commands.Account.Create;
using ATM.Web.API.CQRS.Commands.Account.Delete;
using ATM.Web.API.CQRS.Commands.Account.Deposit;
using ATM.Web.API.CQRS.Commands.Account.Withdraw;
using ATM.Web.API.CQRS.Commands.Account.Transfer;
using ATM.Web.API.CQRS.Queries.Transaction.GetByAccount;
using ATM.Web.API.Repositories.Interfaces;

namespace ATM.Web.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddATMDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ATMDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        
        return services;
    }

    public static IServiceCollection RegisterATMServices(this IServiceCollection servicesCollection)
    {
        servicesCollection.AddScoped<IAccountReadRepository, AccountReadRepository>();
        servicesCollection.AddScoped<IAccountWriteRepository, AccountWriteRepository>();
        servicesCollection.AddScoped<ITransactionRepository, TransactionRepository>();

        servicesCollection.AddScoped<CreateAccountCommandHandler>();
        servicesCollection.AddScoped<DeleteAccountCommandHandler>();
        servicesCollection.AddScoped<DepositCommandHandler>();
        servicesCollection.AddScoped<WithdrawCommandHandler>();
        servicesCollection.AddScoped<TransferCommandHandler>();

        servicesCollection.AddScoped<GetAccountByIdQueryHandler>();
        servicesCollection.AddScoped<GetAllAccountsQueryHandler>();
        servicesCollection.AddScoped<GetTransactionsByAccountQueryHandler>();

        servicesCollection.AddScoped<IValidator<CreateAccountCommand>, CreateAccountCommandValidation>();
        servicesCollection.AddScoped<IValidator<DeleteAccountCommand>, DeleteAccountCommandValidation>();
        servicesCollection.AddScoped<IValidator<DepositCommand>, DepositCommandValidation>();
        servicesCollection.AddScoped<IValidator<WithdrawCommand>, WithdrawCommandValidation>();
        servicesCollection.AddScoped<IValidator<TransferCommand>, TransferCommandValidation>();

        
        servicesCollection.AddFluentValidationAutoValidation();
        
        return servicesCollection;
    }
} 