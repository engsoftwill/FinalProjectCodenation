using FinalProjectCodenation.Interfaces;
using FinalProjectCodenation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectCodenation.Data
{
    public class Repository : IRepository , ILogRepository, ISectorRepository, IUserRepository
    {
        private readonly LogErrorContext _context;

        public Repository(LogErrorContext context)
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

        public Log[] GetAllLogs(bool includeUser = false)
        {
            IQueryable<Log> query = _context.Logs;

            query = query.AsNoTracking().OrderBy(a => a.Events);

            return query.ToArray();
        }

        public Log GetLogbyId(int logId, bool includeUser = false)
        {
            IQueryable<Log> query = _context.Logs;

            query = query.AsNoTracking().OrderBy(a => a.Id).Where(x=>x.Id==logId);

            return query.FirstOrDefault();
        }

        public Log[] GetLogsbySector(int sectorId, bool includeUser = false)
        {
            IQueryable<Log> query = _context.Logs;

            query = query.AsNoTracking().OrderBy(a => a.Id).Where(x => x.User.SectorId == sectorId);

            return query.ToArray();
        }


        public User[] GetAllUsers()
        {
            IQueryable<User> query = _context.Users;

            query = query.AsNoTracking().OrderBy(a => a.Id);

            return query.ToArray();
        }

        public User GetUserbyId(int userId)
        {
            IQueryable<User> query = _context.Users;


            query = query.AsNoTracking().OrderBy(a => a.Id).Where(x => x.Id == userId);

            return query.FirstOrDefault();
        }

        public User[] GetUsersbySector(int sectorId)
        {
            IQueryable<User> query = _context.Users;

            query = query.AsNoTracking().OrderBy(a => a.Id).Where(b => b.SectorId == sectorId);
            return query.ToArray();
        }
    }
}
