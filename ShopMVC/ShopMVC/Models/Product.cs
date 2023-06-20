using System.ComponentModel.DataAnnotations;

namespace ShopMVC.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "The Price field must be a positive value.")]
        public decimal Price { get; set; }

        [StringLength(100, ErrorMessage = "The Description field must not exceed 100 characters.")]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
