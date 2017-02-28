using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using tiendaVirtual;

namespace tiendaVirtual.Controllers
{
    public class PedidosController : Controller
    {
        private tiendaVirtualEntities db = new tiendaVirtualEntities();

        // GET: Pedidos
        public ActionResult Index()
        {
            var pedidoes = db.Pedidoes.Include(p => p.Producto);
            return View(pedidoes.ToList());
        }

    }
}
