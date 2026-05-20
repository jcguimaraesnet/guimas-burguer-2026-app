using GuimasBurguer2026App.Data;
using GuimasBurguer2026App.Services;
using GuimasBurguer2026App.Services.Memory;

namespace GuimasBurguer2026App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddTransient<IHamburguerService, Services.Data.HamburguerService>();
            //builder.Services.AddSingleton<IHamburguerService, Services.Memory.HamburguerService>();
            builder.Services.AddDbContext<HamburguerDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            app.Run();
        }
    }
}
