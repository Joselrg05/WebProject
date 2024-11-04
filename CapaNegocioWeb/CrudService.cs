using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocioWeb
{
    public class CrudService <T> where T : class
    {
        /// <summary>
        /// Conexión al contexto BD
        /// </summary>
        private DbContext _db;

        public CrudService(DbContext db)
        {
            this._db = db;
        }

        /// <summary>
        /// Función para listar registros de una entidad o clase
        /// </summary>
        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public List<T> ObtenerTodo(Expression<Func<T, bool>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression), "The expression cannot be null.");
            }

            try
            {
                return _db.Set<T>().Where(expression).ToList();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while retrieving data.", ex);
            }
        }

        /// <summary>
        /// Funcion para crear una registro de una entidad
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public bool Crear(T entidad)
        {
            _db.Entry(entidad).State = EntityState.Added;
            return _db.SaveChanges() > 0;
        }

        /// <summary>
        /// Funcion para actualizar un registro de una entidad
        /// </summary>
        /// <param name="entidad"></param>
        public void Actualizar(T entidad)
        {
            _db.Entry(entidad).State = EntityState.Modified;

            _db.SaveChanges();

        }

        /// <summary>
        /// Funicon para eliminar un registro de una entidad
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Eliminar(int id)
        {
            var entidad = _db.Set<T>().Find(id);

            _db.Entry(entidad).State = EntityState.Deleted;

            return _db.SaveChanges() > 0;
        }

        /// <summary>
        /// Funicon para eliminar un registro de una entidad
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T BuscarId(int id)
        {
            var entidad = _db.Set<T>().Find(id);
            return entidad;
        }
    }
}
