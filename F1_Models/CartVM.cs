using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Models
{
    public class CartVM : CartItem
    {
        public IEnumerable<CartItem> CartItems { get; set; }
        public OrderHeader OrderHeader { get; set; }
    }
}
