using Montreal.Domain.Commands;

namespace Montreal.Domain.Validations
{
    public class RemoveProductCommandValidation : ProductValidation<RemoveProductCommand>
    {
        public RemoveProductCommandValidation()
        {
            ValidateId();
        }
    }
}
