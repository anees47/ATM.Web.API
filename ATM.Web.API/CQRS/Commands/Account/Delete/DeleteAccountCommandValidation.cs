using FluentValidation;

namespace ATM.Web.API.CQRS.Commands.Account.Delete;

public class DeleteAccountCommandValidation : AbstractValidator<DeleteAccountCommand>
{
    public DeleteAccountCommandValidation()
    {
        RuleFor(x => x.AccountId)
            .NotEmpty().WithMessage("Account ID is required");
    }
} 