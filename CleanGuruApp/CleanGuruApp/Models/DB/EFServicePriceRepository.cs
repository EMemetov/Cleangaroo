using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public class EFServicePriceRepository : IServicePriceRepository
    {
        private ApplicationDBContext context;
        public EFServicePriceRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public IQueryable<ServicePrice> ServicePrices => context.ServicePrice;

        public void SaveServicePrice(ServicePrice servicePrice)
        {
            if (servicePrice.IdServicePrice == 0)
            {
                context.ServicePrice.Add(servicePrice);
            }
            else
            {
                ServicePrice dbEntry = context.ServicePrice.
                    FirstOrDefault(s => s.IdServicePrice == servicePrice.IdServicePrice);
                if (dbEntry != null)
                {
                    dbEntry.CtAmountHour = servicePrice.CtAmountHour;
                    dbEntry.ClAmountHour = servicePrice.ClAmountHour;
                    dbEntry.ServicePriceStatus = servicePrice.ServicePriceStatus;
                }
            }
            context.SaveChanges();
        }


        public void DeleteServicePrice(int idServicePrice)
        {
            ServicePrice dbEntry = context.ServicePrice.
                FirstOrDefault(s => s.IdServicePrice == idServicePrice);
            if(dbEntry != null)
            {
                context.ServicePrice.Remove(dbEntry);
                context.SaveChanges();
            }
        }

    }
}
