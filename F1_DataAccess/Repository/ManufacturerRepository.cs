using F1_DataAccess.Repository.IRepository;
using F1_Garage.Data;
using F1_Garage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_DataAccess.Repository
{
    public class ManufacturerRepository : Repository<Manufacturer>, IManufacturerRepository
    {
        private ApplicationDbContext _db;
        public ManufacturerRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
        public void save()
        {
            _db.SaveChanges();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Manufacturer obj)
        {
            _db.Update(obj);
        }
    }
}
