using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public interface IScheduleCleanerRepository
    {
        IQueryable<ScheduleCleaner> ScheduleCleaners { get; }
        void SaveScheduleCleaner(ScheduleCleaner scheduleCleaner);
        void DeleteScheduleCleaner(int idScheduleCleaner);
        List<ScheduleCleaner> ListCleaners(String dayWeek, String initTime, 
            String finTime);
    }
}
