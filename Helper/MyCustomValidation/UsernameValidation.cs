using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace JWT_TokenBased.Helper.MyCustomValidation
{
    public class UsernameValidation : ValidationAttribute 
    {
        private readonly string _fieldName;

        public UsernameValidation(string fieldName)
        {
            _fieldName = fieldName;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string username = value.ToString();
                if (!Regex.IsMatch(username, @"^[a-zA-Z0-9]+$"))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}
