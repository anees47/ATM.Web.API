using FluentValidation;

namespace ATM.Web.API.Commands.Account;

public class DeleteAccountCommandValidation : AbstractValidator<DeleteAccountCommand>
{
    public DeleteAccountCommandValidation()
    {
        RuleFor(x => x.AccountId)
            .NotEmpty().WithMessage("Account ID is required");
    }
} 