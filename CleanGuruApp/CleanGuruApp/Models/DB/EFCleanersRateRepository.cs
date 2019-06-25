using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public class EFCleanersRateRepository : ICleanersRateRepository
    {
        private ApplicationDBContext context;

        public EFCleanersRateRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        //public IQueryable<Cleaners> Cleaners => context.Cleaners.Include(c => c.Players);     //DELETE after adjust below

        public IQueryable<Cleaners> Cleaners => throw new NotImplementedException();            //DELETE after adjust abouve

        public void SaveCleanersRate(Cleaners cleaner)
        {
            //INSERT CODE

            context.SaveChanges();
        }

        public Cleaners DeleteCleanersRate(int idCleaner)
        {
            Cleaners cleaner = Cleaners.FirstOrDefault(c => c.IdCleaner == idCleaner);

            //INSERT CODE

            return cleaner;
        }
    }
}
