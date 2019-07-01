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
                    dbEntry.Subscription = customerSubscription.Subscription;
                    dbEntry.Periodicity = customerSubscription.Periodicity;
                    dbEntry.FinishDate = customerSubscription.FinishDate;
                    dbEntry.IdCustomer = customerSubscription.IdCustomer;
                }
            }
            context.SaveChanges();
        }
        //public void DeleteCustomerSubscription(int idSubscription)
        //{
        //    CustomerSubscription dbEntry = context.CustomerSubscription.
        //        FirstOrDefault(c=>c.IdSubscription==idSubscription);
        //    if(dbEntry != null)
        //    {
        //        context.CustomerSubscription.Remove(dbEntry);
        //        context.SaveChanges();
        //    }
        //}
    }
}
