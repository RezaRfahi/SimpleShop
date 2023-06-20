using System.ComponentModel.DataAnnotations;

namespace ShopMVC.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        [StringLength(50, ErrorMessage = "The Description field must not exceed 50 characters.")]
        public string Description { get; set; }
    }
}
