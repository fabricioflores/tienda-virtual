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
    [Authorize]
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

        public ActionResult Buy(CarroCompra cc, int index)
        {
            Producto productInCart = cc.ElementAt(index);
            Producto productInDb = db.Productoes.Find(productInCart.id);
            if (productInDb.cantidad - 1 < 0)
            {
                return RedirectToAction("Stock", "Carro", new { id = productInDb.id});
            }
            else
            {
                cc.RemoveAt(index);
                productInDb.cantidad = productInDb.cantidad - 1;
                Pedido pedido = new Pedido();
                pedido.usuario = User.Identity.Name;
                pedido.cantidad = 1;
                pedido.Producto = productInDb;
                db.Pedidoes.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index", "Carro");
            }

        }

        public ActionResult Stock(int id)
        {
            Producto producto = db.Productoes.Find(id);
            return View(producto);
        }

    }
}
