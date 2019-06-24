using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public interface IScheduleRepository
    {
        IQueryable<Schedule> Schedules { get; }
        void SaveSchedule(Schedule schedule);

        Schedule DeleteSchedule(int idSchedule);
    }
}
