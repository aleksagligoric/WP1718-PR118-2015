using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Voznja
    {
        public DateTime vreme { get; set; }
        public string lokacija { get; set; }
        public  TipAuta tip { get; set; }

       public Musterija musterija { get; set; }

        public Lokacija odrediste { get; set; }

        public Dispecer diespecer { get; set; }

        public int iznos { get; set; }

        public  Komentar komentar { get; set; }

        public StatusVoznje status { get; set; }

        public Voznja(DateTime vreme, string lokacija, TipAuta tip, Musterija musterija, Lokacija odrediste, Dispecer diespecer, int iznos, Komentar komentar, StatusVoznje status)
        {
            this.vreme = vreme;
            this.lokacija = lokacija;
            this.tip = tip;
            this.musterija = musterija;
            this.odrediste = odrediste;
            this.diespecer = diespecer;
            this.iznos = iznos;
            this.komentar = komentar;
            this.status = status;
        }
        public Voznja()
        {
                
        }
    }
}