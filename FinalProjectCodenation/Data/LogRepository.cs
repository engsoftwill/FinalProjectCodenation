using FinalProjectCodenation.Interfaces;
using FinalProjectCodenation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectCodenation.Data
{
    public class LogRepository :  ILogRepository
    {
        private readonly LogErrorContext _context;

        public LogRepository(LogErrorContext context)
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
        

        public Log GetLogbyId(int logId, bool includeUser = false)
        {
            IQueryable<Log> query = _context.Logs;

            query = query.AsNoTracking().OrderBy(a => a.Id).Where(x => x.Id == logId);

            return query.FirstOrDefault();
        }

        public Log[] GetLogsbySector(int sectorId, bool includeUser = false)
        {
            IQueryable<Log> query = _context.Logs;

            query = query.AsNoTracking().OrderBy(a => a.Id).Where(x => x.User.SectorId == sectorId);

            return query.ToArray();
        }

       

        public Log[] GetAllLogsOrderByName(bool includeUser = false)
        {
            IQueryable<Log> query = _context.Logs;

            query = query.AsNoTracking().OrderBy(a => a.Name);

            return query.ToArray();
        }

        public Log[] GetAllLogsOrderByLevel(bool includeUser = false)
        {
            IQueryable<Log> query = _context.Logs;

            query = query.AsNoTracking().OrderBy(a => a.Level);

            return query.ToArray();
        }

        public Log[] GetAllLogsOrderByEvents(bool includeUser = false)
        {
            IQueryable<Log> query = _context.Logs;

            query = query.AsNoTracking().OrderBy(a => a.Events);

            return query.ToArray();
        }


        public Log[] GetLogbyLevel(string level, bool includeUser = false)
        {
            IQueryable<Log> query = _context.Logs;

            query = query.AsNoTracking().OrderBy(a => a.Id).Where(x => x.Level == level);

            return query.ToArray();
        }

        public Log[] GetLogbyDescription(string description, bool includeUser = false)
        {
            IQueryable<Log> query = _context.Logs;

            query = query.AsNoTracking().OrderBy(a => a.Id).Where(x => x.Description == description);

            return query.ToArray();
        }

        public Log[] GetLogbyOrigin(string origin, bool includeUser = false)
        {
            IQueryable<Log> query = _context.Logs;

            query = query.AsNoTracking().OrderBy(a => a.Id).Where(x => x.Origin == origin);

            return query.ToArray();
        }
        
    }
}
