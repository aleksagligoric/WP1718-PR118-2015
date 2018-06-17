using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.DBClasses
{
    public class SystemDBContext
    {
        public DbSet<Musterija> Musterije { get; set; }
        public DbSet<Dispecer> Dispeceri { get; set; }
        public DbSet<Vozac> Vozaci { get; set; }
        public DbSet<Lokacija> Lokacije { get; set; }
        public DbSet<Voznja> Voznje { get; set; }
        public DbSet<Komentar> Komentari { get; set; }
    }
}