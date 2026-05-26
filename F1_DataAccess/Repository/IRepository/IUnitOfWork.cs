using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IManufacturerRepository Manufacturer {  get; }
        IOrderHeaderRepository OrderHeader { get; }
        IOrderDetailsRepository OrderDetails { get; }
        ICartRepository CartItem { get; }
        IApplicationUserRepository ApplicationUser { get; }
        IProductRepository Product { get; }
        void Save();
    }
}
