using F1_DataAccess.Repository;
using F1_DataAccess.Repository.IRepository;
using F1_Garage.Data;
using Microsoft.EntityFrameworkCore;

namespace F1_Garage
{
    public static class AppConfig
    {
        // SERVICES
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
        }

        public static void ConfigureApp(WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}