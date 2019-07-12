using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public class EFCustomerAddressRepository : ICustomerAddressRepository
    {
        private ApplicationDBContext context;

        public EFCustomerAddressRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

       //public IQueryable<CustomerAddress> CustomerAddresss => context.CustomerAddress;

        public IEnumerable<CustomerAddress> CustomerAddresss => context.CustomerAddress.Include(p => p.Customer).ToList();

        public void SaveCustomerAddress(CustomerAddress customerAddress)
        {
            if (customerAddress.idCustAddress == 0)
            {
                context.CustomerAddress.Add(customerAddress);
            }
            else
            {
                CustomerAddress dbEntry = context.CustomerAddress
                .FirstOrDefault(c => c.idCustAddress == customerAddress.idCustAddress);
                if (dbEntry != null)
                {
                    dbEntry.Address = customerAddress.Address;
                    dbEntry.AddressUnit = customerAddress.AddressUnit;
                    dbEntry.PostalCode = customerAddress.PostalCode;
                    dbEntry.PostalCode = customerAddress.PostalCode;
                    dbEntry.City = customerAddress.City;
                    dbEntry.Province = customerAddress.Province;
                }
            }
            context.SaveChanges();
        }

        //public void DeleteCustomerAddress(int idCustAddress)
        //{
        //    CustomerAddress dbEntry = context.CustomerAddress
        //               .FirstOrDefault(c => c.IdCustAddress == idCustAddress);
        //    if (dbEntry != null)
        //    {
        //        context.CustomerAddress.Remove(dbEntry);
        //        context.SaveChanges();
        //    }
        //}
    }
}
