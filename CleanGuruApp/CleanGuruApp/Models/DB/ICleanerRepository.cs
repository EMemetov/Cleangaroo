using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public interface ICleanerRepository
    {
        IQueryable<Cleaner> Cleaners { get; }
        void SaveCleaner(Cleaner cleaner);

        void DeleteCleaner(int idCleaner);
    }
}
