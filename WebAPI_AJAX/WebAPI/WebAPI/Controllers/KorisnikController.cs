using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
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
       

    }
}
