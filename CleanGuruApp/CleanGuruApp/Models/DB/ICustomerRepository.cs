using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public interface ICustomerRepository
    {
        //IQueryable<Customer> Customers { get; }
        //void DeleteCustomer(int idCustomer);

        IEnumerable<Customer> Customers { get; }
        void SaveCustomer(Customer customer);
        Customer GetCustomer(int? idCustomer);
    }
}
