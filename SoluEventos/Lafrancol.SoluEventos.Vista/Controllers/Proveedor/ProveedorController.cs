using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lafrancol.SoluEventos.Vista.Controllers.ProveedorController
{
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        public ActionResult index()
        {
            return View("Proveedor");
        }
        public ActionResult nuevoProveedor() {
            return View("NuevoProveedor");
        }
    }
}