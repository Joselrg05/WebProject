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
    
    public partial class facturas_ventas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public facturas_ventas()
        {
            this.factura_producto_venta = new HashSet<factura_producto_venta>();
        }
    
        public int id { get; set; }
        public string codigo_factura { get; set; }
        public Nullable<System.DateTime> fecha_factura { get; set; }
        public Nullable<decimal> subtotal { get; set; }
        public Nullable<decimal> total { get; set; }
        public string estado_factura { get; set; }
        public Nullable<int> cliente_id { get; set; }
        public Nullable<int> vendedor_id { get; set; }
        public Nullable<int> tipo_factura_id { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
    
        public virtual clientes clientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<factura_producto_venta> factura_producto_venta { get; set; }
        public virtual tipos_facturas tipos_facturas { get; set; }
        public virtual vendedores vendedores { get; set; }
    }
}
