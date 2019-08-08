//*********************************************************************************************************************
// Author: Fernando Martin - Last Modified Date: August, 7th 2019.  
// Entity Framework - EFCustomerSubscriptionRepository
//*********************************************************************************************************************

using System.Linq;


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

        //method used to save the subscription
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
        //method used to delete the subscription from a specific appointment
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
