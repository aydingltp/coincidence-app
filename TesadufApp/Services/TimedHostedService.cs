using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TesadufApp.Data;
using TesadufApp.Models;

namespace TesadufApp.Services
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private Timer _timer;
        private Timer _timer2;
        public readonly string searchedWord = "Kainat tesadüfen oluştu!";
        private const string letters = " AaBbCcÇçDdEeFfGgĞğHhİiIıJjKkLlMmNnOoÖöPpRrSsŞşTtUuÜüVvYyZz!";
        private int wordLength = "Kainat tesadüfen oluştu!".Length;

        public List<Zaman> _times { get; } = new();
        private readonly Zaman _time = new();


        private readonly IServiceProvider _provider;
        public TimedHostedService(IServiceProvider serviceProvider)
        {
            _provider = serviceProvider;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(TimeWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(1));

            _timer2 = new Timer(CoincidenceWork, null, TimeSpan.Zero,
                TimeSpan.FromMilliseconds(100));

            //_timer2 = new Timer(CoincidenceWork, null, TimeSpan.Zero,
            //    TimeSpan.FromMinutes(10));

            return Task.CompletedTask;
        }


        private void CoincidenceWork(object state)
        {
            using var scope = _provider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<DataContext>();

            var stringChars = new char[wordLength];
            var random = new Random();

            for (var i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = letters[random.Next(letters.Length)];
            }
            var uretilenKelime = new string(stringChars);

            var lastEntity = db.SonDegerler.OrderBy(p => p.Id).FirstOrDefault();
            var lastTime = db.Zamanlar.FirstOrDefault();

            if (uretilenKelime == searchedWord)
            {
                var mirEntity = db.SonDegerlerAlls.OrderByDescending(p => p.Id).Take(300).ToList();
                foreach (var item in mirEntity)
                {
                    item.GelenDeger = uretilenKelime;
                    item.Sayac = lastEntity.Sayac;
                    item.Saniye = lastTime.Saniye;
                    item.Dakika = lastTime.Dakika;
                    item.Saat = lastTime.Saat;
                    item.Gun = lastTime.Gun;
                }
                db.SaveChanges();
                StopAsync(CancellationToken.None);
                return;
            }

            var sonYuzHepsi = db.SonDegerlerAlls.Count();
            if (sonYuzHepsi > 1200)
            {
                var ilkUcYuz = db.SonDegerlerAlls.OrderBy(p=>p.Id).Take(300);
                db.SonDegerlerAlls.RemoveRange(ilkUcYuz);
            }

            var sonyuzEntity = new SonDegerlerAll
            {
                Sayac = lastEntity.Sayac,
                GelenDeger = lastEntity.GelenDeger,
                Saniye = lastTime.Saniye,
                Dakika = lastTime.Dakika,
                Saat = lastTime.Saat,
                Gun = lastTime.Gun
            };
            db.SonDegerlerAlls.Add(sonyuzEntity);

            lastEntity.Sayac += 1;
            lastEntity.GelenDeger = uretilenKelime;

            db.SaveChanges();
        }


        private void TimeWork(object state)
        {
            using var scope = _provider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<DataContext>();
            var entity = db.Zamanlar.OrderBy(p => p.Id).FirstOrDefault();

            if (entity == null) return;

            _time.Saniye = entity.Saniye;
            _time.Dakika = entity.Dakika;
            _time.Saat = entity.Saat;
            _time.Gun = entity.Gun;

            if ((_time.Saniye == 59))
            {
                _time.Saniye = -1;
                _time.Dakika += 1;
                if (_time.Dakika == 60)
                {
                    _time.Saniye = 0;
                    _time.Dakika = 0;
                    _time.Saat += 1;
                    if (_time.Saat == 24)
                    {
                        _time.Saniye = 0;
                        _time.Dakika = 0;
                        _time.Saat = 0;
                        _time.Gun += 1;
                    }
                }
            }
            _time.Saniye += 1;
            _times.Add(_time);

            entity.Saniye = _time.Saniye;
            entity.Dakika = _time.Dakika;
            entity.Saat = _time.Saat;
            entity.Gun = _time.Gun;

            db.SaveChanges();

        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _timer2?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
            _timer2.Dispose();
        }


    }
}
