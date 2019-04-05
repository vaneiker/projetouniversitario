
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

/// <summary>
/// Summary description for DataAccess
/// </summary>
public class DataAccess
{
    private SysflexContextDataContext _entities { get; set; }

    public DataAccess()
    {
        this._entities = new SysflexContextDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["SysFlexSegurosConnectionString"].ToString());
    }

    public List<VW_DATA_MARBETE> GetData(string[] policyList)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
        var result = new List<VW_DATA_MARBETE>(0);
        var data = _entities.VW_DATA_MARBETEs
            .Where(o => policyList.Contains(o.poliza) || policyList.Contains(o.Chassis))
                 .OrderBy(o => o.poliza)
                    .ThenBy(r => r.Chassis).ToList();
        if (data.Any())
            result = data;
        return result;
    }
    public List<VW_DATA_MARBETE> GetDataMarbete(string[] policyList)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
        _entities.CommandTimeout = 1800;
        var result = new List<VW_DATA_MARBETE>(0);
        var dataByPolicy = _entities.VW_DATA_MARBETEs.Where(o => policyList.Contains(o.poliza));
        var dataByChasis = _entities.VW_DATA_MARBETEs.Where(o => policyList.Contains(o.Chassis));
        var data = dataByPolicy.Union(dataByChasis).DistinctBy(p=> p.Chassis).OrderBy(o => o.poliza)
                    .ThenBy(r => r.Chassis).ToList();
        if (data.Any())
            result = data;
        return result;
    }
    
    public List<Marbete> GetMarbete(string[] policyList)
    {
        var result = new List<Marbete>(0);
        var data = _entities.VW_DATA_MARBETEs.Where(o => policyList.Contains(o.poliza)).ToList();
        if (data.Any())
        {
            result = data.Select(o => new Marbete()
            {
                poliza = o.poliza.DefaultValue(),
                cotizacion = o.cotizacion.ToString(),
                fechainiciovigencia = o.fechainiciovigencia.ToString().DefaultValue(),
                fechafinvigencia = o.fechafinvigencia.ToString().DefaultValue(),
                nombrecliente = o.nombrecliente.DefaultValue(),
                TipoVehiculo = o.TipoVehiculo.DefaultValue(),
                Marca = o.Marca.DefaultValue(),
                Modelo = o.Modelo.DefaultValue(),
                Ano = o.Ano,
                Color = o.Color.DefaultValue(),
                Chassis = o.Chassis.DefaultValue(),
                Registro = o.Registro.DefaultValue(),
                Uso = o.Uso.DefaultValue(),
                Cilindro = o.Cilindro.DefaultValue(),
                Pasajeros = o.Pasajeros.ToString().DefaultValue(),
                EndosoSeccion = o.EndosoSeccion.DefaultValue(),
                Observacion = o.Observacion.DefaultValue(),
                Fianza = o.Fianza.DefaultValue(),
                CasaConductor = !string.IsNullOrEmpty(o.CasaConductor) ? "Yes" : string.Empty,
                Grua = !string.IsNullOrEmpty(o.Grua) ? "Yes" : string.Empty,
                Asistencia = !string.IsNullOrEmpty(o.Asistencia) ? "Yes" : string.Empty,
            }).ToList();

        }
        return result;
    }
    public bool AddLog(UserInfo user)
    {
        bool result = false;
        var _User = new P_PolizaImpresionMarbete();
        try
        {
            _User.Usuario = user.UserFullName.ToUpper();
            _User.Cotizacion = user.Quotation;
            _User.Poliza = user.Policy;
            _User.DiasImpresion = 0;
            _User.Fecha = DateTime.Now;
            _User.Compania = 30;
            _User.Secuencia = user.Sequence;
            _entities.P_PolizaImpresionMarbetes.InsertOnSubmit(_User);
            _entities.SubmitChanges();
            result = true;
        }
        catch (Exception)
        {
            return result;
        }
        return result;
    }
}