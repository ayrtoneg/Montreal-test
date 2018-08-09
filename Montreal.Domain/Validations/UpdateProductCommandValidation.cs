using Montreal.Domain.Commands;

namespace Montreal.Domain.Validations
{
    public class UpdateProductCommandValidation : ProductValidation<UpdateProductCommand>
    {
        public UpdateProductCommandValidation()
        {
            ValidateName();
            ValidateId();
            ValidateDescrition();
            ValidateImages();
        }
    }
}
