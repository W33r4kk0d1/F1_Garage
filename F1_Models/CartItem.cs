using System.ComponentModel.DataAnnotations;

namespace F1_Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        public string ItemName { get; set; }

        [Required]
        public string ItemType { get; set; }

        public int ItemId { get; set; }

        public int Quantity { get; set; }
    }
}