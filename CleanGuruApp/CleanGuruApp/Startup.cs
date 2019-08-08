//*********************************************************************************************************************
// Team 5 - First version created in July, 1st 2019. 
//
// Developers:
//  Andrea de Fatima Cavalheiro - 301054219
//  Eskender Memetov - 300805013
//  Fernando Martins - 300964760
//  Kishore Jothinarayanan - 300977076
//  Mariia Staforkina - 301052981
//  Melanie March - 300903524
//  Satbyul Park -  300940276
//  Theo Dias Mitchell - 300984894
//
//*********************************************************************************************************************
using CleanGuruApp.Models.DB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanGuruApp
{
    public class Startup
    {
        //DB Configuration
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //DB Configuration
            services.AddDbContext<ApplicationDBContext>(options => 
                options.UseSqlServer(Configuration["Data:CleanGuruDB:ConnectionString"]));
            services.AddTransient<IAppointmentRepository, EFAppointmentRepository>();
            services.AddTransient<ICustomerRepository, EFCustomerRepository>();
            services.AddTransient<ICustomerAddressRepository, EFCustomerAddressRepository>();
            services.AddTransient<ICleanerRepository, EFCleanerRepository>();
            services.AddTransient<IServicePriceRepository, EFServicePriceRepository>();
            services.AddTransient<IUserLoginRepository, EFUserLoginRepository>();
            services.AddTransient<ICustomerSubscriptionRepository, EFCustomerSubscriptionRepository>();

            //MVC Configuration
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePages();

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            SeedData.EnsurePopulated(app);
        }
    }
}
