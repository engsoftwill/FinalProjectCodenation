using FinalProjectCodenation.Interfaces;
using FinalProjectCodenation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectCodenation.Data
{
    public class SectorRepository :  ISectorRepository
    {
        private readonly LogErrorContext _context;

        public SectorRepository(LogErrorContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }


        public Sector GetSectorbyId(int sectorId, bool includeUser = false)
        {
            IQueryable<Sector> query = _context.Sectors;

            query = query.AsNoTracking().OrderBy(a => a.Id).Where(x => x.Id == sectorId);

            return query.FirstOrDefault();
        }


        public Sector[] GetAllSectors(bool includeUser = false)
        {
            IQueryable<Sector> query = _context.Sectors;

            query = query.AsNoTracking().OrderBy(a => a.Name);

            return query.ToArray();
        }
               
    }
}
