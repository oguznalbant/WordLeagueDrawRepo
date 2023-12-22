using Adesso.WordLeague.DTO;
using System.ComponentModel.DataAnnotations;

namespace Adesso.WordLeague.Validators
{
    public class MultipleValueCheckValidation : ValidationAttribute
    {
        private int[] _requiredValues;

        public MultipleValueCheckValidation(int[] requiredValues)
        {
            _requiredValues = requiredValues;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!_requiredValues.ToList().Contains((int)value))
            {
                return new ValidationResult("Group Count value must ve 4 or 8");
            }

            return ValidationResult.Success;
        }
    }
}
