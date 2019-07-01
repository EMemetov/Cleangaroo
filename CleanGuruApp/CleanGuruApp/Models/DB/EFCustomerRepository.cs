using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private ApplicationDBContext context;

        public EFCustomerRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public IQueryable<Customer> Customers => context.Customer;       

        public void SaveCustomer(Customer customer)
        {
            if (customer.IdCustomer == 0)
            {
                context.Customer.Add(customer);
            }
            else
            {
                Customer dbEntry = context.Customer
                .FirstOrDefault(c => c.IdCustomer == customer.IdCustomer);
                if (dbEntry != null)
                {
                    dbEntry.FCustomerName = customer.FCustomerName;
                    dbEntry.MCustomerName = customer.MCustomerName;
                    dbEntry.LCustomerName = customer.LCustomerName;
                    dbEntry.CtPhone1 = customer.CtPhone1;
                    dbEntry.CtPhone2 = customer.CtPhone2;
                    dbEntry.UserName = customer.UserName;
                }
            }
            context.SaveChanges();
        }

        //public void DeleteCustomers(int idCustomer)
        //{
        //    Customer dbEntry = context.Customer
        //               .FirstOrDefault(c => c.IdCustomer == idCustomer);
        //    if (dbEntry != null)
        //    {
        //        context.Customer.Remove(dbEntry);
        //        context.SaveChanges();
        //    }
        //}

    }
}
