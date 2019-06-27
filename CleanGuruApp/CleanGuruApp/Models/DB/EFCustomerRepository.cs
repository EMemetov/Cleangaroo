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

        public IQueryable<Customers> Customers => context.Customers;       

        public void SaveCustomers(Customers customer)
        {
            if (customer.IdCustomer == 0)
            {
                context.Customers.Add(customer);
            }
            else
            {
                Customers dbEntry = context.Customers
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

        public void DeleteCustomers(int idCustomer)
        {
            Customers dbEntry = context.Customers
                       .FirstOrDefault(c => c.IdCustomer == idCustomer);
            if (dbEntry != null)
            {
                context.Customers.Remove(dbEntry);
                context.SaveChanges();
            }
        }
    }
}
