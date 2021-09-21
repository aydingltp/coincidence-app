using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TesadufApp.Data;
using TesadufApp.Models;
using TesadufApp.Models.ViewModel;

namespace TesadufApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _db;

        public HomeController(DataContext db)
        {
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
        
        public IActionResult GetDatas()
        {
            var entity = _db.SonDegerlerAlls.OrderByDescending(p => p.Id).Take(600).ToList();
            entity.Reverse();

            var result = JsonHelper(entity);
            
            return Json(result);
        }

        [NonAction]
        public List<JsonData> JsonHelper(List<SonDegerlerAll> data)
        {
            return data.Select(item => new JsonData
            {
                GelenDeger = item.GelenDeger,
                Sayac = item.Sayac.ToString("000 000 000 000"),
                Saniye = item.Saniye.ToString("00"),
                Dakika = item.Dakika.ToString("00"),
                Saat = item.Saat.ToString("00"),
                Gun = item.Gun.ToString("00")
            }).ToList();
        }
    }
}
