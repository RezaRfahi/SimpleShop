using System.ComponentModel.DataAnnotations;

namespace ShopMVC.Models
{
    public class Order
    {
        public int Id { get; set; }
    
        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
    
        [Display(Name = "Total Amount")]
        [DataType(DataType.Currency)]
        [Range(0, double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal TotalAmount { get; set; }
    
        // Other properties as per your requirements
    
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
