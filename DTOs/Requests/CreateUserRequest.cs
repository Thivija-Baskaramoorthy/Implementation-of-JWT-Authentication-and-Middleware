using JWT_TokenBased.Helper.MyCustomValidation;
using System.ComponentModel.DataAnnotations;

namespace JWT_TokenBased.DTOs.Requests
{
    public class CreateUserRequest
    {
        [Required]
        [NameValidation(nameof(first_name))]
        public string first_name {  get; set; }

        [Required]
        [NameValidation(nameof(last_name))]
        public string last_name { get; set; }

        [Required]
        [EmailValidation(nameof(email))]
        public string email { get; set; }

        [Required]
        [UsernameValidation(nameof(username))]
        public string username { get; set; }

        [Required]
        public string password { get; set; }
        
    }
}
