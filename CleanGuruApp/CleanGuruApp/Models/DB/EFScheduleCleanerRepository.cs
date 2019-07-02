using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public class EFScheduleCleanerRepository : IScheduleCleanerRepository
    {
        private ApplicationDBContext context;

        public EFScheduleCleanerRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public IQueryable<ScheduleCleaner> ScheduleCleaners => context.ScheduleCleaner;



        public void SaveScheduleCleaner(ScheduleCleaner scheduleCleaner)
        {
            if (scheduleCleaner.IdCleaner == 0)
            {
                context.ScheduleCleaner.Add(scheduleCleaner);
            }
            else
            {
                ScheduleCleaner dbEntry = context.ScheduleCleaner.
                    FirstOrDefault(s => s.IdScheduleCleaner == scheduleCleaner.IdScheduleCleaner);
                if (dbEntry != null)
                {
                    dbEntry.DayWeek = scheduleCleaner.DayWeek;
                    dbEntry.InitialTime = scheduleCleaner.InitialTime;
                    dbEntry.FinishTime = scheduleCleaner.FinishTime;
                    dbEntry.IdCleaner = scheduleCleaner.IdCleaner;
                }
                context.SaveChanges();
            }
        }


        public void DeleteScheduleCleaner(int idScheduleCleaner)
        {
            ScheduleCleaner dbEntry = context.ScheduleCleaner.
                FirstOrDefault(s => s.IdScheduleCleaner == idScheduleCleaner);
            if (dbEntry != null)
            {
                context.ScheduleCleaner.Remove(dbEntry);
                context.SaveChanges();
            }
        }

        public List<ScheduleCleaner> ListCleaners(String dayWeek, string initTime, string finTime)
        {
            List<ScheduleCleaner> list = new List<ScheduleCleaner>();
            list = context.ScheduleCleaner.
                FromSql($"SearchCustCleaner {dayWeek}, {initTime}, {finTime}").
                ToList();
            return list;
        }
    }
}
