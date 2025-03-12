using System.ComponentModel.DataAnnotations;

namespace AdminDashboard.Models
{
    public class ProjectDTO
    {
        public string Title { get; set; } 
        [Required(ErrorMessage = "Project Description is Required")]
        public string Discription { get; set; } 
        [Required(ErrorMessage = "Technologies are Required")]
        public string Technologies { get; set; }
        [Required(ErrorMessage = "Project URL is Required")]
        public string URL { get; set; } 
        [Required(ErrorMessage = "Project Date is Required")]
        public DateOnly CreatedAt { get; set; }
        [Required(ErrorMessage = "Project Image is Required")]
        public IFormFile ImageURL { get; set; }
        public bool? IsFeatured { get; set; } 
        public Category? Category { get; set; }
        public virtual int? CategoryID { get; set; }
    }
}
