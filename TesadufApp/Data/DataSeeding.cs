using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TesadufApp.Models;

namespace TesadufApp.Data
{
    public static class DataSeeding
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<DataContext>();

            if (context==null) return;

            context?.Database.Migrate();

            if (!context.SonDegerlerAlls.Any()  )
            {
                context.SonDegerlerAlls.Add(new SonDegerlerAll
                {
                    Sayac = 0,
                    GelenDeger = "Tesaduf!",
                    Saniye = 0,
                    Dakika = 0,
                    Saat = 0,
                    Gun = 0
                });
            }

            if (!context.Zamanlar.Any())
            {
                context.Zamanlar.Add(new Zaman()
                {
                    Saniye = 0,
                    Dakika = 0,
                    Saat = 0,
                    Gun = 0
                });
            }

            if (!context.SonDegerler.Any())
            {
                context.SonDegerler.Add(new SonDeger()
                {
                    Sayac = 0,
                    GelenDeger = "Tesaduf!",
                });
            }
            if (!context.Sayacs.Any())
            {
                context.Sayacs.Add(new Sayac()
                {
                    Count = 0,
                    GelenDeger = "Tesaduf!",
                    CreatedDate = DateTime.Now,
                    Saniye = DateTime.Now.Second,
                    Dakika = DateTime.Now.Minute,
                    Saat = DateTime.Now.Hour,
                    Gun = DateTime.Now.Day

                });
            }

            context.SaveChanges();
        }
    }
}
