using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Vozac: Korisnik
    {
        public Lokacija lokacija { get; set; }

        public Automobil automobil { get; set; }

        public Vozac(string kime, string lozinka, string ime, string prezime, string jMBG, string telefon, string email, string uloga, List<Voznja> voznje,Automobil a,Lokacija l)
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
            this.lokacija = l;
            this.automobil = a;
        }
        public Vozac() { }

    }
}