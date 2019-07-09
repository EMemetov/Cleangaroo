using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        // public IQueryable<ServicePrice> ServicePrices => context.ServicePrice;

        public IEnumerable<ServicePrice> ServicePrices
        {
            get
            {
                var servicePrices = context.ServicePrice.Include(c => c.Appointments).ToList();

                return servicePrices;
            }
        }

        public ServicePrice GetServicePrice(int? idServicePrice)
        {
            if (idServicePrice == null) return null;

            var servicePrice = context.ServicePrice.Include(c => c.Appointments).FirstOrDefault(c => c.IdServicePrice == idServicePrice);

            return servicePrice;
        }


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
                    dbEntry.ServicePriceDescr = servicePrice.ServicePriceDescr;
                    dbEntry.CtAmountHour = servicePrice.CtAmountHour;
                    dbEntry.ClAmountHour = servicePrice.ClAmountHour;
                    dbEntry.ServicePriceStatus = servicePrice.ServicePriceStatus;
                }
            }
            context.SaveChanges();
        }


        //public void DeleteServicePrice(int idServicePrice)
        //{
        //    ServicePrice dbEntry = context.ServicePrice.
        //        FirstOrDefault(s => s.IdServicePrice == idServicePrice);
        //    if(dbEntry != null)
        //    {
        //        context.ServicePrice.Remove(dbEntry);
        //        context.SaveChanges();
        //    }
        //}

    }
}
