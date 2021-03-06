﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebAPI.Models;

namespace WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Korisnici korisnici = new Korisnici("~/Baza/korisnici.txt");
            HttpContext.Current.Application["korisnici"] = korisnici;

            Dispeceri dispeceri = new Dispeceri("~/Baza/dispeceri.txt");
            HttpContext.Current.Application["dispeceri"] = dispeceri;

            Vozaci vozaci = new Vozaci("~/Baza/vozaci.txt");
            HttpContext.Current.Application["vozaci"] = vozaci;

             Voznje voznje = new Voznje("~/Baza/voznje.txt");
             HttpContext.Current.Application["voznje"] = voznje;
          Komentari komentari = new Komentari("~/Baza/komentari.txt");
            HttpContext.Current.Application["komentari"] = komentari;
        }
        protected void Application_PostAuthorizeRequest()
        {
            System.Web.HttpContext.Current.SetSessionStateBehavior(System.Web.SessionState.SessionStateBehavior.Required);
        }
    }
}
