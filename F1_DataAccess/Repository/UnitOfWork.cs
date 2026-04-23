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
        public ITyresRepository Tyres { get; private set; }
        public IECURepository ECU { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Manufacturer=new ManufacturerRepository(_db);
            Tyres=new TyresRepository(_db);
            ECU=new ECURepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
