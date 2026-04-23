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
    public class TyresRepository : Repository<Tyres>, ITyresRepository
    {
        private readonly ApplicationDbContext _db;

        public TyresRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Tyres obj)
        {
            _db.Tyres.Update(obj);
        }
    }
}
