using System.ComponentModel.DataAnnotations;

namespace AdminDashboard.Models
{
    public class ContactForm
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Your Name Is Required")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Your Phone Number Is Required")]
        [Phone]
        public required string Phone { get; set; }
        [Required(ErrorMessage = "Your Email Is Required")]
        public required string Email { get; set; }
        public string? Message { get; set; }
        public DateTime DateSent { get; set; }
        public bool Status { get; set; }
    }
}
