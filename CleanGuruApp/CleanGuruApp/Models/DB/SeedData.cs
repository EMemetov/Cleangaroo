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
                    new UserLogin
                    {
                        UserName = "JOHN",
                        Pin = "1234",
                        Role = "CLEANER"
                    },
                    new UserLogin
                    {
                        UserName = "Fred",
                        Pin = "1020",
                        Role = "MANAGER"
                    },
                    new UserLogin
                    {
                        UserName = "Rattan",
                        Pin = "1245",
                        Role = "CLEANER"
                    }
                    );
                context.SaveChanges();
            }
            if (!context.Appointment.Any())
            {
                //context.Appointment.AddRange(
                //    new Appointment { IdAppointment = 1, IdServicePrice = 1, IdCustomer = 1, CtHoursRequested = 6 },
                //    new Appointment { IdAppointment = 2, IdServicePrice = 2, IdCustomer = 2, CtHoursRequested = 4 }
                //    );
                //context.SaveChanges();
            }

            if (!context.ServicePrice.Any())
            {
                //context.ServicePrice.AddRange(
                //    new ServicePrice { CtAmountHour = 10.1, ClAmountHour = 20.2, ServicePriceStatus = 'A' },
                //    new ServicePrice { CtAmountHour = 30.3, ClAmountHour = 50.5, ServicePriceStatus = 'A' }
                //    );
                //context.SaveChanges();
            }
        }
    }
}
