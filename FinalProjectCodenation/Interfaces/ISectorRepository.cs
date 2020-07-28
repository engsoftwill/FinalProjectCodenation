using FinalProjectCodenation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectCodenation.Interfaces
{
    public interface ISectorRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        bool SaveChanges();
        Sector[] GetAllSectors(bool includeUser = false);
        Sector GetSectorbyId(int sectorId, bool includeUser = false);
    }
}
