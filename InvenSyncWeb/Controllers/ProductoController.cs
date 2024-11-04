using CapaDatoWeb.Modelado;
using CapaNegocioWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvenSyncWeb.Controllers
{
    public class ProductoController : Controller
    {
        private InvenSyncEntity db;
        private ProductoService producto;

        public ProductoController()
        {
            db = new InvenSyncEntity();
            producto = new ProductoService(db);
        }

        // GET: Prod
        public ActionResult Index()
        {
            var listarProducto = producto.GetAll();
            return View(listarProducto);
        }
    }
}