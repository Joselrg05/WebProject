//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaDatoWeb.Modelado
{
    using System;
    using System.Collections.Generic;
    
    public partial class clientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public clientes()
        {
            this.descuentos_clientes = new HashSet<descuentos_clientes>();
            this.facturas_ventas = new HashSet<facturas_ventas>();
        }
    
        public int id { get; set; }
        public string nombre_cliente { get; set; }
        public string direccion_cliente { get; set; }
        public string telefono_cliente { get; set; }
        public string email_cliente { get; set; }
        public Nullable<decimal> descuento { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<descuentos_clientes> descuentos_clientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<facturas_ventas> facturas_ventas { get; set; }
    }
}
