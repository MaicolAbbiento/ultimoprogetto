using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using ultimoprogetto.Models;

namespace ultimoprogetto.Controllers
{
    public class AgiungieModificaPizzaController : Controller
    {
        // GET: AgiungieModificaPizza
        public ActionResult creapizza()
        {
            return View();
        }

        [HttpPost]
        public ActionResult creapizza(pizza p, HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {
                if (p.img != null)
                {
                    string nomeFile = img.FileName;
                    string pathToSave = Path.Combine(Server.MapPath("~/Content/FileUpload"), nomeFile);
                    img.SaveAs(pathToSave);
                    p.img = nomeFile;
                    Model1 model = new Model1();
                    model.pizza.Add(p);
                    model.SaveChanges();
                }
                else { ViewBag.pizza = "si prega di inserire un immagine"; }
            }
            return View();
        }

        public ActionResult eliminapizzadaldatabase(string parameter)
        {
            int i = Convert.ToInt32(parameter);
            Model1 model = new Model1();
            pizza p = model.pizza.FirstOrDefault((e) => e.idpizza == i);
            model.pizza.Remove(p);
            model.SaveChanges();
            return RedirectToAction("menu", "MenuOrdinazioni");
        }

        [HttpGet]
        public ActionResult modificapizza(int id)
        {
            Model1 model = new Model1();
            pizza p = model.pizza.FirstOrDefault((e) => e.idpizza == id);
            Session["img"] = p.img;
            return View(p);
        }

        [HttpPost]
        public ActionResult modificapizza(pizza p)
        {
            Model1 model = new Model1();
            if (p.img == null)
            {
                p.img = Session["img"].ToString();
            }
            else
            {
                Session["img"] = p.img;
            }
            model.Entry(p).State = EntityState.Modified;
            model.SaveChanges();
            return View();
        }
    }
}