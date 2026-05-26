using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace F1_Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ECUId { get; set; }
        [ForeignKey("ECUId")]
        public ECU ECU { get; set; }

        public int TyreId { get; set; }
        [ForeignKey("TyreId")]
        public Tyres Tyre { get; set; }

        [Range(1, 1000, ErrorMessage = "Please enter a value between 1 and 1000")]
        public int Count { get; set; }

        public int ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
    }
}