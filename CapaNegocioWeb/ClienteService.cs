using CapaDatoWeb.Modelado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocioWeb
{
    public class ClienteService : CrudService<clientes>
    {
        private InvenSyncEntity _db;
        public ClienteService(InvenSyncEntity db) : base(db)
        {
            if (db == null)
                this._db = new InvenSyncEntity();
            else
                this._db = db;
        }

        /// <summary>
        /// Validaciones antes de crear un nuevo registro
        /// </summary>
        /// <param name="clientes"></param>
        /// <returns></returns>
        public string ValidarAntesCrear(clientes clientes)
        {
            if (_db.clientes.Any(clnt => clnt.id == clientes.id))
                return "Ya existe un cliente con dicho Id, Verifique y vuelva a intertar";

            return string.Empty;
        }

        /// <summary>
        /// Validaciones antes de actualizar un registro
        /// </summary>
        /// <param name="clientes"></param>
        /// <returns></returns>
        public string ValidarAntesActualizar(clientes clientes)
        {
            var objCliente = _db.clientes.Find(clientes.id);

            if (objCliente == null)
                return "El cliente a editar ya no existe en el sistema";

            if (clientes.id == objCliente.id)
                return string.Empty;

            return ValidarAntesCrear(clientes);
        }

        /// <summary>
        /// Validación antes de eliminar un registro
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string ValidarAntesEliminar(int Id)
        {
            var objCliente = _db.clientes.Find(Id);

            if (objCliente == null)
                return "El cliente a eliminar no se encuentra en el sistema";

            if (objCliente.facturas_ventas.Count > 0)
                return "El cliente no se puede eliminar porque esta siendo usado por otra entidad";

            return string.Empty;
        }
    }
}
