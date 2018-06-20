using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Voznja
    {
        public Voznja() { }

        public string Id { get; set; }
        public DateTime DatumVreme { get; set; }
        public Lokacija Lokacija { get; set; }

        public TipAuta Automobil { get; set; }

        public string idKorisnik { get; set; }

        public Lokacija Odrediste { get; set; }

        public string idDispecer { get; set; }
        public string idVozac { get; set; }
        public double Iznos { get; set; }

        public Komentar Komentar { get; set; }

        public StatusVoznje StatusVoznje { get; set; }


        public int Ocena { get; set; }


        public Voznja(string id, string datum, double xDolaziste, double yDolaziste, string ulicaBrojDolaziste, string mestoDolaziste, string zipDolaziste, string tipAuta, string idKorisnika,
          double xOdlaziste, double yOdlaziste, string ulicaBrojOdlaziste, string mestoOdlaziste, string zipOdlaziste,
            string idDispecera, string idVozaca, double iznos, string opisKomentar, string datumKomentar, string idKorKomentar, string idVoznjaKomentar, string ocenaKomentar
            , string statusVoznje) : this()
        {
            Id = id;
            DatumVreme = DateTime.Parse(datum);
            Lokacija start = new Lokacija();
            start.x = xDolaziste;
            start.y = yDolaziste;
            Adresa startAdr = new Adresa();
            startAdr.UlicaBroj = ulicaBrojDolaziste;
            startAdr.NaseljenoMesto = mestoDolaziste;
            startAdr.PozivniBrojMesta = zipDolaziste;
            start.adresa = startAdr;
            Lokacija = start;
            if (tipAuta.Equals("Putnicki")) { Automobil = TipAuta.putnicki; } else if (tipAuta.Equals("Kombi")) { Automobil = TipAuta.kombi; } else if (tipAuta.Equals("Svejedno")) { Automobil = TipAuta.svejedno; };
            idKorisnik = idKorisnika;
            Lokacija end = new Lokacija();
            end.x = xOdlaziste;
            end.y = yOdlaziste;
            Adresa endAdr = new Adresa();
            endAdr.UlicaBroj = ulicaBrojOdlaziste;
            endAdr.NaseljenoMesto = mestoOdlaziste;
            endAdr.PozivniBrojMesta = zipOdlaziste;
            end.adresa = endAdr;
            Odrediste = end;

            idDispecer = idDispecera;
            idVozac = idVozaca;

            Iznos = iznos;

            Komentar komentar = new Komentar();
            komentar.DatumObjave = datumKomentar;
            komentar.Ocena = ocenaKomentar;
            komentar.idVoznja = idVoznjaKomentar;
            komentar.idKorisnik = idKorKomentar;
            komentar.Opis = opisKomentar;
            Komentar = komentar;

            if (statusVoznje.Equals("Kreirana"))
            {
                StatusVoznje = StatusVoznje.Kreirana;
            }
            else if (statusVoznje.Equals("Formirana"))
            {
                StatusVoznje = StatusVoznje.Formirana;
            }
            else if (statusVoznje.Equals("Obradjena"))
            {
                StatusVoznje = StatusVoznje.Obradjena;
            }
            else if (statusVoznje.Equals("Prihvacena"))
            {
                StatusVoznje = StatusVoznje.Prihvacena;
            }
            else if (statusVoznje.Equals("Otkazana"))
            {
                StatusVoznje = StatusVoznje.Otkazana;
            }
            else if (statusVoznje.Equals("Neuspesna"))
            {
                StatusVoznje = StatusVoznje.Neuspesna;
            }
            else if (statusVoznje.Equals("Uspesna"))
            {
                StatusVoznje = StatusVoznje.Uspesna;
            }

        }
    }
}