using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class VozacController : ApiController
    {
        public List<Vozac> Get()
        {
            Vozaci vozaci = (Vozaci)HttpContext.Current.Application["vozaci"];
            List<Vozac> lista = new List<Vozac>();

            foreach (var v in vozaci.list)
                lista.Add(v.Value);

            return lista;
        }

        public Vozac Get(string id)
        {
            Vozaci vozaci = (Vozaci)HttpContext.Current.Application["vozaci"];
            return vozaci.list[id];
        }

        public bool Post([FromBody]Vozac vozac)
        {
            Vozaci vozaci = (Vozaci)HttpContext.Current.Application["vozaci"];
            Korisnici korisnici = (Korisnici)HttpContext.Current.Application["korisnici"];
            Dispeceri dispeceri = (Dispeceri)HttpContext.Current.Application["dispeceri"];

            foreach (var v in vozaci.list)
            {
                if (v.Value.Kime == vozac.Kime)
                    return true;
            }

            foreach (var v in korisnici.list)
            {
                if (v.Value.Kime == vozac.Kime)
                    return true;
            }

            foreach (var v in dispeceri.list)
            {
                if (v.Value.Kime == vozac.Kime)
                    return true;
            }

            string path = "~/Baza/vozaci.txt";
            path = HostingEnvironment.MapPath(path);

            StringBuilder sb = new StringBuilder();
            vozac.Id = vozaci.list.Count.ToString();
            vozac.Automobil.BrTaksija = (vozaci.list.Count + 100).ToString();
            sb.Append(vozac.Id + ";" + vozac.ime + ";" + vozac.prezime + ";" + vozac.Kime + ";" + vozac.lozinka + ";" + vozac.JMBG + ";" + vozac.telefon + ";" + vozac.pol + ";" + vozac.email + ";" + vozac.Lokacija.x + ";" + vozac.Lokacija.y + ";" + vozac.Lokacija.adresa.UlicaBroj + ";" + vozac.Lokacija.adresa.NaseljenoMesto + ";" + vozac.Lokacija.adresa.PozivniBrojMesta + ";" + vozac.Automobil.BrTaksija+ ";" + vozac.Automobil.godiste + ";" + vozac.Automobil.BrRegistracije + ";" + vozac.Automobil.tipAuta + ";" + vozac.Zauzet + "\n");

            if (!File.Exists(path))
                File.WriteAllText(path, sb.ToString());
            else
                File.AppendAllText(path, sb.ToString());

            vozaci = new Vozaci("~/Baza/vozaci.txt");
            HttpContext.Current.Application["vozaci"] = vozaci;
            return false;
        }

    }
}
