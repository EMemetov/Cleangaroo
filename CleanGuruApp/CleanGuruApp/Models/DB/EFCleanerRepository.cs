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

        public IQueryable<Cleaner> Cleaners => context.Cleaner;

        public void SaveCleaner(Cleaner cleaner)
        {
            if (cleaner.IdCleaner == 0)
            {
                context.Cleaner.Add(cleaner);
            }
            else
            {
                Cleaner dbEntry = context.Cleaner.
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
                    dbEntry.ClSinNumber = cleaner.ClSinNumber;
                    dbEntry.UserName = cleaner.UserName;
                }
            }
            context.SaveChanges();
        }

        //public void DeleteCleaner(int idCleaner)
        //{
        //    Cleaner dbEntry = context.Cleaner.
        //        FirstOrDefault(c => c.IdCleaner == idCleaner);
        //    if(dbEntry != null)
        //    {
        //        context.Cleaner.Remove(dbEntry);
        //        context.SaveChanges();
        //    }
        //}        
    }
}
