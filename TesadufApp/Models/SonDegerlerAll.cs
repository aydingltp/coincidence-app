using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesadufApp.Models
{
    public class SonDegerlerAll
    {
        public int Id { get; set; }
        public Int64 Sayac { get; set; }
        public string GelenDeger { get; set; }
        public int Saniye { get; set; }
        public int Dakika { get; set; }
        public int Saat { get; set; }
        public int Gun { get; set; }
    }
}
