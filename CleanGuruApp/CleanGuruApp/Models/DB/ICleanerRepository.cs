using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public interface ICleanerRepository
    {

        IEnumerable<Cleaner> Cleaners { get; }
        void SaveCleaner(Cleaner cleaner);
        Cleaner GetCleaner(int? idCleaner);
    }
}
