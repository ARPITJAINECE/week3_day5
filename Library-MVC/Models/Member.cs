using System.ComponentModel.DataAnnotations;

namespace Library_MVC.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid phone number. Phone number must be 10 digits.")]
        public int MobileNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Invalid pincode. Pincode must be 6 digits.")]
        public string Pincode { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
