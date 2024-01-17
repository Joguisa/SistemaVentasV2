using FluentValidation;
using POS.Application.Dtos.Category.Request;

namespace POS.Application.Validators.Category
{
    public class CategoryValidator : AbstractValidator<CategoryRequestDto>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El nombre no puede ser nulo")
                .NotEmpty().WithMessage("El nombre no puede estar vacío");
            //RuleFor(x => x.Description)
            //    .NotNull().WithMessage("La descripción no puede ser nula");
        }

    }
}
