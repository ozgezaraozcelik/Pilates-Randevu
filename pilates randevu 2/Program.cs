using pilates_randevu_2.Context;
using pilates_randevu_2.Models;
using pilates_randevu_2.VeriErisim.Somut;
using pilates_randevu_2.VeriErisim.Soyut;
namespace pilates_randevu_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>();
            builder.Services.AddScoped<IHizmetRepository, HizmetRepository>();
            builder.Services.AddScoped<IKullaniciRepository, KullaniciRepository>();
            builder.Services.AddScoped<IRandevuKayýtRepository, RandevuKayitRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Auth}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
