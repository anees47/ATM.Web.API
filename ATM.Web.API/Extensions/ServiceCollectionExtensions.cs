using Microsoft.EntityFrameworkCore;
using ATM.Web.API.Data;
using ATM.Web.API.Repositories;
using ATM.Web.API.Commands.Account;
using FluentValidation;
using FluentValidation.AspNetCore;
using ATM.Web.API.CQRS.Queries.Account.GetAll;
using ATM.Web.API.CQRS.Queries.Account.Get;
using ATM.Web.API.CQRS.Commands.Account.Create;

namespace ATM.Web.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddATMDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ATMDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        
        return services;
    }

    public static IServiceCollection RegisterATMServices(this IServiceCollection services)
    {
        services.AddScoped<IAccountReadRepository, AccountReadRepository>();
        services.AddScoped<IAccountWriteRepository, AccountWriteRepository>();

        services.AddScoped<CreateAccountCommandHandler>();
        services.AddScoped<DeleteAccountCommandHandler>();

        services.AddScoped<GetAccountByIdQueryHandler>();
        services.AddScoped<GetAllAccountsQueryHandler>();

        services.AddScoped<IValidator<CreateAccountCommand>, CreateAccountCommandValidation>();
        services.AddScoped<IValidator<DeleteAccountCommand>, DeleteAccountCommandValidation>();

        
        services.AddFluentValidationAutoValidation();
        
        return services;
    }
} 