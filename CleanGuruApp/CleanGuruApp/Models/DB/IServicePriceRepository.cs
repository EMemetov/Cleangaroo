using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public interface IServicePriceRepository
    {
        // IQueryable<ServicePrice> ServicePrices { get; }
        // void DeleteServicePrice(int idServicePrice);

        IEnumerable<ServicePrice> ServicePrices { get; }
        void SaveServicePrice(ServicePrice servicePrice);
        ServicePrice GetServicePrice(int? idServicePrice);


    }
}
