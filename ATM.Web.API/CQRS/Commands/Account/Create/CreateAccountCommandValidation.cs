using FluentValidation;

namespace ATM.Web.API.CQRS.Commands.Account.Create;

public class CreateAccountCommandValidation : AbstractValidator<CreateAccountCommand>
{
    public CreateAccountCommandValidation()
    {
        RuleFor(x => x.InitialBalance)
            .GreaterThanOrEqualTo(0).When(x => x.InitialBalance.HasValue)
            .WithMessage("Initial balance cannot be negative");
    }
} 