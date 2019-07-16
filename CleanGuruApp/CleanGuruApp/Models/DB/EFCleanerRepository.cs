using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public class EFCleanerRepository : ICleanerRepository
    {

        private readonly ApplicationDBContext context;

        public EFCleanerRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Cleaner> Cleaners
        {
            get
            {
                var cleaners = context.Cleaner.Include(c => c.Appointments).ToList();

                return cleaners;
            }
        }

        public Cleaner GetCleaner(int? idCleaner)
        {
            if (idCleaner == null) return null;

            var cleaner = context.Cleaner.Include(c => c.Appointments).FirstOrDefault(c => c.IdCleaner == idCleaner);

            return cleaner;
        }

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
                    dbEntry.Password = cleaner.Password;
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
