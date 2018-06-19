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

            if (korisnici.list.ContainsKey(korisnik.Kime))
            {
                k = korisnici.list[korisnik.Kime];
                k.uloga = Models.Uloga.musterija;
                return k;
            }
            if (dispeceri.list.ContainsKey(korisnik.Kime))
            {
                k = dispeceri.list[korisnik.Kime];
                k.uloga = Models.Uloga.dispecer;
                return k;
            }
            if (vozaci.list.ContainsKey(korisnik.Kime))
            {
                k = vozaci.list[korisnik.Kime];
                k.uloga = Models.Uloga.vozac;
                return k;
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