using Montreal.Domain.Models;
using Montreal.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Montreal.Domain.Commands
{
    public class UpdateProductCommand : ProductCommand
    {
        public UpdateProductCommand(Guid id,string name, string description, ICollection<Image> images, Guid? idFatherProduct = null)
        {
            Id = id;
            Name = name;
            Description = description;
            IdFatherProduct = idFatherProduct;
            Images = images;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
