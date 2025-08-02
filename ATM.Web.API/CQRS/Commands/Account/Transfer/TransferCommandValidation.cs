using FluentValidation;
using ATM.Web.API.CQRS.Commands.Account.Transfer;

namespace ATM.Web.API.CQRS.Commands.Account.Transfer;

public class TransferCommandValidation : AbstractValidator<TransferCommand>
{
    public TransferCommandValidation()
    {
        RuleFor(x => x.FromAccountId)
            .NotEmpty()
            .WithMessage("From Account ID is required");

        RuleFor(x => x.ToAccountId)
            .NotEmpty()
            .WithMessage("To Account ID is required");

        RuleFor(x => x.Amount)
            .GreaterThan(0)
            .WithMessage("Transfer amount must be greater than 0");

        RuleFor(x => x.Amount)
            .LessThanOrEqualTo(100000)
            .WithMessage("Transfer amount cannot exceed 100,000 per transaction");

        RuleFor(x => x)
            .Must(x => x.FromAccountId != x.ToAccountId)
            .WithMessage("Cannot transfer to the same account");
    }
} 