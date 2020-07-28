using FinalProjectCodenation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectCodenation.Interfaces
{
    public interface ILogRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        bool SaveChanges();
        Log[] GetLogsbySector(int sectorId, bool includeUser = false);
        Log[] GetAllLogsOrderByName(bool includeUser = false);
        Log[] GetAllLogsOrderByLevel(bool includeUser = false);
        Log[] GetAllLogsOrderByEvents(bool includeUser = false);
        Log[] GetLogbyLevel(string level, bool includeUser = false);
        Log[] GetLogbyDescription(string description, bool includeUser = false);
        Log[] GetLogbyOrigin(string origin, bool includeUser = false);
    }
}
