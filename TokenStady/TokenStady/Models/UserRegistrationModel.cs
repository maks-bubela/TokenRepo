using System.ComponentModel.DataAnnotations;

namespace MintyIssueTracker.Models
{
    public class UserRegistrationModel
    {
        [Required, MinLength(4), MaxLength(16)]
        public string Username { get; set; }

        [Required, MinLength(6), MaxLength(16)]
        public string Password { get; set; }

        [Required, MinLength(6), MaxLength(16), Compare("Password")]
        public string RePassword { get; set; }

        [Required, MinLength(3), MaxLength(16)]
        public string Firstname { get; set; }

        [Required, MinLength(3), MaxLength(16)]
        public string Lastname { get; set; }

        [Required, MinLength(3), MaxLength(16)]
        public string RoleName { get; set; }
    }
}