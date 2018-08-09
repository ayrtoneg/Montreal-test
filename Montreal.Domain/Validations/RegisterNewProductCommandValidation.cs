using Montreal.Domain.Commands;

namespace Montreal.Domain.Validations
{
    public class RegisterNewProductCommandValidation : ProductValidation<RegisterNewProductCommand>
    {
        public RegisterNewProductCommandValidation()
        {
            ValidateName();
            ValidateDescrition();
            ValidateImages();
        }
    }
}
