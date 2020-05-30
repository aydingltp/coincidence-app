using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CoincidenceApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CoincidenceApp.Models.Tesaduf
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private Timer _timer;
        private Timer _timer2;

        Zaman _time = new Zaman();

        //private readonly DataContext _db;
        //public TimedHostedService(DataContext db)
        //{
        //    _db = db;
        //}
        //private DataContext _db;
        
        private readonly IServiceProvider _provider;
        public TimedHostedService(IServiceProvider serviceProvider)
        {
            _provider = serviceProvider;
        }
        public Task StartAsync(CancellationToken stoppingToken)
        {
            //_logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(1));
            _timer2 = new Timer(DoWork2, null, TimeSpan.Zero,
                TimeSpan.FromMilliseconds(1000));

            return Task.CompletedTask;
        }

        private void DoWork2(object state)
        {
            using (IServiceScope scope = _provider.CreateScope())
            {
                var _db = scope.ServiceProvider.GetRequiredService<DataContext>();

                var harfler = " .AaBbCcÇçDdEeFfGgĞğHhİiIıJjKkLlMmNnOoÖöPpRrSsŞşTtUuÜüVvYyZz";
                var stringChars = new char[27];
                var random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = harfler[random.Next(harfler.Length)];
                }
                var uretilenKelime = new String(stringChars);
                var lastEntity = _db.SonDegerler.OrderBy(p => p.Id).FirstOrDefault();
                //var lastEntity = _db.SonDegerler.Find(1);

                //var lastEntity = _db.TesadufModels.OrderByDescending(p => p.Id).FirstOrDefault();

                if (lastEntity != null)
                {
                    var entity = new TesadufModel()
                    {
                        Sayac = lastEntity.Sayac + 1,
                        GelenDeger = uretilenKelime
                    };
                    //_db.TesadufModels.Add(entity);
                    lastEntity.Sayac = lastEntity.Sayac + 1;
                    lastEntity.GelenDeger = uretilenKelime;
                    _db.Entry(lastEntity).State = EntityState.Modified;

                    _db.SaveChanges();
                    //return finalString;
                }
                else
                {
                    var entity2 = new SonDeger()
                    {
                        Sayac = 1,
                        GelenDeger = uretilenKelime
                    };
                    //var entity = new TesadufModel()
                    //{
                    //    Sayac = 1,
                    //    GelenDeger = uretilenKelime
                    //};
                    //_db.TesadufModels.Add(entity);
                    _db.SonDegerler.Add(entity2);

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
                        Saniye = 0, //time.Saniye,
                        Dakika = 0, //time.Dakika,
                        Saat = 0, //time.Saat,
                        Gun = 0, //time.Gun
                    };
                   
                    _db.Zamanlar.Add(time);
                    _db.SaveChanges();
                }
                // 
                if (entity != null)
                {
                    _time.Saniye = entity.Saniye;
                    _time.Dakika = entity.Dakika;
                    _time.Saat = entity.Saat;
                    _time.Gun = entity.Gun;
                    
                    if ((_time.Saniye == 59))
                    {
                        _time.Saniye = 0;
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
                /*else
                {
                    var entity2 = new Zaman
                    {
                        Saniye = time.Saniye,
                        Dakika = time.Dakika,
                        Saat = time.Saat,
                        Gun = time.Gun
                    };
                    _db.Zamanlar.Add(entity2);
                    _db.SaveChanges();
                }*/

                //_logger.LogInformation(
                //    "Timed Hosted Service is working. Count: {Count}", executionCount);
            }
        }
        public Task StopAsync(CancellationToken stoppingToken)
        {
            //_logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }


    }

}
