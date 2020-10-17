using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TesadufApp.Models;

namespace TesadufApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _db;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DataContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public string GetData()
        {
            var entity = _db.SonDegerler.OrderBy(p => p.Id).FirstOrDefault();
            var zaman = _db.Zamanlar.OrderBy(p => p.Id).FirstOrDefault();
            if (entity != null && zaman != null)
            {
                var json = new List<string>
                {
                    entity.Sayac.ToString(String.Format("000 000 000 000")),
                    entity.GelenDeger,
                    zaman.Saniye.ToString(String.Format("00")),
                    zaman.Dakika.ToString(String.Format("00")),
                    zaman.Saat.ToString(String.Format("00")),
                    zaman.Gun.ToString(String.Format("00"))
                };

                return JsonConvert.SerializeObject(json);

            }
            return null;
        }
        public string GetDatas()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var entity = _db.SonDegerlerAlls.OrderByDescending(p => p.Id).Take(300).ToList();
            entity.Reverse();
            var json = new List<JsonData>();
            foreach (var item in entity)
            {
                json.Add(new JsonData
                {
                    GelenDeger = item.GelenDeger,
                    Sayac = item.Sayac.ToString(String.Format("000 000 000 000")),
                    Saniye = item.Saniye.ToString(String.Format("00")),
                    Dakika = item.Dakika.ToString(String.Format("00")),
                    Saat = item.Saat.ToString(String.Format("00")),
                    Gun = item.Gun.ToString(String.Format("00"))
                });
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            if (entity != null)
            {
                return JsonConvert.SerializeObject(json);
            }
            return null;
        }
    }
}
