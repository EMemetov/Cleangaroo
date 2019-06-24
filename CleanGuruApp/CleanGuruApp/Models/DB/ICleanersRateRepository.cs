using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public interface ICleanersRateRepository
    {
        IQueryable<CleanersRate> CleanersRates { get; }
        void SaveCleanersRate(CleanersRate cleanersRate);

        CleanersRate DeleteCleanersRate(int idRate);
    }
}
