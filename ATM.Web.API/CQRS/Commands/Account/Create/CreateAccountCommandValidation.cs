using FluentValidation;

namespace ATM.Web.API.CQRS.Commands.Account.Create;

public class CreateAccountCommandValidation : AbstractValidator<CreateAccountCommand>
{
    public CreateAccountCommandValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Account name is required")
            .MaximumLength(100).WithMessage("Account name must be 100 characters or fewer");
        
        RuleFor(x => x.InitialBalance)
            .GreaterThanOrEqualTo(0).When(x => x.InitialBalance.HasValue)
            .WithMessage("Initial balance cannot be less than 0");
    }
} 