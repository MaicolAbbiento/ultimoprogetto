using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ultimoprogetto.Models;

namespace ultimoprogetto.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult signUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult signUp(cliente c)
        {
            if (ModelState.IsValid)
            {
                Model1 model = new Model1();
                List<cliente> cl = model.cliente.Where((e) => e.username == c.username).ToList();
                List<amministatori> a = model.amministatori.Where((e) => e.username == c.username).ToList();
                if (cl.Count == 0 && a.Count == 0)
                {
                    if (c.password == c.confermaPassword)
                    {
                        model.cliente.Add(c);
                        model.SaveChanges();
                        FormsAuthentication.SetAuthCookie(c.username, false);
                    }
                    else { ViewBag.errore = "le password non coincidono"; }
            ;
                }
                else { ViewBag.errore = "utente già presente"; }
            }

            return View();
        }

        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        public ActionResult login(amministatori c)
        {
            Model1 model = new Model1();
            amministatori d = new amministatori();
            d = model.amministatori.FirstOrDefault(p => p.username == c.username && p.password == c.password);
            cliente cl = new cliente();
            cl = model.cliente.FirstOrDefault(p => p.username == c.username && p.password == c.password);
            if (d != null || cl != null)
            {
                FormsAuthentication.SetAuthCookie(c.username, false);
            }
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult listautenti()
        {
            Model1 model = new Model1();
            List<cliente> cl = model.cliente.ToList();

            return View(cl);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}