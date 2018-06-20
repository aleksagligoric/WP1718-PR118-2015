using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Vozac: Korisnik
    {
        public Lokacija Lokacija { get; set; }
        public Automobil Automobil { get; set; }
        public int Zauzet { get; set; } // 0 - nije zauzet i 1 jeste

        public Vozac() { }


        public Vozac( string id,string ime, string prezime, string korisnickoIme, string lozinka, string jmbg, string kontakt, string pol,
            string email, double x, double y, string ulicaBroj, string mesto, string zip, string brojAuta, int godisteAuta, string registracijaAuta
            , string tipAuta, int z) : this()
        {
            Zauzet = z;
            //Licne INFO
            this.Id = id;
            this.ime = ime;
            this.prezime = prezime;
            this.Kime= korisnickoIme;
            this.lozinka = lozinka;
            this.JMBG = jmbg;
            this.telefon = kontakt;
            if (pol.Equals("Muski")) { this.pol = Pol.Muski; } else { this.pol = Pol.Zenski; }
            this.email = email;

            //LOKACIJA
            Lokacija l = new Lokacija();
            l.x = x; l.y = y;
            Adresa a = new Adresa(); // Treba za lokaciju
            a.UlicaBroj = ulicaBroj; a.NaseljenoMesto = mesto; a.PozivniBrojMesta = zip;
            l.adresa = a;
            Lokacija = l;

            //AUTOMOBIL
            Automobil auto = new Automobil();
            auto.BrTaksija= brojAuta;
            auto.godiste = godisteAuta.ToString();
            auto.BrRegistracije = registracijaAuta;
            if (tipAuta.Equals("Putnicki")) { auto.tipAuta = TipAuta.putnicki; } else if (tipAuta.Equals("Kombi")) { auto.tipAuta = TipAuta.kombi; };
            Automobil = auto;
        }


    }

    
}