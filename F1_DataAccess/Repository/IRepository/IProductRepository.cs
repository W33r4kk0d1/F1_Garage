using F1_Models;

namespace F1_DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Products>
    {
        void Update(Products obj);
    }
}