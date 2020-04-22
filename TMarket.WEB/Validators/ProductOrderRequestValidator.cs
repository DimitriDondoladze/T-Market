using FluentValidation;
using TMarket.WEB.Helpers.Constants;
using TMarket.WEB.RequestModels.Orders;

namespace TMarket.WEB.Validators
{
    public class ProductOrderRequestValidator : AbstractValidator<ProductOrderRequest>
    {
        public ProductOrderRequestValidator()
        {
            RuleFor(x => x.ProductId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage(ModelConstants.PropertyNotFound)
                .GreaterThanOrEqualTo(0).WithMessage(ModelConstants.MustBeMoreThanZero);

            RuleFor(x => x.Quantity)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage(ModelConstants.PropertyNotFound)
                .GreaterThanOrEqualTo(0).WithMessage(ModelConstants.MustBeMoreThanZero);
        }
    }
}
