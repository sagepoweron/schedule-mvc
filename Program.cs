using schedule_mvc.Data;
using Microsoft.EntityFrameworkCore;
using schedule_mvc.Repositories;

namespace schedule_mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("Connection string 'Default' not found.");
            builder.Services.AddDbContext<ScheduleDBContext>(options => options.UseSqlServer(connectionString));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddTransient<IClientRepository, ClientRepository>();
            builder.Services.AddTransient<IDoctorRepository, DoctorRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
