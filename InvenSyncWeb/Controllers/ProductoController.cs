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
        private ProductoService productoService;

        public ProductoController()
        {
            db = new InvenSyncEntity();
            productoService = new ProductoService(db);
        }

        // GET: Prod
        public ActionResult Index()
        {
            var listarProducto = productoService.GetAll();
            return View(listarProducto);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(productos productos)
        {
            // Validación inicial del modelo. Si no es válido, regresamos la vista con el mismo modelo
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMensaje = "Hay errores en el formulario. Por favor, corríjalos e intente nuevamente.";
                return View(productos);
            }

            try
            {
                // Llamamos a la validación específica del servicio antes de crear el producto
                var errorMensaje = productoService.ValidarAntesCrear(productos);

                if (!string.IsNullOrEmpty(errorMensaje))
                {
                    // Si hay un mensaje de error, mostramos el mensaje y regresamos la vista con el modelo
                    ViewBag.ErrorMensaje = errorMensaje;
                    return View(productos);
                }

                // Intentamos crear el producto
                var resultado = productoService.Crear(productos);

                // Si la creación fue exitosa, redirigimos a la vista "Index"
                if (resultado)
                    return RedirectToAction("Index");

                // En caso de error inesperado en el servicio, mostramos mensaje de error
                ViewBag.ErrorMensaje = "Error de servidor, por favor contacte al administrador.";
                return View(productos);
            }
            catch (Exception ex)
            {
                // Captura de excepciones para errores inesperados
                // Aquí podríamos loguear el error si fuera necesario para seguimiento
                ViewBag.ErrorMensaje = "Ha ocurrido un error inesperado. Contacte al administrador del sistema.";

                // Opcional: Log de la excepción para un seguimiento más detallado en logs
                // Logger.LogError("Error al crear producto", ex);

                return View(productos);
            }
        }
    }
}