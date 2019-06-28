using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> Customers { get; }
        void SaveCustomers(Customer customer);

        void DeleteCustomers(int idCustomer);
    }
}
