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
        public bool Put(string id, [FromBody]Vozac vozac)//menjam samo vozaca
        {
            Vozaci vozaci = (Vozaci)HttpContext.Current.Application["vozaci"];//sve voznje


            Vozac vv = vozaci.list[id];
         /*   if (vozac.Ban != 2)
            {
                vv.Ban = vozac.Ban;
            }*/

            if (vozac.Zauzet != 2)
            {
                vv.Zauzet = vozac.Zauzet;
            }

            string path = "~/Baza/vozaci.txt";
            path = HostingEnvironment.MapPath(path);

            var lines = File.ReadAllLines(path);
            lines[int.Parse(id)] = vv.Id + ";" + vv.Kime + ";" + vv.lozinka + ";" + vv.ime + ";" + vv.prezime + ";" + vv.JMBG + ";" + vv.telefon + ";" + vv.pol + ";" + vv.email + ";" + vv.Lokacija.x + ";" + vv.Lokacija.y + ";" + vv.Lokacija.adresa.UlicaBroj + ";" + vv.Lokacija.adresa.NaseljenoMesto + ";" + vv.Lokacija.adresa.PozivniBrojMesta + ";" + vv.Automobil.BrTaksija + ";" + vv.Automobil.godiste + ";" + vv.Automobil.BrRegistracije + ";" + vv.Automobil.tipAuta+ ";" + vv.Zauzet;
            File.WriteAllLines(path, lines);

            vozaci = new Vozaci("~/Baza/vozaci.txt");
            HttpContext.Current.Application["vozaci"] = vozaci;
            return true;
        }
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
            sb.Append(vozac.Id + ";" + vozac.Kime + ";" + vozac.lozinka + ";" + vozac.ime + ";" + vozac.prezime + ";" + vozac.JMBG + ";" + vozac.telefon + ";" + vozac.pol + ";" + vozac.email + ";" + vozac.Lokacija.x + ";" + vozac.Lokacija.y + ";" + vozac.Lokacija.adresa.UlicaBroj + ";" + vozac.Lokacija.adresa.NaseljenoMesto + ";" + vozac.Lokacija.adresa.PozivniBrojMesta + ";" + vozac.Automobil.BrTaksija+ ";" + vozac.Automobil.godiste + ";" + vozac.Automobil.BrRegistracije + ";" + vozac.Automobil.tipAuta + ";" + vozac.Zauzet + "\n");

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
