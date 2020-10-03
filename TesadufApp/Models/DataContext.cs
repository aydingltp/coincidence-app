using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesadufApp.Models
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {

        }

        public DbSet<SonDeger> SonDegerler { get; set; }
        public DbSet<Zaman> Zamanlar { get; set; }
        public DbSet<SonDegerlerAll> SonDegerlerAlls { get; set; }
        public DbSet<DataAll> DataAlls { get; set; }

    }
}
