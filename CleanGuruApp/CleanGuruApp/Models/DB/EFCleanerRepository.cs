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

        public IQueryable<Cleaners> Cleaners => context.Cleaners;

        public void SaveCleaner(Cleaners cleaner)
        {
            if (cleaner.IdCleaner == 0)
            {
                context.Cleaners.Add(cleaner);
            }
            else
            {
                Cleaners dbEntry = context.Cleaners.
                    FirstOrDefault(c=>c.IdCleaner==cleaner.IdCleaner);
                if(dbEntry != null)
                {
                    dbEntry.FCleanerName = cleaner.FCleanerName;
                    dbEntry.MCleanerName = cleaner.MCleanerName;
                    dbEntry.LCleanerName = cleaner.LCleanerName;
                    dbEntry.ClAddress = cleaner.ClAddress;
                    dbEntry.ClAddressUnit = cleaner.ClAddressUnit;
                    dbEntry.ClPostalCode = cleaner.ClPostalCode;
                    dbEntry.ClCity = cleaner.ClCity;
                    dbEntry.ClProvince = cleaner.ClProvince;
                    dbEntry.ClPhone1 = cleaner.ClPhone1;
                    dbEntry.ClPhone2 = cleaner.ClPhone2;
                    dbEntry.ClSincNumber = cleaner.ClSincNumber;
                    dbEntry.UserName = cleaner.UserName;
                }
            }
            context.SaveChanges();
        }

        public void DeleteCleaner(int idCleaner)
        {
            Cleaners dbEntry = context.Cleaners.
                FirstOrDefault(c => c.IdCleaner == idCleaner);
            if(dbEntry != null)
            {
                context.Cleaners.Remove(dbEntry);
                context.SaveChanges();
            }
        }        
    }
}
