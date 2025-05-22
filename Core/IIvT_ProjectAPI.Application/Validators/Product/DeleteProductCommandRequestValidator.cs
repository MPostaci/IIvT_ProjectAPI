using FluentValidation;
using IIvT_ProjectAPI.Application.Features.Commands.Product.DeleteProduct;

namespace IIvT_ProjectAPI.Application.Validators.Product
{
    public class DeleteProductCommandRequestValidator : AbstractValidator<DeleteProductCommandRequest>
    {
        public DeleteProductCommandRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is required.")
                .Must(id => Guid.TryParse(id, out _))
                .WithMessage("Id must be a valid GUID.");
        }
    }
}
