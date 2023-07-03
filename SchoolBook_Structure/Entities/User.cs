using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SchoolBook_Structure.Entities
{
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

    }
}
