using FluentValidation;
using Montreal.Domain.Commands;
using Montreal.Domain.Models;
using System;

namespace Montreal.Domain.Validations
{
    public abstract class ProductValidation<T> : AbstractValidator<T> where T : ProductCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .Length(1, 100).WithMessage("O nome deve estar entre 1 e 100 caracteres");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateDescrition()
        {
            RuleFor(c => c.Description)
                .MaximumLength(200).WithMessage("A descrição deve ter no máximo 200 caracteres");
        }

        protected void ValidateImages()
        {
            RuleForEach(c => c.Images)
                .SetValidator(new ImageValidation<Image>())
                .NotEmpty().WithMessage("É obrigatório ter ao menos uma imagem ao produto");
        }
    }
}
