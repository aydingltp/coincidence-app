using Microsoft.EntityFrameworkCore;
using CoincidenceApp.Models.Tesaduf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

 namespace CoincidenceApp.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }
        
        public DbSet<TesadufModel> TesadufModels { get; set; }
        public DbSet<SonDeger> SonDegerler { get; set; }
        public DbSet<Zaman> Zamanlar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=blogging.db");

    }
}
