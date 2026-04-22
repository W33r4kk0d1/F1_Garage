using F1_Garage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_DataAccess.Repository.IRepository
{
    public interface IManufacturerRepository:IRepository<Manufacturer>
    {
        void Update(Manufacturer obj);
        void Save();
    }
}
