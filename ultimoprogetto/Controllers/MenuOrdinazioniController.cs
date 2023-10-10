using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public JsonResult ordina(string input)
        {
            Model1 model = new Model1();
            List<pizza> cl = model.pizza.ToList();

            ordini ordini = new ordini();
            cliente cliente = new cliente();
            cliente = model.cliente.FirstOrDefault(c => c.username == User.Identity.Name);
            ordini.idcliente = cliente.idcliente;
            ordini.dataordine = DateTime.Now;
            ordini.completato = false;
            ordini.indirizzo = (string)Session["ind"];
            List<ordini> o = model.ordini.Where((c) => c.idcliente == ordini.idcliente && ordini.completato == false).ToList();
            if (o.Count == 0)
            {
                model.ordini.Add(ordini);
                model.SaveChanges();
            }
            List<ordini> ord = model.ordini.Where((c) => c.idcliente == ordini.idcliente && ordini.completato == false).ToList();
            pizeeoridnate p = new pizeeoridnate();
            p.idordine = ord[0].idordine;
            Session["ordine"] = o[0].idordine;
            pizza piz = (pizza)Session["pizza"];
            piz.idpizza = p.idpizza;
            model.pizeeoridnate.Add(p);

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
                d.indirizzo = "ritiro in pizzerie";
            }

            Session["ind"] = d.indirizzo;

            return PartialView("_indirizzo", d);
        }

        public JsonResult query2()
        {
            Model1 model = new Model1();
            List<pizza> cl = model.pizza.ToList();
            Random random = new Random();
            List<int> list = new List<int>();
            foreach (pizza pizza in cl)
            {
                pizza.idpizzaimpt = random.Next(cl.Count + 1, 500000000);
                list.Add(pizza.idpizzaimpt);
            }
            return Json(cl, JsonRequestBehavior.AllowGet);
        }
    }
}