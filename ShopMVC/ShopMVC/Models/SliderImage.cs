using System.ComponentModel.DataAnnotations;

namespace ShopMVC.Models
{
    public class SliderImage
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The file name is required.")]
        public string FileName { get; set; }

        [StringLength(100, ErrorMessage = "The caption must not exceed 100 characters.")]
        public string? Caption { get; set; }
    }
}
