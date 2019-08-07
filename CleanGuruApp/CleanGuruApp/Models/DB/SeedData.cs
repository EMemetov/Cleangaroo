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
                    new UserLogin { UserName = "Aaron@gmail.com", Pin = "1234", Role = "CUSTOMER" },
                    new UserLogin { UserName = "Frank@gmail.com", Pin = "1111", Role = "CUSTOMER" },
                    new UserLogin { UserName = "Edward@gmail.com", Pin = "2222", Role = "CUSTOMER" },
                    new UserLogin { UserName = "Rubens@gmail.com", Pin = "1234", Role = "CLEANER" },
                    new UserLogin { UserName = "Fred@gmail.com", Pin = "1020", Role = "MANAGER" },
                    new UserLogin { UserName = "Rattan@gmail.com", Pin = "1245", Role = "CLEANER" }
                    );
                context.SaveChanges();
            }

            if (!context.ServicePrice.Any())
            {
                context.ServicePrice.AddRange(
                    new ServicePrice { ServicePriceDescr = "Home Cleaning", CtAmountHour = 10.10, ClAmountHour = 5.20, ServicePriceStatus = 'A' },
                    new ServicePrice { ServicePriceDescr = "Commercial Cleaning", CtAmountHour = 30.30, ClAmountHour = 10.50, ServicePriceStatus = 'I' }
                    );
                context.SaveChanges();
            }


            if (!context.Customer.Any())
            {
                context.Customer.AddRange(
                    new Customer
                    {
                        FCustomerName = "Aaron",
                        MCustomerName = "Brown",
                        LCustomerName = "Hank",
                        CtPhone1 = "666-222-1111",
                        UserName = "Aaron@gmail.com",
                        Password = "123123"
                    },
                    new Customer
                    {
                        FCustomerName = "Frank",
                        MCustomerName = "Abdu",
                        LCustomerName = "Rash",
                        CtPhone1 = "666-222-2222",
                        UserName = "Frank@gmail.com",
                        Password = "321321"
                    },
                    new Customer
                    {
                        FCustomerName = "Edward",
                        LCustomerName = "Tank",
                        CtPhone1 = "666-333-1111",
                        UserName = "Edward@gmail.com",
                        Password = "554433"
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
                        ClSinNumber = "123456789",
                        UserName = "Rubens",
                        Password = "pass1"
                        
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
                        UserName = "Rattan",
                        Password = "pass2"
                    }
                    );
                context.SaveChanges();
            }

            if (!context.ScheduleCleaner.Any())
            {
                context.ScheduleCleaner.AddRange(
                    new ScheduleCleaner
                    {
                        DayWeek = "Monday",
                        InitialTime = Convert.ToDateTime("07:00 AM"),
                        FinishTime = Convert.ToDateTime("18:00 PM"),
                        IdCleaner = 1
                    },
                    new ScheduleCleaner
                    {
                        DayWeek = "Tuesday",
                        InitialTime = Convert.ToDateTime("07:00 AM"),
                        FinishTime = Convert.ToDateTime("18:00 PM"),
                        IdCleaner = 1
                    },
                    new ScheduleCleaner
                    {
                        DayWeek = "Wednesday",
                        InitialTime = Convert.ToDateTime("07:00 AM"),
                        FinishTime = Convert.ToDateTime("18:00 PM"),
                        IdCleaner = 1
                    },
                    new ScheduleCleaner
                    {
                        DayWeek = "Thursday",
                        InitialTime = Convert.ToDateTime("07:00 AM"),
                        FinishTime = Convert.ToDateTime("18:00 PM"),
                        IdCleaner = 1
                    },
                    new ScheduleCleaner
                    {
                        DayWeek = "Friday",
                        InitialTime = Convert.ToDateTime("07:00 AM"),
                        FinishTime = Convert.ToDateTime("18:00 PM"),
                        IdCleaner = 2
                    },
                    new ScheduleCleaner
                    {
                        DayWeek = "Saturday",
                        InitialTime = Convert.ToDateTime("08:00 AM"),
                        FinishTime = Convert.ToDateTime("14:00 PM"),
                        IdCleaner = 2
                    },
                    new ScheduleCleaner
                    {
                        DayWeek = "Sunday",
                        InitialTime = Convert.ToDateTime("08:00 AM"),
                        FinishTime = Convert.ToDateTime("14:00 PM"),
                        IdCleaner = 2
                    }
                    );
                context.SaveChanges();
            }


            if (!context.Appointment.Any())
            {
                context.Appointment.AddRange(
                    new Appointment
                    {
                        IdServicePrice = 1,
                        IdCustomer = 1,
                        CtDateRequestService = Convert.ToDateTime("06/30/2019"),
                        CtHoursRequested = 6,
                        IdCleaner = 1,
                        StartTime = Convert.ToDateTime("09:00AM"),
                        //IsSubscription = Convert.ToBoolean(0)
                        IsSubscription = false

                    },
                    new Appointment
                    {
                        IdServicePrice = 2,
                        IdCustomer = 2,
                        CtDateRequestService = Convert.ToDateTime("07/03/2019"),
                        CtHoursRequested = 5,
                        IdCleaner = 2,
                        StartTime = Convert.ToDateTime("10:00AM"),
                        //IsSubscription = Convert.ToBoolean(1)
                        IsSubscription = true
                    }
                    );
                context.SaveChanges();
            }

            if (!context.CustomerSubscription.Any() && !context.Appointment.Any())
            {
                context.CustomerSubscription.AddRange(
                    new CustomerSubscription
                    {
                        Periodicity = 7,
                        FinishDate = Convert.ToDateTime("08/30/2019"),
                        IdAppointment = 2
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}