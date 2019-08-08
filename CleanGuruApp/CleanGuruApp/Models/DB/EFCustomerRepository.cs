﻿//*********************************************************************************************************************
// Author: Theo Mitchel - Last Modified Date: August, 7th 2019.  
// Entity Framework - EFCustomerRepository
//*********************************************************************************************************************

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CleanGuruApp.Models.DB
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDBContext context;


        public EFCustomerRepository(ApplicationDBContext ctx)
        {
            context = ctx;
        }
        

        public IEnumerable<Customer> Customers
        {
            get
            {
                var customers = context.Customer.Include(c => c.Appointments).ToList();

                return customers;
            }
        }

        //method used to get the information about the customer
        public Customer GetCustomer(int? idCustomer)
        {
            if (idCustomer == null) return null;

            var customer = context.Customer.Include(c => c.Appointments).FirstOrDefault(c => c.IdCustomer == idCustomer);

            return customer;
        }

        //method used to save the information about the customer
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
                    dbEntry.Password = customer.Password;
                }
            }
            context.SaveChanges();
        }
    }
}
