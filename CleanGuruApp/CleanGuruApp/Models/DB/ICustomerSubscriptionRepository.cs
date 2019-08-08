//*********************************************************************************************************************
// Author: Fernando Martin - Last Modified Date: August, 7th 2019.  
// Declaring the methods to be used for the EFCustomerSubscriptionRepository
//*********************************************************************************************************************
using System.Linq;

namespace CleanGuruApp.Models.DB
{
    public interface ICustomerSubscriptionRepository
    {
        IQueryable<CustomerSubscription> CustomerSubscriptions { get; }
        void SaveCustomerSubscription(CustomerSubscription customerSubscription);
        void DeleteCustomerSubscription(int idSubscription);
    }
}
