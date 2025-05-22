using FluentValidation;
using IIvT_ProjectAPI.Application.Features.Commands.Basket.UpdateItemQuantity;

namespace IIvT_ProjectAPI.Application.Validators.Basket
{
    public class UpdateItemQuantityCommandRequestValidator : AbstractValidator<UpdateItemQuantityCommandRequest>
    {
        public UpdateItemQuantityCommandRequestValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty()
                .Must(id => Guid.TryParse(id, out _))
                .WithMessage("ProductId must be a valid GUID.");
            RuleFor(x => x.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than zero.");
        }

    }
}
