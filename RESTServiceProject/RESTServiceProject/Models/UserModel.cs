using Newtonsoft.Json;
using System;

namespace RESTServiceProject.Models
{
    public class UserModel
    {
        [JsonProperty("ID")]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [JsonProperty("dateadded")]
        public DateTime DateAdded { get; set; }
    }
}
