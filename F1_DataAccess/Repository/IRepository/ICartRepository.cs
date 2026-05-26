using F1_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_DataAccess.Repository.IRepository
{
    public interface ICartRepository : IRepository<CartItem>
    {
        void Update(CartItem obj);
    }
}
