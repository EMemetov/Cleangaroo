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

        //public IQueryable<Cleaners> Cleaners => context.Cleaners.Include(c => c.Players);     //DELETE after adjust below

        public IQueryable<CustomerSubscription> CustomerSubscriptions => throw new NotImplementedException();            //DELETE after adjust abouve

        public void SaveCustomerSubscription(CustomerSubscription customerSubscription)
        {
            //INSERT CODE

            context.SaveChanges();
        }
        public CustomerSubscription DeleteCustomerSubscription(int idSubscription)
        {
            //CustomerSubscription customerSubscription = CustomerSubscription.FirstOrDefault(c => c.IdSubscription == idSubscription);

            ////INSERT CODE

            //return customerSubscription;


            //Just to make it work
            CustomerSubscription customerSubscription = new CustomerSubscription();
            return customerSubscription;
        }


    }
}
