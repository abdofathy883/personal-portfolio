using System.ComponentModel.DataAnnotations;

namespace AdminDashboard.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Category Name is Required")]

        [MaxLength(50)]
        public required string Name { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        public List<Project>? Projects { get; set; }
    }
}
