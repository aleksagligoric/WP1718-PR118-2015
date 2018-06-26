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
    public class VoznjaController : ApiController
    {
        public Voznja Get(int id)
        {
            Voznje voznje = (Voznje)HttpContext.Current.Application["voznje"];

            Voznja v = voznje.list[id.ToString()];

            return v;
        }
        public List<Voznja> Get()
        {
            Voznje voznje = (Voznje)HttpContext.Current.Application["voznje"];
            List<Voznja> kreiraneVoznje = new List<Voznja>();
            foreach (var v in voznje.list)
                kreiraneVoznje.Add(v.Value);

            return kreiraneVoznje;
        }
        public bool Post([FromBody]Voznja voznja)
        {
            Voznje voznje = (Voznje)HttpContext.Current.Application["voznje"];

            string path = "~/Baza/voznje.txt";
            path = HostingEnvironment.MapPath(path);

            StringBuilder sb = new StringBuilder();
            voznja.Id = voznje.list.Count.ToString();
            voznja.DatumVreme = DateTime.Now;

            sb.Append(voznja.Id + ";" + voznja.DatumVreme.ToString("MM/dd/yyyy HH:mm") + ";" + voznja.Lokacija.x + ";" + voznja.Lokacija.y + ";" + voznja.Lokacija.adresa.UlicaBroj + ";" + voznja.Lokacija.adresa.NaseljenoMesto + ";" + voznja.Lokacija.adresa.PozivniBrojMesta + ";" + voznja.Automobil + ";" + voznja.idKorisnik + ";0;0; ; ; ;" + voznja.idDispecer + ";" + voznja.idVozac + ";0; ; ; ; ; ;" + voznja.StatusVoznje + "\n");

            if (!File.Exists(path))
                File.WriteAllText(path, sb.ToString());
            else
                File.AppendAllText(path, sb.ToString());

            voznje = new Voznje("~/Baza/voznje.txt");
            HttpContext.Current.Application["voznje"] = voznje;
            return true;

        }
        public bool Put(string id, [FromBody]Voznja voznja)
        {
            Voznje voznje = (Voznje)HttpContext.Current.Application["voznje"];

            Voznja voki = voznje.list[id];


            if (voznja.Automobil != 0)
                voki.Automobil = voznja.Automobil;

            if (voznja.idDispecer != null)
                voki.idDispecer = voznja.idDispecer;

            if (voznja.idKorisnik != null)
                voki.idKorisnik = voznja.idKorisnik;

            if (voznja.idVozac != null)
                voki.idVozac = voznja.idVozac;

            if (voznja.Iznos != 0)
                voki.Iznos = voznja.Iznos;

            if (voznja.Komentar != null)
            {
                if (voki.Komentar.Opis != " ")
                {
                    return false;
                }
                voznja.Komentar.DatumObjave = DateTime.Now.ToString();
                voki.Komentar = voznja.Komentar;
            }

            if (voznja.Lokacija != null)
                voki.Lokacija = voznja.Lokacija;

            if (voznja.Ocena != 0)
                voki.Ocena = voznja.Ocena;

            if (voznja.Odrediste != null)
                voki.Odrediste = voznja.Odrediste;

            if (voznja.StatusVoznje != 0)
            {
                if (voznja.StatusVoznje == Models.StatusVoznje.Prihvacena)
                {
                    if (voki.StatusVoznje == Models.StatusVoznje.Prihvacena || voki.StatusVoznje == Models.StatusVoznje.Neuspesna)
                        return false;
                }

                else if (voznja.StatusVoznje == Models.StatusVoznje.Uspesna)
                {
                    if (voki.StatusVoznje == Models.StatusVoznje.Uspesna || voki.StatusVoznje == Models.StatusVoznje.Neuspesna)
                        return false;
                }
                else if (voznja.StatusVoznje == Models.StatusVoznje.Neuspesna)
                {
                    if (voki.StatusVoznje == Models.StatusVoznje.Uspesna || voki.StatusVoznje == Models.StatusVoznje.Neuspesna)
                        return false;
                }
                else if (voznja.StatusVoznje == Models.StatusVoznje.Otkazana)
                {
                    if (voki.idDispecer != " ")
                    {
                        return false;
                    }
                }

                voki.StatusVoznje = voznja.StatusVoznje;
            }

            string path = "~/Baza/voznje.txt";
            path = HostingEnvironment.MapPath(path);

            var lines = File.ReadAllLines(path);
            lines[int.Parse(id)] = voki.Id + ";" + voki.DatumVreme.ToString("MM/dd/yyyy HH:mm") + ";" + voki.Lokacija.x+ ";" + voki.Lokacija.y + ";" + voki.Lokacija.adresa.UlicaBroj + ";" + voki.Lokacija.adresa.NaseljenoMesto + ";" + voki.Lokacija.adresa.PozivniBrojMesta + ";" + voki.Automobil + ";" + voki.idKorisnik + ";" + voki.Odrediste.x + ";" + voki.Odrediste.y + ";" + voki.Odrediste.adresa.UlicaBroj + ";" + voki.Odrediste.adresa.NaseljenoMesto + ";" + voki.Odrediste.adresa.PozivniBrojMesta + ";" + voki.idDispecer + ";" + voki.idVozac + ";" + voki.Iznos + ";" + voki.Komentar.Opis + ";" + voki.Komentar.DatumObjave + ";" + voki.Komentar.idKorisnik + ";" + voki.Komentar.idVoznja + ";" + voki.Komentar.Ocena + ";" + voki.StatusVoznje;
            File.WriteAllLines(path, lines);

            voznje = new Voznje("~/Baza/voznje.txt");
            HttpContext.Current.Application["voznje"] = voznje;
            return true;
        }

    }
}
