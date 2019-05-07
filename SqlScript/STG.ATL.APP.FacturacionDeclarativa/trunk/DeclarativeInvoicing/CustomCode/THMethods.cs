using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Text;

namespace Declarative.Invoicing.CustomCode
{
    public static class THMethods
    {
        public static byte[] GenerateXMLInvoiceToThunderhead(Entities.Invoices data)
        {
            byte[] result;
            var oDataSet = new TH.AUTO_SYSFLEX();
            var oTransaction = new TH.Transaction();
            var oContabilidad = new TH.Contabilidad();
            var oPaquete = new TH.Paquete();
            var oSupervisor = new TH.Supervisor();
            var UserCodeName = string.Empty;
            var DocumentIdSysFlexInvoice = ConfigurationManager.AppSettings["DocumentIdSysFlexInvoice"];

            oTransaction.DocumentId = DocumentIdSysFlexInvoice;
            var ListAntiguedadSalgo = new List<TH.AntiguedadSaldo>(0);
            ListAntiguedadSalgo.Add(new TH.AntiguedadSaldo { NoFactura = data.FacturaNumero, NoPoliza = data.Poliza, FechaFactura = data.Fecha.ToString() });

            oContabilidad.AntiguedadSaldo = ListAntiguedadSalgo;
            oTransaction.NoComprobante = data.Ncf;
            oTransaction.DescripcionComprobante = data.TipoComprobante;
            oTransaction.Moneda = "RD";
            oTransaction.NoPoliza = data.Poliza;
            oTransaction.Fullname = "1"+data.NombreCliente;
            oTransaction.Address = string.IsNullOrEmpty(data.Direccion) ? "-" : data.Direccion;
            oPaquete.TipoDocumento = data.Concepto;
            oPaquete.Product = string.IsNullOrEmpty(data.Producto) ? "-" : data.Producto;
            oPaquete.IdNumber = data.cedulaCliente;
            oPaquete.Email = "N/A";
            var ListAgente = new List<TH.Agente>(0);
            var ListCliente = new List<TH.Cliente>(0);
            ListCliente.Add(new TH.Cliente { CodigoCliente = data.CodigoCliente.GetValueOrDefault().ToString(), TelCasa = data.TelRes, TelTrabajo = data.TelOfic, TelMovil = data.TelCel });

            ListAgente.Add(new TH.Agente { CodigoAgente = data.CodigoAgente, NombreAgente = data.NombreVendedor, DireccionAgente = data.DireccionAgente, Cliente = ListCliente.ToArray() });
            oSupervisor.Agente = ListAgente.ToArray();
            oSupervisor.CodigoSupervisor = string.IsNullOrEmpty(data.CodigoSupervisor) ? "0" : data.CodigoSupervisor;
            oSupervisor.NombreSupervisor = data.NombreSupervisor;
            oPaquete.StartDate = data.VigenciaDesde.ToString();
            oPaquete.EndDate = data.VigenciaHasta.ToString();
            oTransaction.OficinaComercial = data.Oficina;
            oTransaction.Ramo = data.Ramo;
            var ListVehicles = new List<TH.Vehicles>(0);
            ListVehicles.Add(new TH.Vehicles
            {
                EnsuredAmount = data.SumaAsegurada.GetValueOrDefault().ToString("#,0.00", CultureInfo.InvariantCulture).Replace(",", ""),
                TotalVehiclePrime = data.PrimaNeta.GetValueOrDefault().ToString("#,0.00", CultureInfo.InvariantCulture).Replace(",", "")
            });

            oPaquete.Vehicles = ListVehicles.ToArray();
            var oPrimeResume = new TH.PrimeResume();
            oPrimeResume.Taxes = data.ISC.GetValueOrDefault().ToString("#,0.00", CultureInfo.InvariantCulture).Replace(",", "");
            oPrimeResume.TotalPayment = data.TotalAPagar.GetValueOrDefault().ToString("#,0.00", CultureInfo.InvariantCulture).Replace(",", "");
            oPaquete.PrimeResume = oPrimeResume;
            oTransaction.Username = data.UserName;
            oDataSet.Transaction = oTransaction;
            oDataSet.Contabilidad = oContabilidad;
            oDataSet.Paquete = oPaquete;
            oDataSet.Supervisor = oSupervisor;

            var DocXML = Utility.SerializeToXMLString(oDataSet);
            result = Encoding.UTF8.GetBytes(DocXML);
            return result;
        }        
    }
}