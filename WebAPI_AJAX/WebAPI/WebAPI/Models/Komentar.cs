using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Komentar
    {
        public string opis { get; set; }
        public DateTime datum { get; set; }
        public Korisnik korisnik { get; set; }

        public Voznja voznja { get; set; }

        public int  ocena { get; set; }

        public Komentar(string opis, DateTime datum, Korisnik korisnik, Voznja voznja, int ocena)
        {
            this.opis = opis;
            this.datum = datum;
            this.korisnik = korisnik;
            this.voznja = voznja;
            this.ocena = ocena;
        }
        public Komentar()
        {

        }
    }
}