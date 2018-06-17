using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.DBClasses
{
    public class DispecerRepository
    {
        public List<Dispecer> GetAdmins()
        {
            SystemDBContext context = new SystemDBContext();

            return context.Dispeceri.ToList();
        }

        public Dispecer GetOneAdmin(string username)
        {
            List<Dispecer> list = GetAdmins();

            return list.FirstOrDefault(x => x.Kime == username);
        }

        public bool AdminLogged(Dispecer a, string pw)
        {
            if (a != null && pw == a.Kime)
            {
                return true;
            }

            return false;
        }
    }
}
