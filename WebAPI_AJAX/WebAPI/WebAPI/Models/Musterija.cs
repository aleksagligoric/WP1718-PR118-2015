using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Musterija : Korisnik
    {
        public Musterija(string id,string kime, string lozinka, string ime, string prezime, string jMBG, string telefon, string email, string pol)
        {
            this.Id = id;
            this.Kime = kime;
            this.lozinka = lozinka;
            this.ime = ime;
            this.prezime = prezime;
            this.JMBG = jMBG;
            this.telefon = telefon;
            this.email = email;
            if (pol == "muski")
            {
                this.pol = Pol.Muski;
            }
            else
            {
                this.pol = Pol.Zenski;
            }
        }
        public Musterija() { }
    }
}