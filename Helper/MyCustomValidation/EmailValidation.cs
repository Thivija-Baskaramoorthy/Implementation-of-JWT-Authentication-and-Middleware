using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace JWT_TokenBased.Helper.MyCustomValidation
{
    public class EmailValidation: ValidationAttribute
    {
        private readonly string _fieldName;

        public EmailValidation(string fieldName)
        {
            _fieldName = fieldName;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string input = value.ToString();

                // Split the email address into prefix and domain parts
                string[] parts = input.Split('@');
                if (parts.Length != 2)
                {
                    return new ValidationResult($"{_fieldName} must contain only one '@' symbol");
                }

                string prefix = parts[0];
                string domain = parts[1];

                // Validate the prefix (local part) of the email address
                if (!Regex.IsMatch(prefix, @"^[a-zA-Z0-9._%+-]+$"))
                {
                    return new ValidationResult($"The prefix of {_fieldName} is not valid");
                }

                // Validate the domain part of the email address using the IsEmail method
                if (!IsEmail(input))
                {
                    return new ValidationResult($"{_fieldName} format is not valid");
                }
            }
            return ValidationResult.Success;
        }

        private bool IsEmail(string input)
        {
            // Email regex pattern to match standard email format
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(input, emailPattern);
        }

    }
}
