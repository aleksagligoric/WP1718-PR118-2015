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
    public class LokacijaController : ApiController
    {
        public Lokacija Get(int id)
        {
            Lokacija lokacija = new Lokacija();
            Vozaci vozaci = (Vozaci)HttpContext.Current.Application["vozaci"];

            lokacija = vozaci.list[id.ToString()].Lokacija;


            return lokacija;
        }
        public bool Put(string id, [FromBody]Lokacija lokacija)
        {

            Vozaci vozaci = (Vozaci)HttpContext.Current.Application["vozaci"];
            Vozac vv = vozaci.list[id];

            vv.Lokacija = lokacija;

            string path = "~/Baza/vozaci.txt";
            path = HostingEnvironment.MapPath(path);

            var lines = File.ReadAllLines(path);
            lines[int.Parse(id)] = vv.Id + ";" + vv.Kime  + ";" + vv.lozinka + ";" + vv.ime + ";" + vv.prezime + ";" + vv.JMBG + ";" + vv.telefon+ ";" + vv.pol + ";" + vv.email + ";" + vv.Lokacija.x + ";" + vv.Lokacija.y + ";" + vv.Lokacija.adresa.UlicaBroj + ";" + vv.Lokacija.adresa.NaseljenoMesto + ";" + vv.Lokacija.adresa.PozivniBrojMesta + ";" + vv.Automobil.BrTaksija + ";" + vv.Automobil.godiste + ";" + vv.Automobil.BrRegistracije + ";" + vv.Automobil.tipAuta + ";" + vv.Zauzet ;
            File.WriteAllLines(path, lines);

            vozaci = new Vozaci("~/Baza/vozaci.txt");
            HttpContext.Current.Application["vozaci"] = vozaci;


            return true;

        }
    }
}
