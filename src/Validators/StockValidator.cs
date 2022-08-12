using FluentValidation;
using SwaggerAnnotationsExample.DTOs;

namespace SwaggerAnnotationsExample.Validators
{
    public class StockValidator : AbstractValidator<StockDto>
    {
        public StockValidator()
        {
            RuleFor(s => s.Price).Cascade(CascadeMode.Continue).GreaterThan(0).WithMessage("Price must be larger than $0.").LessThan(20).WithMessage("Price cannot be more than $20.").Empty().WithMessage("It cannot be empty!");
            RuleFor(s => s.Symbol).NotEmpty().Length(1, 4).WithMessage("Symbol cannot exceed 4 characters.");
        }
    }
}
