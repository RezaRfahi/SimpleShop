using System.ComponentModel.DataAnnotations;

namespace ShopMVC.Models 
{
    public class CartItem
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int ProductId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; }

        public ApplicationUser User { get; set; }

        public Product Product { get; set; }
    }   
}   