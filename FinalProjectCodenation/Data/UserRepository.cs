using FinalProjectCodenation.Interfaces;
using FinalProjectCodenation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectCodenation.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly LogErrorContext _context;

        public UserRepository(LogErrorContext context)
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
