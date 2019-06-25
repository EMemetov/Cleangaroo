using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public class EFScheduleRepository : IScheduleRepository
    {
        private ApplicationDBContext context;

        public EFScheduleRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        //public IQueryable<Cleaners> Cleaners => context.Cleaners.Include(c => c.Players);     //DELETE after adjust below

        public IQueryable<Schedule> Schedules => throw new NotImplementedException();            //DELETE after adjust abouve

        public void SaveSchedule(Schedule schedule)
        {
            //INSERT CODE

            context.SaveChanges();
        }
        public Schedule DeleteSchedule(int idSchedule)
        {
            //Schedule schedule = Schedule.FirstOrDefault(c => c.IdSchedule == idSchedule);       //ERROR ????

            ////INSERT CODE

            //return schedule;       //ERROR ????

            //Just to make it work
            Schedule schedule = new Schedule();
            return schedule;


        }


    }
}
