using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ContosoPets.Ui.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ContosoPetsUser class
    public class ContosoPetsUser : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
    }
}
