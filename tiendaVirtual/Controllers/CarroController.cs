using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using tiendaVirtual;
using tiendaVirtual.Models;

namespace tiendaVirtual.Controllers
{
    public class CarroController : Controller
    {
        private tiendaVirtualEntities db = new tiendaVirtualEntities();

        // GET: Carro
        public ActionResult Index(CarroCompra cc)
        {
            return View(cc);
        }

        public ActionResult DeleteFromCart(CarroCompra cc, int index) {
            cc.RemoveAt(index);
            return RedirectToAction("Index", "Carro");
        }

    }
}
