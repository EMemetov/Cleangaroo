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
        public DbSet<Cleaners> Cleaners { get; set; }
        public DbSet<CustomerAddress> CustomerAddress { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<CustomerSubscription> CustomerSubscription { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<SchedulePayment> SchedulePayment { get; set; }
        public DbSet<ServicePrice> ServicePrice { get; set; }
        public DbSet<UserLogin> UserLogin { get; set; }


        ////Should we have???
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Club>().HasMany<Player>(c => c.Players);
        //}

    }
}