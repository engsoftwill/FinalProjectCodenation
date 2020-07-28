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
        Log[] GetAllLogs(bool includeUser = false);
        Log GetLogbyId(int logId, bool includeUser = false);
    }
}
