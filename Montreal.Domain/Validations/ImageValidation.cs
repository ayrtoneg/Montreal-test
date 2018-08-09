using FluentValidation;
using Montreal.Domain.Models;
using System;

namespace Montreal.Domain.Validations
{
    public class ImageValidation<T> : AbstractValidator<T> where T : Image
    {
        public ImageValidation()
        {
            ValidateType();
            ValidateId();
        }

        protected void ValidateType()
        {
            RuleFor(c => c.Type)
                .NotEmpty().WithMessage("Tipo é obrigatório")
                .Length(1, 50).WithMessage("O tipo deve estar entre 1 e 50 caracteres");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
