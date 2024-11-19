using System.ComponentModel.DataAnnotations;

namespace GuidExample.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(25, ErrorMessage = "Name length should not be more than 25 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address email should be in correct format")]
        public string Email { get; set; }
    }
}