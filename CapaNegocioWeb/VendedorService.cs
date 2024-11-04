using CapaDatoWeb.Modelado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocioWeb
{
    public class VendedorService : CrudService<vendedores>
    {
        private InvenSyncEntity _db;
        public VendedorService(InvenSyncEntity db) : base(db)
        {
            if (db == null)
                this._db = new InvenSyncEntity();
            else
                this._db = db;
        }

        /// <summary>
        /// Validaciones antes de crear un nuevo registro
        /// </summary>
        /// <param name="vendedores"></param>
        /// <returns></returns>
        public string ValidarAntesCrear(vendedores vendedores)
        {
            if (_db.vendedores.Any(vnds => vnds.id == vendedores.id))
                return "Ya existe un vendedor con dicho Id, Verifique y vuelva a intertar";

            return string.Empty;
        }

        /// <summary>
        /// Validaciones antes de actualizar un registro
        /// </summary>
        /// <param name="clientes"></param>
        /// <returns></returns>
        public string ValidarAntesActualizar(vendedores vendedores)
        {
            var objVendedor = _db.clientes.Find(vendedores.id);

            if (objVendedor == null)
                return "El vendedor a editar ya no existe en el sistema";

            if (vendedores.id == objVendedor.id)
                return string.Empty;

            return ValidarAntesCrear(vendedores);
        }

        /// <summary>
        /// Validación antes de eliminar un registro
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string ValidarAntesEliminar(int Id)
        {
            var objVendedor = _db.vendedores.Find(Id);

            if (objVendedor== null)
                return "El Vendedor a eliminar no se encuentra en el sistema";

            if (objVendedor.facturas_ventas.Count > 0)
                return "El vendedor no se puede eliminar porque esta siendo usado por otra entidad";

            return string.Empty;
        }
    }
}
