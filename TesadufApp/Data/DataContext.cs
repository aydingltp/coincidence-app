using Microsoft.EntityFrameworkCore;
using TesadufApp.Models;

namespace TesadufApp.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<SonDeger> SonDegerler { get; set; }
        public DbSet<Zaman> Zamanlar { get; set; }
        public DbSet<SonDegerlerAll> SonDegerlerAlls { get; set; }
        public DbSet<Sayac> Sayacs { get; set; }

    }
}
