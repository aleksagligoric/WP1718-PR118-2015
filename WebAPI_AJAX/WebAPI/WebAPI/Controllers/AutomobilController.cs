using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class AutomobilController : ApiController
    {
        public Automobil Get(int id)
        {
            Vozaci vozaci = (Vozaci)HttpContext.Current.Application["vozaci"];
            return vozaci.list[id.ToString()].Automobil;
        }
        public bool Put(int id, [FromBody]Automobil automobil)
        {
            Vozaci vozaci = (Vozaci)HttpContext.Current.Application["vozaci"];

            Vozac vv = vozaci.list[id.ToString()];
            vv.Automobil.BrRegistracije = automobil.BrTaksija;
            vv.Automobil.BrRegistracije = automobil.BrRegistracije;
            vv.Automobil.tipAuta = automobil.tipAuta;
            vv.Automobil.godiste = automobil.godiste;

            string path = HostingEnvironment.MapPath("~/Baza/vozaci.txt");


            var lines = File.ReadAllLines(path);
            lines[id] = vv.Id + ";" + vv.Kime + ";" + vv.lozinka + ";" + vv.ime + ";" + vv.prezime + ";" + vv.JMBG + ";" + vv.telefon + ";" + vv.pol + ";" + vv.email + ";" + vv.Lokacija.x + ";" + vv.Lokacija.y + ";" + vv.Lokacija.adresa.UlicaBroj + ";" + vv.Lokacija.adresa.NaseljenoMesto + ";" + vv.Lokacija.adresa.PozivniBrojMesta + ";" + vv.Automobil.BrTaksija + ";" + vv.Automobil.godiste + ";" + vv.Automobil.BrRegistracije + ";" + vv.Automobil.tipAuta + ";" + vv.Zauzet;
            File.WriteAllLines(path, lines);

            vozaci = new Vozaci("~/Baza/vozaci.txt");
            HttpContext.Current.Application["vozaci"] = vozaci;
            return true;


        }

    }
}
