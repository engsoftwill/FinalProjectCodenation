using FinalProjectCodenation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectCodenation.Interfaces
{
    public interface IUserRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        bool SaveChanges();
        User[] GetAllUsers();
        User[] GetUsersbySector(int sectorId);
        User GetUserbyId(int userId);
    }
}
