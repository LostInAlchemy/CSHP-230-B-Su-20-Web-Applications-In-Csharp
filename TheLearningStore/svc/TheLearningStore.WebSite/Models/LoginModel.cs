using System.ComponentModel.DataAnnotations;

namespace TheLearningCenter.WebSite.Models
{
    public class LoginModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}