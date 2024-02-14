using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace JWT_TokenBased.Helper.MyCustomValidation
{
    public class NameValidation : ValidationAttribute
    {
        private readonly string _fieldName;

        public NameValidation(string fieldName)
        {
            _fieldName = fieldName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string input = value.ToString();
                if (!Regex.IsMatch(input, @"^[a-zA-Z]+$"))
                {
                    return new ValidationResult($"{_fieldName} is not valid.");
                }
            }
            return ValidationResult.Success;
        }
    }

}

