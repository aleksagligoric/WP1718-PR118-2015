using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
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
    }
}
