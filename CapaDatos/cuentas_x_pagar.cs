
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
    
public partial class cuentas_x_pagar
{

    public int id { get; set; }

    public int id_proveedor { get; set; }

    public System.DateTime fecha { get; set; }

    public decimal valor { get; set; }

    public bool pagado { get; set; }

    public string usuario { get; set; }



    public virtual proveedor proveedor { get; set; }

}

}