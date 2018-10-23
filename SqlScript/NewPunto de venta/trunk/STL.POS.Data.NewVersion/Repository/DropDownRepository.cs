﻿using Entity.Entities;
using STL.POS.Data.NewVersion.EdmxModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data.NewVersion.Repository
{
    public class DropDownRepository : BaseRepository
    {
        public DropDownRepository() { }

        public IEnumerable<Generic> GetDropDown(string DropDownType)
        {
            IEnumerable<Generic> result;
            IEnumerable<SP_FILL_DROP_DOWN_Result> temp;
            temp = PosContex.SP_FILL_DROP_DOWN(DropDownType);
            result = temp.Select(d => new Generic
            {
                Value = d.id,
                name = d.name
            }).ToArray();

            return
                 result;
        }

        public IEnumerable<VehicleModel> GetVehicleModel(int? brandID)
        {
            IEnumerable<VehicleModel> result;
            IEnumerable<SP_GET_MODELS_BY_BRANDS_Result> temp;
            temp = PosContex.SP_GET_MODELS_BY_BRANDS(brandID);

            result = temp.Select(q => new VehicleModel()
            {
                Id = q.id,
                Name = q.name,
                CoreId = q.Core_Id
            })
            .ToArray();

            return result;
        }

        public IEnumerable<Generic> GetMunicipalities(int? countryID, int? provinceID)
        {
            IEnumerable<Generic> result;
            IEnumerable<SP_GET_MUNICIPALITIES_Result> temp;
            temp = PosContex.SP_GET_MUNICIPALITIES(countryID, provinceID);

            result = temp.Select(q => new Generic()
            {
                Value = q.id,
                name = q.name
            })
            .ToArray();

            return result;
        }

        public IEnumerable<Generic> GetProvinces(int? countryID)
        {
            IEnumerable<Generic> result;
            IEnumerable<SP_GET_PROVINCES_Result> temp;
            temp = PosContex.SP_GET_PROVINCES(countryID);

            result = temp.Select(q => new Generic()
            {
                Value = q.id.ToString(),
                name = q.name
            })
            .ToArray();

            return result;
        }

        public IEnumerable<Generic> GetCities(int? countryID, int? provinceID, int? municipalityID)
        {
            IEnumerable<Generic> result;
            IEnumerable<SP_GET_CITIES_Result> temp;
            temp = PosContex.SP_GET_CITIES(countryID, provinceID, municipalityID);

            result = temp.Select(q => new Generic()
            {
                Value = q.id,
                name = q.name
            })
            .ToArray();

            return result;
        }

        public Generic GetParameter(string parameterName)
        {
            Generic result;
            IEnumerable<SP_GET_PARAMETERS_Result> temp;
            temp = PosContex.SP_GET_PARAMETERS(parameterName);

            result = temp.Select(q => new Generic()
            {
                Value = q.Value,
                name = q.Name
            }).FirstOrDefault();

            return
                result;
        }

        public IEnumerable<IdentificationFinalBeneficiaryOptions> GetIdentificationFinalBeneficaryOptions(bool isCompany)
        {
            IEnumerable<IdentificationFinalBeneficiaryOptions> Result;
            IEnumerable<SP_GET_IDENTIFICATION_FINAL_BENEFICIARY_OPTION_Result> temp;
            temp = PosContex.SP_GET_IDENTIFICATION_FINAL_BENEFICIARY_OPTION(isCompany);

            Result = temp.Select(q => new IdentificationFinalBeneficiaryOptions()
            {
                Id = q.Id,
                Name = q.name,
                Allowed = q.Allowed,
                Includeforcompanyornot = q.includeforcompanyornot
            })
            .ToArray();

            return
                Result;
        }

        public IEnumerable<UsageStates> GetUsageStates()
        {
            IEnumerable<UsageStates> result;
            IEnumerable<SP_GET_USAGE_STATES_Result> temp;
            temp = PosContex.SP_GET_USAGE_STATES();

            result = temp.Select(q => new UsageStates()
            {
                Id = q.id,
                Name = q.name,
                UsageMessage = q.Usage_Message,
                Allowed = q.Allowed
            })
            .ToArray();

            return
                result;
        }

        public IEnumerable<PepFormularyOptions> GetPepFormularyOptions()
        {
            IEnumerable<PepFormularyOptions> result;
            IEnumerable<SP_GET_PEP_OPTIONS_Result> temp;
            temp = PosContex.SP_GET_PEP_OPTIONS();

            result = temp.Select(q => new PepFormularyOptions()
            {
                Id = q.Id,
                Name = q.name,
                Allowed = q.Allowed
            })
            .ToArray();

            return result;
        }

        public IEnumerable<CountryBusinessLine> GetCountryBusinessLines(int countryID)
        {
            IEnumerable<CountryBusinessLine> result;
            IEnumerable<SP_GET_BUSINESS_LINE_BY_COUNTRY_Result> temp;
            temp = PosContex.SP_GET_BUSINESS_LINE_BY_COUNTRY(countryID);

            result = temp.Select(q => new CountryBusinessLine()
            {
                Id = q.Id,
                bl_name = q.bl_name,
                Path = q.Path,
                CoreId = q.CoreId,
                Global_Country_Desc = q.Global_Country_Desc,
                Global_Country_Id = q.Global_Country_Id,
            })
            .ToArray();

            return
                result;
        }

        public IEnumerable<VehicleTypes> GetVehicleTypes(int? brandID, int? modelID)
        {
            IEnumerable<VehicleTypes> result;
            IEnumerable<SP_GET_VEHICLE_TYPES_Result> temp;
            temp = PosContex.SP_GET_VEHICLE_TYPES(brandID, modelID);

            result = temp.Select(q => new VehicleTypes()
            {
                CoreVehicleTypeId = q.Core_Vehicle_Type_Id,
                Namekey = q.namekey,
                RowId = q.ROW_ID,
                VehicleTypeDesc = q.Vehicle_Type_Desc,
                VehicleTypeId = q.Vehicle_Type_Id,
                VehicleTypeStatus = q.Vehicle_Type_Status
            })
            .ToArray();

            return result;
        }

        public IEnumerable<Entity.Entities.WSEntities.ComboCondicion> GetComboConditionsByParameters(
            string type, int? ramo, int? subramo, string nombreArch, string descrip, int? ano, int? id)
        {
            IEnumerable<Entity.Entities.WSEntities.ComboCondicion> result;
            IEnumerable<GET_COMBO_CONDICITIONS_BY_PARAMETERS_Result> temp;
            temp = PosContex.GET_COMBO_CONDICITIONS_BY_PARAMETERS(type, ramo, subramo, nombreArch, descrip, ano, id);

            result = temp.Select(x => new Entity.Entities.WSEntities.ComboCondicion()
            {
                Ramo = x.Ramo,
                SubRamo = x.SubRamo,
                SecuenciaCondicion = x.SecuenciaCondicion,
                NombreArchivo = x.NombreArchivo,
                Codigo = x.Codigo,
                Descripcion = x.Descripcion,
                Porciento = x.Porciento,
                Prima = x.Prima,
                Reaseguro = x.Reaseguro

            })
            .ToArray();

            return result;
        }


        public IEnumerable<VehicleFuelType> GetVehicleFuelType(int? VehicleFuelTypeIdSysflex)
        {
            IEnumerable<VehicleFuelType> result;
            IEnumerable<SP_GET_VEHICLE_FUEL_TYPE_Result> temp;
            temp = PosContex.SP_GET_VEHICLE_FUEL_TYPE(VehicleFuelTypeIdSysflex);

            result = temp.Select(q => new VehicleFuelType()
            {
                VehicleFuelTypeIdSysflex = q.VehicleFuelTypeIdSysflex,
                VehicleFuelTypeDesc = q.VehicleFuelTypeDesc
            })
            .ToArray();

            return result;
        }

        public IEnumerable<VehicleFuelTypeByModel> GetVehicleFuelTypeByModel(VehicleFuelTypeByModel.Parameter parameter)
        {
            IEnumerable<VehicleFuelTypeByModel> result;
            IEnumerable<SP_GET_VEHICLE_FUEL_TYPE_BY_MODEL_Result> temp;
            temp = PosContex.SP_GET_VEHICLE_FUEL_TYPE_BY_MODEL(parameter.vehicleFuelTypeIdSysflex, parameter.makeId, parameter.modelId);

            result = temp.Select(q => new VehicleFuelTypeByModel()
            {
                VehicleFuelTypeIdSysflex = q.VehicleFuelTypeIdSysflex,
                VehicleFuelTypeDesc = q.VehicleFuelTypeDesc,
                MakeId = q.Make_Id,
                ModelId = q.Model_Id
            })
            .ToArray();

            return result;
        }

    }
}