using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ultimoprogetto.Models;

namespace ultimoprogetto.Controllers
{
    public class CassaController : Controller
    {
        // GET: Cassa
        public ActionResult cassa()
        {
            return View();
        }

        public JsonResult soldincassati()
        {
            Model1 model = new Model1();
            DateTime dataOggi = DateTime.Now.Date;
            List<ordini> or = model.ordini.Where((o) => o.dataordine == dataOggi).ToList();
            decimal prezzoTot = 0;
            int nuomeroOrdiniEvasi = 0;
            foreach (var item in or)
            {
                if (item.evaso == true)
                {
                    nuomeroOrdiniEvasi++;
                    prezzoTot += item.costotot;
                }
            }
            Soldi soldi = new Soldi();
            soldi.soldiDelgiorniorno = prezzoTot.ToString("C2");
            soldi.numeroOrdiniEvasi = nuomeroOrdiniEvasi;
            return Json(soldi, JsonRequestBehavior.AllowGet);
        }
    }
}