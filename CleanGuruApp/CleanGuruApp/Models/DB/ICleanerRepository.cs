using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public interface ICleanerRepository
    {
        IQueryable<Cleaners> Cleaners { get; }
        void SaveCleaner(Cleaners cleaner);

        Cleaners DeleteCleaner(int idCleaner);
    }
}
