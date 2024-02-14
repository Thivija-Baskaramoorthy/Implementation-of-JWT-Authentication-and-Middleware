
using JWT_TokenBased.Helper;
using JWT_TokenBased.Helper.MyCustomValidation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace JWT_TokenBased.Models
{
    [Table("user")]
    public class UserModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [Required]
        [DisplayName("First Name")]
        [NameValidation(nameof(first_name))]
        public string first_name { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [NameValidation(nameof(last_name))]
        public string last_name { get; set; }

        [Required]
        [DisplayName("User Name")]
        [UsernameValidation(nameof(username))]
        public string username { get; set; }

        [Required]
        [DisplayName("Email")]
        [EmailValidation(nameof(email))]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime created_at { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updated_at { get; set; }

    }
}
