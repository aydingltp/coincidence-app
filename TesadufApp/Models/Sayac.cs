using System;

namespace TesadufApp.Models
{
    public class Sayac
    {
        public int Id { get; set; }
        public long? Count { get; set; }
        public string GelenDeger { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int Saniye { get; set; } 
        public int Dakika { get; set; }
        public int Saat { get; set; }
        public int Gun { get; set; }
    }
}
