using System.Text.Json.Serialization;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace MoventureApi.Entities
{
    public class User:Attribute
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }

        [JsonIgnore]
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}