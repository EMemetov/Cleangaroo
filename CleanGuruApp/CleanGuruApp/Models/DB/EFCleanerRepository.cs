using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public class EFCleanerRepository : ICleanerRepository
    {
        private ApplicationDBContext context;

        public EFCleanerRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        //public IQueryable<Cleaners> Cleaners => context.Cleaners.Include(c => c.Players);     //DELETE after adjust below

        public IQueryable<Cleaners> Cleaners => throw new NotImplementedException();            //DELETE after adjust abouve

        public void SaveCleaner(Cleaners cleaner)
        {
            //INSERT CODE

            context.SaveChanges();
        }

        public Cleaners DeleteCleaner(int idCleaner)
        {
            Cleaners cleaner = Cleaners.FirstOrDefault(c => c.IdCleaner == idCleaner);

            //INSERT CODE

            return cleaner;
        }        
    }
}
