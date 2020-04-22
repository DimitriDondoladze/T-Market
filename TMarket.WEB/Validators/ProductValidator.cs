using System;
using FluentValidation;
using TMarket.WEB.Helpers.Constants;
using TMarket.WEB.RequestModels;

namespace TMarket.WEB.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.AvailableCount)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage(ModelConstants.PropertyNotFound)
                .GreaterThanOrEqualTo(0).WithMessage(ModelConstants.MustBeMoreThanZero);
            
            RuleFor(p => p.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage(ModelConstants.PropertyNotFound)
                .Length(3, 30).WithMessage(ModelConstants.StringLengthError);

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage(ModelConstants.PropertyNotFound);

            RuleFor(p => p.UsefulnessTerm)
                .NotEmpty().WithMessage(ModelConstants.PropertyNotFound);

            RuleFor(p => p.IsAvailable)
                .Equal(false).When(p => p.AvailableCount == 0)
                .WithMessage(ModelConstants.IsAvailableLogicError);

            RuleFor(p => p.UsefulnessTerm)
                .NotEmpty().WithMessage(ModelConstants.PropertyNotFound);

            RuleFor(p => p.UsefulnessTerm)
                .GreaterThan(DateTime.Now)
                .WithMessage("ვადა აუცილებლად მომავალში უნდა იყოს!");
        }
    }
}
