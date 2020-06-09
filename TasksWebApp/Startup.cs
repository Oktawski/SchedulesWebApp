using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TasksWebApp.Models;
using TasksWebApp.Services;

namespace TasksWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //Connection on PC
            /*services.AddDbContext<ScheduleContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ScheduleDB")));*/

            //Connection on Notebook
            services.AddDbContext<ScheduleContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("NotebookScheduleDB")));

            services.AddScoped<IScheduleService<Assignment>, AssignmentsService>();
            services.AddScoped<IScheduleService<Exam>, ExamsService>();
            services.AddScoped<IScheduleService<OnlineMeeting>, OnlineMeetingsService>();
            services.AddScoped<IScheduleService<Appointment>, AppointmentsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
