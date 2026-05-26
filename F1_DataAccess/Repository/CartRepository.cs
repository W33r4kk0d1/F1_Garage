using F1_DataAccess.Repository.IRepository;
using F1_Garage.Data;
using F1_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_DataAccess.Repository
{
    public class CartRepository : Repository<CartItem>, ICartRepository
    {
        private ApplicationDbContext _db;

        public CartRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }
        public void Update(CartItem obj)
        {
            _db.CartItems.Update(obj);
        }
    }
}
