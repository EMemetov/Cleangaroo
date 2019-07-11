using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public interface ICustomerSubscriptionRepository
    {
        IQueryable<CustomerSubscription> CustomerSubscriptions { get; }
        void SaveCustomerSubscription(CustomerSubscription customerSubscription);
        void DeleteCustomerSubscription(int idSubscription);
    }
}
