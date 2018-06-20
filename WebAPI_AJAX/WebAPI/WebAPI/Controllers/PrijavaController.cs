using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class PrijavaController : ApiController
    {
        // GET: Prijava
        public Korisnik Put(string id, [FromBody]Korisnik korisnik)
        {
            Korisnik k = null;
            Korisnici korisnici = (Korisnici)HttpContext.Current.Application["korisnici"];
            Dispeceri dispeceri = (Dispeceri)HttpContext.Current.Application["dispeceri"];
            Vozaci vozaci = (Vozaci)HttpContext.Current.Application["vozaci"];

            foreach (var kk in korisnici.list)
            {
                if (kk.Value.Kime == korisnik.Kime)
                {
                    k = kk.Value;
                    k.uloga = Models.Uloga.musterija;
                    return k;
                }
            }

            foreach (var kk in dispeceri.list)
            {
                if (kk.Value.Kime == korisnik.Kime)
                {
                    k = kk.Value;
                    k.uloga = Models.Uloga.dispecer;

                    return k;
                }
            }

            foreach (var kk in vozaci.list)
            {
                if (kk.Value.Kime == korisnik.Kime)
                {
                    k = kk.Value;
                    k.uloga = Models.Uloga.vozac;

                    return k;
                }
            }

            return k;
        }

        public string Post([FromBody]Korisnik korisnik) // Ispravnost user-a
        {
            Vozaci vozaci = (Vozaci)HttpContext.Current.Application["vozaci"];

            Korisnici korisnici = (Korisnici)HttpContext.Current.Application["korisnici"];
            Dispeceri dispeceri = (Dispeceri)HttpContext.Current.Application["dispeceri"];

            foreach (var k in korisnici.list)
            {

                if ((k.Value.Kime.Equals(korisnik.Kime)) && (k.Value.lozinka.Equals(korisnik.lozinka)))
                {

                    return "Uspesno";
                }

            }
            foreach (var k in dispeceri.list)
            {

                if ((k.Value.Kime.Equals(korisnik.Kime)) && (k.Value.lozinka.Equals(korisnik.lozinka)))
                {

                    return "Uspesno";
                }

            }
            foreach (var k in vozaci.list)
            {

                if ((k.Value.Kime.Equals(korisnik.Kime)) && (k.Value.lozinka.Equals(korisnik.lozinka)))
                {

                    return "Uspesno";
                }

            }
            return "Neuspesna prijava";
        }

    }
}