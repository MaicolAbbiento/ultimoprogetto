using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ultimoprogetto.Models;

namespace ultimoprogetto.Controllers
{
    public class MenuOrdinazioniController : Controller
    {
        // GET: MenuOrdinazioni
        public ActionResult menu()
        {
            Model1 model = new Model1();
            List<pizza> cl = model.pizza.ToList();

            return View(cl);
        }

        [HttpPost]
        public JsonResult ordina(string input, string id)
        {
            Model1 model = new Model1();
            List<pizza> cl = model.pizza.ToList();

            ordini ordini = new ordini();
            cliente cliente = new cliente();
            cliente = model.cliente.FirstOrDefault(c => c.username == User.Identity.Name);
            ordini.idcliente = cliente.idcliente;
            ordini.dataordine = DateTime.Now;
            ordini.completato = false;
            if (Session["ind"] == null)
            { ordini.indirizzo = "ritiro in pizzeria"; }
            else { ordini.indirizzo = (string)Session["ind"]; }

            List<ordini> o = model.ordini.Where((c) => c.idcliente == ordini.idcliente && c.completato == false).ToList();
            if (o.Count == 0)
            {
                ordini.evaso = false;
                model.ordini.Add(ordini);
                model.SaveChanges();
            }
            List<ordini> ord = model.ordini.Where((c) => c.idcliente == ordini.idcliente && c.completato == false).ToList();

            pizeeoridnate p = new pizeeoridnate();
            p.idordine = ord[0].idordine;

            int piz = Convert.ToInt32(id);
            p.idpizza = piz;
            List<pizeeoridnate> a = model.pizeeoridnate.Where((pi) => pi.idpizza == piz).ToList();
            if (a.Count == 0)
            {
                if (input == "")
                {
                    p.quantita = 1;
                }
                else { p.quantita = Convert.ToInt32(input); }

                model.pizeeoridnate.Add(p);
                model.SaveChanges();
            }
            else
            {
                p.idpizeeoridnate = a[0].idpizeeoridnate;
                if (input == "")
                {
                    p.quantita = Convert.ToInt32(input) + a[0].quantita;
                }
                p.quantita = Convert.ToInt32(input) + a[0].quantita;

                Model1 model1 = new Model1();

                model1.Entry(p).State = EntityState.Modified;

                model1.SaveChanges();
            }
            return Json(cl);
        }

        [HttpGet]
        public ActionResult indirizzo()
        {
            return PartialView("_indirizzo");
        }

        [HttpPost]
        public ActionResult indirizzo([Bind(Include = "indirizzo")] ordini d)
        {
            if (d.indirizzo == null)
            {
                d.indirizzo = "ritiro in pizzeria";
            }

            Session["ind"] = d.indirizzo;

            return PartialView("_indirizzo", d);
        }

        public JsonResult query2()
        {
            Model1 model = new Model1();
            List<pizza> cl = model.pizza.ToList();
            List<int> pizzaid = new List<int>();
            foreach (var item in cl)
            {
                pizzaid.Add(item.idpizza);
            }

            return Json(pizzaid, JsonRequestBehavior.AllowGet);
        }

        public ActionResult concludiordine()
        {
            Model1 model = new Model1();
            cliente cliente = new cliente();
            cliente = model.cliente.FirstOrDefault(c => c.username == User.Identity.Name);
            List<ordini> o = model.ordini.Where((c) => c.idcliente == cliente.idcliente && c.completato == false).ToList();
            List<pizeeoridnate> pi = new List<pizeeoridnate>();
            if (o.Count > 0)
            {
                int id = o[0].idordine;

                pi = model.pizeeoridnate.Where((p) => p.idordine == id).ToList();
                decimal costo = 0;
                int t = 0;
                foreach (var item in pi)
                {
                    pizza p = model.pizza.Find(item.idpizza);
                    costo = p.costo * item.quantita;

                    t += p.tempoConsegnamin;
                }
                ViewBag.tempostimato = t;

                ViewBag.costotot = costo.ToString("C2");
            }
            else
            {
                pi = new List<pizeeoridnate>();
            }
            return View(pi);
        }

        public ActionResult listaord()
        {
            Model1 model = new Model1();
            cliente cliente = new cliente();
            List<pizeeoridnate> pi = new List<pizeeoridnate>();
            if (User.IsInRole("Admin"))
            {
                List<ordini> o = model.ordini.Where((c) => c.completato == true && c.evaso == false).ToList();

                foreach (var item in o)
                {
                    List<pizeeoridnate> pizzaa = model.pizeeoridnate.Where((p) => p.idordine == item.idordine).ToList();
                    foreach (var item3 in pizzaa)
                    {
                        pi.Add(item3);
                    }
                }
            }
            else
            {
                List<ordini> o = model.ordini.Where((c) => c.completato == true && c.cliente.username == User.Identity.Name).ToList();
                foreach (var item in o)
                {
                    List<pizeeoridnate> pizzaa = model.pizeeoridnate.Where((p) => p.idordine == item.idordine).ToList();
                    foreach (var item3 in pizzaa)
                    {
                        pi.Add(item3);
                    }
                }
            }
            pi.Reverse();
            return View(pi);
        }

        public ActionResult concludiordine1(string parameter)
        {
            int id = int.Parse(parameter);
            Model1 model = new Model1();
            cliente cliente = new cliente();

            ordini o = model.ordini.Find(id);
            o.completato = true;
            List<pizeeoridnate> pi = new List<pizeeoridnate>();

            pi = model.pizeeoridnate.Where((p) => p.idordine == o.idordine).ToList();
            decimal costo = 0;
            foreach (var item in pi)
            {
                pizza p = model.pizza.Find(item.idpizza);
                costo = p.costo * item.quantita;
            }
            o.costotot = costo;
            model.Entry(o).State = EntityState.Modified;

            model.SaveChanges();
            return RedirectToAction("menu");
        }
    }
}