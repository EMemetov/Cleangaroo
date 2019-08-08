//*********************************************************************************************************************
// Author: Satbyul Park - Last Modified Date: August, 7th 2019.  
// Entity Framework - EFServicePriceRepository
//*********************************************************************************************************************
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CleanGuruApp.Models.DB
{
    public class EFServicePriceRepository : IServicePriceRepository
    {
        private ApplicationDBContext context;
        public EFServicePriceRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<ServicePrice> ServicePrices
        {
            get
            {
                var servicePrices = context.ServicePrice.Include(c => c.Appointments).ToList();
                return servicePrices;
            }
        }


        //method used to get the service price
        public ServicePrice GetServicePrice(int? idServicePrice)
        {
            if (idServicePrice == null) return null;

            var servicePrice = context.ServicePrice.Include(c => c.Appointments).FirstOrDefault(c => c.IdServicePrice == idServicePrice);

            return servicePrice;
        }

        //method used to save the service price
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
    }
}
