﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.DBClasses
{
    public class MusterijaRepository
    {
       
            public List<Musterija> GetMusterije()
            {
                SystemDBContext context = new SystemDBContext();

                return context.Musterije.ToList();
            }

            public Musterija GetOneMusterija(string username)
            {
                List<Musterija> list = GetMusterije();

                return list.FirstOrDefault(x => x.Kime == username);
            }

            public bool MusterijaLogged(Musterija m, string pw)
            {
                if (m != null && pw == m.lozinka)
                {
                    return true;
                }

                return false;
            }
        }
}