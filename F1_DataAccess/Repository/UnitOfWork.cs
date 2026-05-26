using F1_DataAccess.Repository.IRepository;
using F1_Garage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IManufacturerRepository Manufacturer {  get; private set; }
        public IOrderHeaderRepository OrderHeader { get; private set; }
        public IOrderDetailsRepository OrderDetails { get; private set; }
        public ICartRepository CartItem { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IProductRepository Product { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Manufacturer=new ManufacturerRepository(_db);
            OrderHeader=new OrderHeaderRepository(_db);
            OrderDetails=new OrderDetailsRepository(_db);
            CartItem=new CartRepository(_db);
            ApplicationUser=new ApplicationUserRepository(_db);
            Product=new ProductRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
