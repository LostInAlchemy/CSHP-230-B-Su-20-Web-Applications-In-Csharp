using System.ComponentModel.DataAnnotations;

namespace TheLearningCenter.Models
{
    public class NewAccount
    {
        [Required(ErrorMessage = "Please enter your email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter a password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please confirm your password")]
        public string ConfirmPassword { get; set; }
    }
}
