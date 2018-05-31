//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class ingreso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ingreso()
        {
            this.detalle_ingreso = new HashSet<detalle_ingreso>();
        }
    
        public int idingreso { get; set; }
        public int idtrabajador { get; set; }
        public int idproveedor { get; set; }
        public System.DateTime fecha { get; set; }
        public string tipo_comprobante { get; set; }
        public string serie { get; set; }
        public string correlativo { get; set; }
        public decimal igv { get; set; }
        public Nullable<System.DateTime> FechaAdiciona { get; set; }
        public Nullable<System.DateTime> FechaModifica { get; set; }
        public string UsuarioAdiciona { get; set; }
        public string UsuarioModifica { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalle_ingreso> detalle_ingreso { get; set; }
        public virtual proveedor proveedor { get; set; }
        public virtual trabajador trabajador { get; set; }
    }
}
