using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace F1_Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        [Required]
        public int OrderHeaderId { get; set; }
        [ForeignKey("OrderHeaderId")]
        [ValidateNever]
        public OrderHeader OrderHeader { get; set; }

        [Required]
        public int ECUId { get; set; }
        [ForeignKey("ECUId")]
        [ValidateNever]
        public ECU ECU { get; set; }
        [Required]
        public int TyresId { get; set; }
        [ForeignKey("TyresId")]
        [ValidateNever]

        public int Count { get; set; }
        public double Price { get; set; }
    }
}