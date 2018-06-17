using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Musterija : Korisnik
    {
        public Musterija(string kime, string lozinka, string ime, string prezime, string jMBG, string telefon, string email, string uloga, List<Voznja> voznje)
        {
            this.Kime = kime;
            this.lozinka = lozinka;
            this.ime = ime;
            this.prezime = prezime;
            this.JMBG = jMBG;
            this.telefon = telefon;
            this.email = email;
            this.uloga = uloga;
            this.voznje = voznje;
        }
        public Musterija() { }
    }
}