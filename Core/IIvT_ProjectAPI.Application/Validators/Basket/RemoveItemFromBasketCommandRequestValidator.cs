using FluentValidation;
using IIvT_ProjectAPI.Application.Features.Commands.Basket.RemoveItemFromBasket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Validators.Basket
{
    public class RemoveItemFromBasketCommandRequestValidator : AbstractValidator<RemoveItemFromBasketCommandRequest>
    {
        public RemoveItemFromBasketCommandRequestValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty()
                .Must(id => Guid.TryParse(id, out _))
                .WithMessage("ProductId must be a valid GUID.");
        }
    }
}
