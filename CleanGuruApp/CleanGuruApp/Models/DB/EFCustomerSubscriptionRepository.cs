using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public class EFCustomerSubscriptionRepository : ICustomerSubscriptionRepository
    {
        private ApplicationDBContext context;

        public EFCustomerSubscriptionRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public IQueryable<CustomerSubscription> CustomerSubscriptions => context.CustomerSubscription; 

        public void SaveCustomerSubscription(CustomerSubscription customerSubscription)
        {
            if(customerSubscription.IdSubscription == 0)
            {
                context.CustomerSubscription.Add(customerSubscription);
            }
            else
            {
                CustomerSubscription dbEntry = context.CustomerSubscription.
                    FirstOrDefault(c => c.IdSubscription == customerSubscription.IdSubscription);
                if(dbEntry != null)
                {
                    dbEntry.Periodicity = customerSubscription.Periodicity;
                    dbEntry.FinishDate = customerSubscription.FinishDate;
                    dbEntry.IdAppointment = customerSubscription.IdAppointment;
                }
            }
            context.SaveChanges();
        }
        public void DeleteCustomerSubscription(int idAppointment)
        {
            CustomerSubscription dbEntry = context.CustomerSubscription.
                FirstOrDefault(c => c.IdAppointment == idAppointment);
            if (dbEntry != null)
            {
                context.CustomerSubscription.Remove(dbEntry);
                context.SaveChanges();
            }
        }
    }
}
