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
    public class KorisnikController : ApiController
    {
        public List<Korisnik> Get()
        {
            Korisnici korisnici = (Korisnici)HttpContext.Current.Application["korisnici"];
            List<Korisnik> korisnicici = new List<Korisnik>();
            foreach (var k in korisnici.list)
                korisnicici.Add(k.Value);

            return korisnicici;

        }

        public Korisnik Get(string id)
        {
            Korisnici korisnici = (Korisnici)HttpContext.Current.Application["korisnici"];

            return korisnici.list[id];

        }
       public bool Post([FromBody]Korisnik korisnik)
       {
                Korisnici korisnici = (Korisnici)HttpContext.Current.Application["korisnici"];
                Dispeceri dispeceri = (Dispeceri)HttpContext.Current.Application["dispeceri"];
                Vozaci vozaci = (Vozaci)HttpContext.Current.Application["vozaci"];


                bool postoji = false;

                foreach (var k in dispeceri.list)
                {
                    if (k.Value.Kime == korisnik.Kime)
                    {
                        postoji = true;
                        break;
                    }
                }


                foreach (var k in korisnici.list)
                {
                    if (k.Value.Kime == korisnik.Kime)
                    {
                        postoji = true;
                        break;
                    }
                }

                foreach (var k in vozaci.list)
                {
                    if (k.Value.Kime == korisnik.Kime)
                    {
                        postoji = true;
                        break;
                    }
                }
                if (!postoji)
                {
                    string path = @"D:\Aleksa\WEBProjekat\WP1718-PR118-2015\WebAPI_AJAX\WebAPI\WebAPI\Baza\korisnici.txt";
                    StringBuilder sb = new StringBuilder();
                    korisnik.Id = korisnici.list.Count.ToString();
                    sb.Append(korisnik.Id+ ";" + korisnik.Kime+ ";" + korisnik.lozinka+ ";" + korisnik.ime + ";" + korisnik.prezime + ";" + korisnik.JMBG + ";" + korisnik.telefon + ";" + korisnik.email + ";" + korisnik.pol + "\n");

                    if (!File.Exists(path))
                        File.WriteAllText(path, sb.ToString());
                    else
                        File.AppendAllText(path, sb.ToString());

                    korisnici = new Korisnici("~/Baza/korisnici.txt");
                    HttpContext.Current.Application["korisnici"] = korisnici;
                    return true;
                }
                else
                {
                    return false;
                    //Postoji korisnik sa tim korisnickim imenom
                }
            }
        public bool Put(string id, [FromBody]Korisnik korisnik) // Izmena ? , treba mi i put da promenim da je banovan
        {
            Korisnici korisnici = (Korisnici)HttpContext.Current.Application["korisnici"];
            Dispeceri dispeceri = (Dispeceri)HttpContext.Current.Application["dispeceri"];
            Vozaci vozaci = (Vozaci)HttpContext.Current.Application["vozaci"];

            Korisnik korisnikLoc = null;
            Vozac vozacLoc = null;
            Dispecer dispecerLoc = null;

            Korisnik kmaja = new Korisnik(); //korisnik = dispecer
            Vozac vozac = new Vozac(); //on je prosiren


            if (korisnik.uloga== Uloga.musterija)
            {
                korisnikLoc = korisnici.list[id]; // to je stari korisnik koga menjam

                //proveri i za vozace i za dispecere
                foreach (var d in dispeceri.list)
                    if (d.Value.Kime == korisnik.Kime)
                        return false;

                foreach (var v in vozaci.list)
                    if (v.Value.Kime == korisnik.Kime)
                        return false;

                foreach (var k in korisnici.list)//gledam da li je jedinstven username
                {
                    if (k.Value.Kime == korisnik.Kime)//ako vec postoji proverim da to nisam ja
                    {
                        if (korisnikLoc.Kime == korisnik.Kime)//dobro je to je taj user
                        {
                            break;
                        }

                        return false;
                    }
                }

                foreach (var k in korisnici.list)
                {
                    if (k.Value.Kime == korisnikLoc.Kime)
                    {
                        break;
                    }
                }

                string path = "~/Baza/korisnici.txt";
                path = HostingEnvironment.MapPath(path);

                var lines = File.ReadAllLines(@"D:\Aleksa\WEBProjekat\WebAPI_AJAX\WebAPI\WebAPI\Baza\korisnici.txt");
                korisnikLoc.Kime = korisnik.Kime;
                korisnikLoc.lozinka = korisnik.lozinka;
                korisnikLoc.email = korisnik.email;
                korisnikLoc.ime = korisnik.ime;
                korisnikLoc.prezime = korisnik.prezime;
                korisnikLoc.telefon = korisnik.telefon;
                korisnik = korisnikLoc;
                lines[int.Parse(id)] = korisnik.Id + ";" + korisnik.ime + ";" + korisnik.prezime + ";" + korisnik.Kime + ";" + korisnik.lozinka + ";" + korisnik.JMBG + ";" + korisnik.telefon + ";" + korisnik.pol + ";" + korisnik.email;
                File.WriteAllLines(@"D:\Aleksa\WEBProjekat\WebAPI_AJAX\WebAPI\WebAPI\Baza\korisnici.txt", lines);

                korisnici = new Korisnici(@"~\Baza\korisnici.txt");
                HttpContext.Current.Application["korisnici"] = korisnici;


            }
            else if (korisnik.uloga == Uloga.vozac)
            {
                vozacLoc = vozaci.list[id]; // to je stari vozac koga menjam

                foreach (var d in dispeceri.list)
                    if (d.Value.Kime == korisnik.Kime)
                        return false;

                foreach (var k in korisnici.list)
                    if (k.Value.Kime == korisnik.Kime)
                        return false;

                foreach (var k in vozaci.list)//gledam da li je jedinstven username
                {
                    if (k.Value.Kime == korisnik.Kime)//ako vec postoji proverim da to nisam ja
                    {
                        if (vozacLoc.Kime == korisnik.Kime)//dobro je to je taj user
                        {
                            break;
                        }

                        return false;
                    }
                }

                foreach (var k in vozaci.list)
                {
                    if (k.Value.Kime == vozacLoc.Kime)
                    {
                        break;
                    }
                }

                string path = "~/Baza/vozaci.txt";
                path = HostingEnvironment.MapPath(path);

                var lines = File.ReadAllLines(@"D:\Aleksa\WEBProjekat\WebAPI_AJAX\WebAPI\WebAPI\Baza\vozaci.txt");

                vozacLoc.Kime = korisnik.Kime;
                vozacLoc.lozinka = korisnik.lozinka;
                vozacLoc.ime = korisnik.ime;
                vozacLoc.prezime = korisnik.prezime;
                vozacLoc.telefon = korisnik.telefon;
                vozacLoc.email = korisnik.email;
                vozac = vozacLoc;

                lines[int.Parse(id)] = vozac.Id + ";" + vozac.ime + ";" + vozac.prezime + ";" + vozac.Kime + ";" + vozac.lozinka + ";" + vozac.JMBG + ";" + vozac.telefon + ";" + vozac.pol + ";" + vozac.email + ";" + vozac.Lokacija.x + ";" + vozac.Lokacija.y + ";" + vozac.Lokacija.adresa.UlicaBroj + ";" + vozac.Lokacija.adresa.NaseljenoMesto+ ";" + vozac.Lokacija.adresa.PozivniBrojMesta + ";" + vozac.Automobil.BrTaksija+ ";" + vozac.Automobil.godiste + ";" + vozac.Automobil.BrRegistracije + ";" + vozac.Automobil.tipAuta + ";" + vozac.Zauzet;
                File.WriteAllLines(@"D:\Aleksa\WEBProjekat\WebAPI_AJAX\WebAPI\WebAPI\Baza\vozaci.txt", lines);

                vozaci = new Vozaci("~/Baza/vozaci.txt");
                HttpContext.Current.Application["vozaci"] = vozaci;

            }
            else if (korisnik.uloga == Uloga.dispecer)
            {
                dispecerLoc = dispeceri.list[id]; // to je stari vozac koga menjam

                foreach (var k in korisnici.list)
                    if (k.Value.Kime == korisnik.Kime)
                        return false;

                foreach (var k in korisnici.list)
                    if (k.Value.Kime == korisnik.Kime)
                        return false;

                foreach (var k in dispeceri.list)//gledam da li je jedinstven username
                {
                    if (k.Value.Kime == korisnik.Kime)//ako vec postoji proverim da to nisam ja
                    {
                        if (dispecerLoc.Kime == korisnik.Kime)//dobro je to je taj user
                        {
                            break;
                        }

                        return false;
                    }
                }

                foreach (var k in dispeceri.list)
                {
                    if (k.Value.Kime == dispecerLoc.Kime)
                    {
                        break;
                    }
                }


                string path = "~/Baza/dispeceri.txt";
                path = HostingEnvironment.MapPath(path);

                var lines = File.ReadAllLines(@"D:\Aleksa\WEBProjekat\WebAPI_AJAX\WebAPI\WebAPI\Baza\dispeceri.txt");

                dispecerLoc.Kime = korisnik.Kime;
                dispecerLoc.lozinka = korisnik.lozinka;
                dispecerLoc.email = korisnik.email;
                dispecerLoc.ime = korisnik.ime;
                dispecerLoc.prezime = korisnik.prezime;
                dispecerLoc.telefon = korisnik.telefon;
                korisnik = dispecerLoc;

                lines[int.Parse(id)] = korisnik.Id + ";" + korisnik.ime + ";" + korisnik.prezime + ";" + korisnik.Kime + ";" + korisnik.lozinka + ";" + korisnik.JMBG + ";" + korisnik.telefon + ";" + korisnik.pol + ";" + korisnik.email;
                File.WriteAllLines(@"D:\Aleksa\WEBProjekat\WebAPI_AJAX\WebAPI\WebAPI\Baza\dispeceri.txt", lines);

                dispeceri = new Dispeceri(@"D:\Aleksa\WEBProjekat\WebAPI_AJAX\WebAPI\WebAPI\Baza\dispeceri.txt");
                HttpContext.Current.Application["dispeceri"] = dispeceri;


            }

            return true;
        }


    }
}
