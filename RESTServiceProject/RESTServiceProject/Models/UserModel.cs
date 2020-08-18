using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace RESTServiceProject.Models
{
    public class UserModel
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [Required]
        [JsonProperty("Email")]
        public string Email { get; set; }
        [Required]
        [JsonProperty("Password")]
        public string Password { get; set; }
        [JsonProperty("DateAdded")]
        public DateTime DateAdded { get; set; }
    }
}
