using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tiendaVirtual.Models.binders
{
    public class CarroCompraModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            CarroCompra cc = (CarroCompra)controllerContext.HttpContext.Session["key_cc"];
            if (cc == null)
            {
                cc = new CarroCompra();
                controllerContext.HttpContext.Session["key_cc"] = cc;
            }
            return cc;
        }
    }
}