using CapaDatoWeb.Modelado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocioWeb
{
    public class ProductoService : CrudService<productos>
    {
        private InvenSyncEntity _db;
        public ProductoService(InvenSyncEntity db) : base(db)
        {
            if(db == null)
                this._db = new InvenSyncEntity();
            else
                this._db = db;
        }

        /// <summary>
        /// Validaciones antes de crear un neuvo registro
        /// </summary>
        /// <param name="rpoductos"></param>
        /// <returns></returns>
        public string ValidarAntesCrear(productos productos)
        {
            if (_db.productos.Any(pdct => pdct.id == productos.id))
                return "El producto con dicho Id ya existe en el sistema, Verifique y vuelva a intertar";

            return string.Empty;
        }

        /// <summary>
        /// Validaciones antes de actualizar un registro
        /// </summary>
        /// <param name="productos"></param>
        /// <returns></returns>
        public string ValidarAntesActualizar(productos productos)
        {
            var objProducto = _db.productos.Find(productos.id);

            if (objProducto == null)
                return "El producto a editar ya no existe en el sistema";

            if (objProducto.id == productos.id)
                return string.Empty;

            return ValidarAntesCrear(productos);
        }

        /// <summary>
        /// Validaciones antes de eliminar un registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string ValidarAntesEliminar(int id)
        {
            var objProducto = _db.productos.Find(id);

            if (objProducto == null)
                return "El producto a eliminar ya no existe en el sistema";

            if (objProducto.factura_producto_compra.Count > 0)
                return "El producto no se puede eliminar por que esta siendo usado por otras entidades";

            return string.Empty;
        }

    }
}
