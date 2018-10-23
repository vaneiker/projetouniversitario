﻿using STL.POS.Data;
using STL.POS.WsProxy.SysflexService;
using STL.POS.WsProxy.WSSysFlexVehicleService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.WsProxy
{
    public interface ICoreProxy
    {

        ProductLimit GetCoverageDetails(int coverageCoreId, decimal vehiclePrice, int codRamo);

        int GetProductId(int coverageId, int vehicleTypeCoreId, string productDescription, int vehicleYear, int codRamo);

        //Dictionary<string, decimal> GetRates(int coverageGroupSysFlexId,
        Dictionary<string, object> GetRates(int coverageGroupSysFlexId,
            string productSysflexDescription,
            int vehicleYear,
            int vehicleTypeCoreId,
            decimal insuredAmount,
            int coveragePercent,
            int storageId,
            int sexId,
            int age,
            DateTime beginDate,
            DateTime endDate,
            string deductibleId,
            string servicesIdList,
            int coreModelId,
            int intermediario,
            decimal? percentSurCharge,
            bool LicenciaExtranjera,
            int qtyVehicles,
            int codRamo);

        IEnumerable<PolicyCoverageSysFlexCoverageDetails> GetCoverage(int coverageCoreId, int Indicador, decimal vehiclePrice, int codRamo);

        IList<DeductibleValues> GetDeductibles(int coverageCoreId, Parameter seqId, int modelo, int codRamo);

        IList<VehicleTypeWS> GetVehicleTypes(int vehicleTypeCoreId, int vehicleYear, string coreDeLeyStringDiscriminator, int codRamo);

        IList<decimal> GetPercentagesForCoverage(int coverageId, int vehicleYear);

        bool SetAutoQuotation(QuotationAuto quotation,
             int codMoneda,
             int tasaMoneda,
             int codIntermediario,
             int codOficina,
             int codRamo,
             int retryAmount,
             string username,
             int companySysflex,
             decimal porcDescuentoFlotilla,
             int descuentoFlotillaIDSysflex,
             decimal porcProntoPago,
             int descuentoProntoPagoIDSysflex,
             string Sistema,
             out string poliza,
             out decimal quotationCoreIdNumber,
             out decimal clientId,
             out List<string> statusMessages,
             out string SourceID,
             out Dictionary<int, string> listVehicleSourceID,
            out bool errorGP);

        PolicyVehicleVehicleIdentification[] CheckChassisPlate(string chassis, string plate);
        OfficeMatchWS GetOfficeMatch(int globalOfficeId);

        PolicyMaximoReaseguroSubramo getMaximoReaseguroSubRamo(int codRamo, int subRamo);



        bool SetAutoQuotation_New(QuotationAuto quotation,
          int codMoneda,
          int tasaMoneda,
          int codIntermediario,
          int codOficina,
          int codRamo,
          int retryAmount,
          string username,
          int companySysflex,
          decimal porcDescuentoFlotilla,
          int descuentoFlotillaIDSysflex,
          decimal porcProntoPago,
          int descuentoProntoPagoIDSysflex,
          string Sistema,
          string errorPrimaZero,
          int ubicationID,
          string genderParam,
          string ageParam,
          string useNCFNew,
          bool IsShowPolicy,
          string AllowDescuentoProntoPago,
          string AllowDescuentoFlotilla,

          out string poliza,
          out decimal quotationCoreIdNumber,
          out decimal clientId,
          out List<string> statusMessages,
          out string SourceID,
          out List<STL.POS.Data.CSEntities.ListVehicleSourceID> listVehicleSourceID,
          out bool errorGP
          );

        string SetAutoQuotationHeaderForGetCoreQuotationNumber(QuotationAuto quotation,
          int codMoneda,
          int tasaMoneda,
          int codIntermediario,
          int codOficina,
          int codRamo,
          int retryAmount,
          string username,
          int companySysflex,
          decimal porcDescuentoFlotilla,
          int descuentoFlotillaIDSysflex,
          decimal porcProntoPago,
          int descuentoProntoPagoIDSysflex,
          string Sistema,
           out string messageError);

        string SetAgentInQuotationHeader(QuotationAuto quotation, int codIntermediario, string user, int company, int codMoneda, int codRamo, int tasaMoneda, int codOficina,
            DateTime? principalDateOfBirth, out List<string> messageError, string Sexo = null);

        List<PolicySysflexMarcaVehiculo> GetVehicleMakes();

        List<STL.POS.WsProxy.SysflexService.PolicySysflexComboCondicion> GetComboCondicion_New(string type, int? ramo, int? subramo, string nombreArch, string descrip, int? ano, int? id);

        List<STL.POS.WsProxy.SysflexService.PolicySysflexComboCondicion> GetComboTipoVehiculo_New(string type, int? ramo, int? subramo, string nombreArch, string descrip, int? ano, int? id);

        List<STL.POS.WsProxy.SysflexService.PolicySysflexComboCondicion> GetAnioVehiculo_New(string type, int? ramo, int? subramo, string nombreArch, string descrip, int? ano, int? id);

        List<STL.POS.WsProxy.SysflexService.PolicySysflexComboCondicion> GetDeductible_New(string type, int? ramo, int? subramo, string nombreArch, string descrip, int? ano, int? id);

        Dictionary<string, object> GetRates_New(PolicyQuotationSysFlexCotDetKey cDetail, out List<string> statusMessages);

        void SetCoverageVehicle_GetRate_New(List<STL.POS.Data.POSEntities.CoverageJsonClass> selfAndThirdCoverage,
            List<STL.POS.Data.POSEntities.CoverageJsonClass> ServiceCoverage, decimal Cotizacion, int secuencia, int COD_COMPANIA, out List<string> statusMessages);

        void DeleteVehicleOnSysflex(int COD_COMPANIA, int vehicleSecuence, decimal quotationCoreNumber);

        PolicyItemReinsurance[] GetReinsuranceByItemVehicle(int COD_COMPANIA, decimal quotationCoreNumber, int vehicleSecuence);

        string GetSexoEdad(PolicySexoEdadKeyParameter param);

        void DeleteCoveragesForVehicle(int COD_COMPANIA, decimal quotationCoreNumber, int vehicleSecuence);

        PolicyAcuerdos[] BuscarAcuerdos(int? compania, decimal? cotizacion, int? secuenciaMov, decimal? inicial, int? cantidadCuotas, string estatus);
        STL.POS.WsProxy.SysflexService.Policyinclusioncontact GetClienteFromPoliza(string PolicyNo);
        STL.POS.WsProxy.SysflexService.Policyinclusionvehicle[] GetVehiculosFromPoliza(string PolicyNo);

        PolicyOverPremiumResult GetIsOverPremium(int? intermediario, string marca, string modelo, int? anio, int? ramo, int? subRamo);
    }
}