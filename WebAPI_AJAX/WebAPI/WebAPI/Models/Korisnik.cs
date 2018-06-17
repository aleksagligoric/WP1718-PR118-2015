using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Korisnik
    {
        public   string Kime { get; set; }
        public string lozinka { get; set; }
        public string ime { get; set; }

        public string prezime { get; set; }

        public string JMBG { get; set; }

        public string telefon { get; set; }

        public string email { get; set; }

        public string uloga { get; set; }

        public List<Voznja> voznje = new List<Voznja>();

        public Korisnik(){ }

        public Korisnik(string kime, string lozinka, string ime, string prezime, string jMBG, string telefon, string email, string uloga, List<Voznja> voznje)
        {
            Kime = kime;
            this.lozinka = lozinka;
            this.ime = ime;
            this.prezime = prezime;
            JMBG = jMBG;
            this.telefon = telefon;
            this.email = email;
            this.uloga = uloga;
            this.voznje = voznje;
        }
    }
}