using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
        public DbSet<Cleaner> Cleaner { get; set; }
        public DbSet<CustomerAddress> CustomerAddress { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerSubscription> CustomerSubscription { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<AppointmentPayment> AppointmentPayment { get; set; }
        public DbSet<ServicePrice> ServicePrice { get; set; }
        public DbSet<UserLogin> UserLogin { get; set; }
        public DbSet<ScheduleCleaner> ScheduleCleaner { get; set; }


        ////Should we have???
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Club>().HasMany<Player>(c => c.Players);
        //}

    }
}