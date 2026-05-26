using F1_Garage.Data;
using F1_Models;
using F1_DataAccess.Repository.IRepository;

namespace F1_DataAccess.Repository
{
    public class ProductRepository : Repository<Products>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Products obj)
        {
            _db.Products.Update(obj);
        }
    }
}