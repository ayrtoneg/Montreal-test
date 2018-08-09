using Montreal.Domain.Models;
using Montreal.Domain.Validations;
using System;
using System.Collections.Generic;

namespace Montreal.Domain.Commands
{
    public class RegisterNewProductCommand : ProductCommand
    {
        public RegisterNewProductCommand(Guid id, string name, string description, ICollection<Image> images, Guid? idFatherProduct = null)
        {
            Id = id;
            Name = name;
            Description = description;
            Images = images;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
