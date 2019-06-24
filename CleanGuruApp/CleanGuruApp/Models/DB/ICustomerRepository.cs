using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public interface ICustomerRepository
    {
        IQueryable<Customers> Customers { get; }
        void SaveCustomers(Customers customer);

        Customers DeleteCustomers(int idCustomer);
    }
}
