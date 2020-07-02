using System.ComponentModel.DataAnnotations;

namespace TheLearningCenter.Models
{
    public class login
    {
        [Required(ErrorMessage = "Please enter your email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter a password")]
        public string Password { get; set; }
    }
}
