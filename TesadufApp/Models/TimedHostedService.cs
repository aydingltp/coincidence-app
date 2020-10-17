using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TesadufApp.Models
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private Timer _timer;
        private Timer _timer2;

        Zaman _time = new Zaman();


        private readonly IServiceProvider _provider;
        public TimedHostedService(IServiceProvider serviceProvider)
        {
            _provider = serviceProvider;
        }
        public Task StartAsync(CancellationToken stoppingToken)
        { 
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(1));
            _timer2 = new Timer(DoWork2, null, TimeSpan.Zero,
                TimeSpan.FromMilliseconds(100));

            return Task.CompletedTask;
        }    
         

        private void DoWork2(object state)
        {
            using (IServiceScope scope = _provider.CreateScope())
            {
                var _db = scope.ServiceProvider.GetRequiredService<DataContext>();

                var harfler = " .AaBbCcÇçDdEeFfGgĞğHhİiIıJjKkLlMmNnOoÖöPpRrSsŞşTtUuÜüVvYyZz";
                var stringChars = new char[24];
                var random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = harfler[random.Next(harfler.Length)];
                }
                var uretilenKelime = new String(stringChars);
                var lastEntity = _db.SonDegerler.OrderBy(p => p.Id).FirstOrDefault();
                var lastTime = _db.Zamanlar.FirstOrDefault();

                if (uretilenKelime == "Kainat tesadüfen oluştu.")
                {
                    //StopAsync(DoWork();
                    StopAsync(CancellationToken.None);
                    return;
                }

                if (lastEntity != null && lastTime != null)
                {
                    var sonYuzHepsi = _db.SonDegerlerAlls.Count();
                    if (sonYuzHepsi > 1200)
                    {
                        var ilkYuzYirmi = _db.SonDegerlerAlls.Take(300);
                        _db.SonDegerlerAlls.RemoveRange(ilkYuzYirmi);
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
                    _db.SonDegerlerAlls.Add(sonyuzEntity);

                    lastEntity.Sayac = lastEntity.Sayac + 1;
                    lastEntity.GelenDeger = uretilenKelime;

                    _db.Entry(lastEntity).State = EntityState.Modified;

                    _db.SaveChanges();
                }
                else
                {
                    var sonDegerEntity = new SonDeger
                    {
                        Sayac = 1,
                        GelenDeger = uretilenKelime
                    };
                    var zamanEntity = new Zaman
                    {
                        Saniye = 0,
                        Dakika = 0,
                        Saat = 0,
                        Gun = 0,
                    };
                    _db.SonDegerler.Add(sonDegerEntity);
                    _db.Zamanlar.Add(zamanEntity);
                    _db.SaveChanges();
                }
            }
        }


        private void DoWork(object state)
        {
            using (IServiceScope scope = _provider.CreateScope())
            {
                var _db = scope.ServiceProvider.GetRequiredService<DataContext>();
                var entity = _db.Zamanlar.OrderBy(p => p.Id).FirstOrDefault();
                if (entity == null)
                {
                    var time = new Zaman
                    {
                        Saniye = 0,
                        Dakika = 0,
                        Saat = 0,
                        Gun = 0,
                    };
                    _db.Zamanlar.Add(time);
                    _db.SaveChanges();
                }

                else
                {
                    _time.Saniye = entity.Saniye;
                    _time.Dakika = entity.Dakika;
                    _time.Saat = entity.Saat;
                    _time.Gun = entity.Gun;

                    if ((_time.Saniye == 59))
                    {
                        _time.Saniye = -1;
                        _time.Dakika = _time.Dakika + 1;
                        if (_time.Dakika == 60)
                        {
                            _time.Saniye = 0;
                            _time.Dakika = 0;
                            _time.Saat = _time.Saat + 1;
                            if (_time.Saat == 24)
                            {
                                _time.Saniye = 0;
                                _time.Dakika = 0;
                                _time.Saat = 0;
                                _time.Gun = _time.Gun + 1;
                            }
                        }
                    }
                    _time.Saniye = _time.Saniye + 1;

                    entity.Saniye = _time.Saniye;
                    entity.Dakika = _time.Dakika;
                    entity.Saat = _time.Saat;
                    entity.Gun = _time.Gun;
                    _db.Entry(entity).State = EntityState.Modified;
                    _db.SaveChanges();
                }
            }
        }
        public Task StopAsync(CancellationToken stoppingToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
            _timer2.Dispose();
        }


    }
}
