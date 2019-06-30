using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDBContext context = app.ApplicationServices.GetRequiredService<ApplicationDBContext>();

            context.Database.Migrate();

            if (!context.UserLogin.Any())
            {
                context.UserLogin.AddRange(
                    new UserLogin { UserName = "Aaron", Pin = "1234", Role = "CUSTOMER" },
                    new UserLogin { UserName = "Frank", Pin = "1111", Role = "CUSTOMER" },
                    new UserLogin { UserName = "Edward", Pin = "2222", Role = "CUSTOMER" },
                    new UserLogin { UserName = "Rubens", Pin = "1234", Role = "CLEANER" },
                    new UserLogin { UserName = "Fred", Pin = "1020", Role = "MANAGER" },
                    new UserLogin { UserName = "Rattan", Pin = "1245", Role = "CLEANER" }
                    );
                context.SaveChanges();
            }

            if (!context.ServicePrice.Any())
            {
                context.ServicePrice.AddRange(
                    new ServicePrice { CtAmountHour = 10.10, ClAmountHour = 20.20, ServicePriceStatus = 'A' },
                    new ServicePrice { CtAmountHour = 30.30, ClAmountHour = 50.50, ServicePriceStatus = 'I' }
                    );
                context.SaveChanges();
            }


            if (!context.Customer.Any())
            {
                context.Customer.AddRange(
                    new Customer { FCustomerName = "Aaron",
                        MCustomerName = "Brown",
                        LCustomerName = "Hank",
                        CtPhone1 = "666-222-1111",
                        UserName = "Aaron"
                    },
                    new Customer
                    {
                        FCustomerName = "Frank",
                        MCustomerName = "Abdu",
                        LCustomerName = "Rash",
                        CtPhone1 = "666-222-2222",
                        UserName = "Frank"
                    },
                    new Customer
                    {
                        FCustomerName = "Edward",
                        LCustomerName = "Tank",
                        CtPhone1 = "666-333-1111",
                        UserName = "Edward"
                    }
                    );
                context.SaveChanges();
            }

            if (!context.CustomerAddress.Any())
            {
                context.CustomerAddress.AddRange(
                    new CustomerAddress
                    {
                        IdCustomer = 1,
                        Address = "2000 Finch Ave E",
                        PostalCode = "A2V4W1",
                        City = "Noth York",
                        Province = "ON"
                    },
                    new CustomerAddress
                    {
                        IdCustomer = 2,
                        Address = "10 Finch Ave E",
                        AddressUnit = "Basement",
                        PostalCode = "Q4Z4K3",
                        City = "Noth York",
                        Province = "ON"
                    },
                    new CustomerAddress
                    {
                        IdCustomer = 3,
                        Address = "238 Bayview Ave",
                        PostalCode = "X5C4N5",
                        City = "Toronto",
                        Province = "ON"
                    }
                    );
                context.SaveChanges();
            }

            if (!context.Cleaner.Any())
            {
                context.Cleaner.AddRange(
                    new Cleaner
                    {
                        FCleanerName = "Rubens",
                        MCleanerName = "Silva",
                        LCleanerName = "Monte",
                        ClAddress = "10 Snow White",
                        ClPostalCode = "A3Q5R2",
                        ClCity = "Etobicoke",
                        ClProvince = "ON",
                        ClPhone1 = "222-111-4444",
                        ClPhone2 = "111-111-4444",
                        ClSinNumber="123456789",
                        UserName = "Rubens"
                    },
                    new Cleaner
                    {
                        FCleanerName = "Rattan",
                        MCleanerName = "abdu",
                        LCleanerName = "Rash",
                        ClAddress = "997 Greenwood",
                        ClPostalCode = "Q31D7X",
                        ClCity = "MARKHAM",
                        ClProvince = "ON",
                        ClPhone1 = "111-888-9999",
                        ClSinNumber = "000111222",
                        UserName = "Rattan"
                    }
                    );
                context.SaveChanges();
            }


            /*            if (!context.CustomerSubscription.Any())
                        {
                            context.CustomerSubscription.AddRange(
                                new CustomerSubscription { Periodicity = "Weekly", FinishDate = Convert.ToDateTime("09/30/2019"), IdCustomer = 1 },
                                new CustomerSubscription { Periodicity = "Biweekly", FinishDate = Convert.ToDateTime("12/30/2019"), IdCustomer = 2 }
                                );
                            context.SaveChanges();
                        }*/

            if (!context.Appointment.Any())
            {
                //context.Appointment.AddRange(
                //    new Appointment { IdAppointment = 1, IdServicePrice = 1, IdCustomer = 1, CtHoursRequested = 6 },
                //    new Appointment { IdAppointment = 2, IdServicePrice = 2, IdCustomer = 2, CtHoursRequested = 4 }
                //    );
                //context.SaveChanges();
            }


        }
    }
}