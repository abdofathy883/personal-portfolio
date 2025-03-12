using System.ComponentModel.DataAnnotations;

namespace AdminDashboard.Models
{
    public class Project
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Project Title is Required")]
        public required string Title { get; set; }
        [Required(ErrorMessage = "Project Description is Required")]
        public required string Discription { get; set; }
        [Required(ErrorMessage = "Technologies are Required")]
        public required string Technologies { get; set; }
        [Required(ErrorMessage = "Project URL is Required")]
        public required string URL { get; set; }
        [Required(ErrorMessage = "Project Date is Required")]
        public required DateOnly CreatedAt { get; set; }
        [Required(ErrorMessage = "Project Image is Required")]
        public required string ImageURL { get; set; }
        public bool IsFeatured { get; set; }
        public Category? Category { get; set; }
        public virtual int CategoryID { get; set; }
    }
}
