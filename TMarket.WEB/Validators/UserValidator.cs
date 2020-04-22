using FluentValidation;
using TMarket.WEB.Helpers.Constants;
using TMarket.WEB.RequestModels;

namespace TMarket.WEB.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage(ModelConstants.PropertyNotFound)
                .Length(4, 20).WithMessage(ModelConstants.StringLengthError)
                .Matches(ModelConstants.NameRegEx).WithMessage(ModelConstants.InvalidName);

            RuleFor(p => p.Lastname)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage(ModelConstants.PropertyNotFound)
                .Length(5, 35).WithMessage(ModelConstants.StringLengthError)
                .Matches(ModelConstants.NameRegEx).WithMessage(ModelConstants.InvalidName);
        }
    }
}
