using FluentValidation;
using ATM.Web.API.CQRS.Commands.Account.Deposit;

namespace ATM.Web.API.CQRS.Commands.Account.Deposit;

public class DepositCommandValidation : AbstractValidator<DepositCommand>
{
    public DepositCommandValidation()
    {
        RuleFor(x => x.AccountId)
            .NotEmpty()
            .WithMessage("Account ID is required");

        RuleFor(x => x.Amount)
            .GreaterThan(0)
            .WithMessage("Deposit amount must be greater than 0");

        RuleFor(x => x.Amount)
            .LessThanOrEqualTo(1000000)
            .WithMessage("Deposit amount cannot exceed 1,000,000");
    }
} 