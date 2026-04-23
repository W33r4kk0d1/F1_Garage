using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F1_DataAccess.Repository.IRepository;
using F1_Garage.Data;
using F1_Models;

namespace F1_DataAccess.Repository
{
    public class ECURepository : Repository<ECU>, IECURepository
    {
        private readonly ApplicationDbContext _db;

        public ECURepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ECU obj)
        {
            _db.ECUs.Update(obj);
        }
    }
}