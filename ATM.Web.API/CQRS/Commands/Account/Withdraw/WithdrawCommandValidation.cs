using FluentValidation;
using ATM.Web.API.CQRS.Commands.Account.Withdraw;

namespace ATM.Web.API.CQRS.Commands.Account.Withdraw;

public class WithdrawCommandValidation : AbstractValidator<WithdrawCommand>
{
    public WithdrawCommandValidation()
    {
        RuleFor(x => x.AccountId)
            .NotEmpty()
            .WithMessage("Account ID is required");

        RuleFor(x => x.Amount)
            .GreaterThan(0)
            .WithMessage("Withdrawal amount must be greater than 0");

        RuleFor(x => x.Amount)
            .LessThanOrEqualTo(10000)
            .WithMessage("Withdrawal amount cannot exceed 10,000 per transaction");
    }
} 