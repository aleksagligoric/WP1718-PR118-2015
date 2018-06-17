using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Automobil
    {
        public Vozac vozac { get; set; }
        public string godiste { get; set; }

        public string BrRegistracije { get; set; }

        public string BrTaksija { get; set; }

        public  TipAuta tipAuta  { get; set; }

        public Automobil(Vozac vozac, string godiste, string brRegistracije, string brTaksija, TipAuta tipAuta)
        {
            this.vozac = vozac;
            this.godiste = godiste;
            BrRegistracije = brRegistracije;
            BrTaksija = brTaksija;
            this.tipAuta = tipAuta;
        }
        public Automobil()
        {

        }
    }
}