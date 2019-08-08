using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> Customers { get; }
        void SaveCustomer(Customer customer);
        Customer GetCustomer(int? idCustomer);
    }
}
