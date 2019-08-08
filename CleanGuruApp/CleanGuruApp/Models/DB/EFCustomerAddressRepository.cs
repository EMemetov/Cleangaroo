﻿//*********************************************************************************************************************
// Author: Andrea Cavalheiro - Last Modified Date: August, 7th 2019.  
// Entity Framework - EFCustomerAddressRepository
//*********************************************************************************************************************
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CleanGuruApp.Models.DB
{
    public class EFCustomerAddressRepository : ICustomerAddressRepository
    {
        private ApplicationDBContext context;

        public EFCustomerAddressRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<CustomerAddress> CustomerAddresss => context.CustomerAddress.Include(p => p.Customer).ToList();

        //method used to save the addres of the customer
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
    }
}
