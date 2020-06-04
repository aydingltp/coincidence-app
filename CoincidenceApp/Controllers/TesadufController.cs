﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoincidenceApp.Models;
using CoincidenceApp.Models.Tesaduf;

namespace CoincidenceApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [FormatFilter]
    public class TesadufController : ControllerBase
    {

        private readonly DataContext _db;

        public TesadufController(DataContext db)
        {
            _db = db;
        }


        // GET: api/Tesaduf
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var entity = _db.SonDegerler.OrderBy(p => p.Id).FirstOrDefault();
            var zaman = _db.Zamanlar.OrderBy(p => p.Id).FirstOrDefault();
            return new List<string>
            {
                entity.Sayac.ToString(String.Format("000 000 000")),
                entity.GelenDeger,
                zaman.Saniye.ToString(String.Format("00")),
                zaman.Dakika.ToString(String.Format("00")),
                zaman.Saat.ToString(String.Format("00")),
                zaman.Gun.ToString(String.Format("00"))
            };
        }

        // GET: api/Tesaduf/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Tesaduf
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Tesaduf/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
