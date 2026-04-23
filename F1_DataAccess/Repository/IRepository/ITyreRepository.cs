using F1_Garage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F1_Models;

namespace F1_DataAccess.Repository.IRepository
{
    public interface ITyresRepository : IRepository<Tyres>
    {
        void Update(Tyres obj);
    }
}