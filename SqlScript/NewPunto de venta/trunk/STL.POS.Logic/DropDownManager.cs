﻿using Entity.Entities;
using STL.POS.Data.NewVersion.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Logic
{
    public class DropDownManager : BaseManager
    {
        private readonly DropDownRepository dropDownRepository;
        public DropDownManager()
        {
            dropDownRepository = new DropDownRepository();
        }

        public IEnumerable<Generic> GetDropDown(string DropDownType)
        {
            return
                dropDownRepository.GetDropDown(DropDownType);
        }

        public IEnumerable<VehicleModel> GetVehicleModels(int? brandID)
        {
            return
                dropDownRepository.GetVehicleModel(brandID);
        }

        public IEnumerable<Generic> GetMunicipalities(int countryID, int provinceID)
        {
            return
                dropDownRepository.GetMunicipalities(countryID, provinceID);
        }

        public IEnumerable<Generic> GetProvices(int? countryID)
        {
            return
                dropDownRepository.GetProvinces(countryID);
        }

        public IEnumerable<Generic> GetCities(int? countryID, int? provinceID, int? municipalityID)
        {
            return
                dropDownRepository.GetCities(countryID, provinceID, municipalityID);
        }

        public Generic GetParameter(string parameterName)
        {
            return
                dropDownRepository.GetParameter(parameterName);
        }

        public IEnumerable<IdentificationFinalBeneficiaryOptions> GetIdentificationFinalBeneficaryOptions(bool isCompany)
        {
            return
                dropDownRepository.GetIdentificationFinalBeneficaryOptions(isCompany);
        }

        public IEnumerable<UsageStates> GetUsageStates()
        {
            return
                dropDownRepository.GetUsageStates();
        }

        public IEnumerable<PepFormularyOptions> GetPepFormularyOptions()
        {
            return
                dropDownRepository.GetPepFormularyOptions();
        }

        public IEnumerable<CountryBusinessLine> GetCountryBusinessLines(int countryID)
        {
            return
                dropDownRepository.GetCountryBusinessLines(countryID);
        }


        public IEnumerable<VehicleTypes> GetVehicleTypes(int? brandID, int? modelID)
        {
            return
                dropDownRepository.GetVehicleTypes(brandID, modelID);
        }


        public IEnumerable<Entity.Entities.WSEntities.ComboCondicion> GetComboConditionsByParameters(string type, int? ramo, int? subramo, string nombreArch, string descrip, int? ano, int? id)
        {
            return
                dropDownRepository.GetComboConditionsByParameters(type, ramo, subramo, nombreArch, descrip, ano, id);
        }


        public IEnumerable<VehicleFuelType> GetVehicleFuelType(int? VehicleFuelTypeIdSysflex)
        {
            return
                  dropDownRepository.GetVehicleFuelType(VehicleFuelTypeIdSysflex);
        }

        public IEnumerable<VehicleFuelTypeByModel> GetVehicleFuelTypeByModel(VehicleFuelTypeByModel.Parameter parameter)
        {
            return
                 dropDownRepository.GetVehicleFuelTypeByModel(parameter);
        }

    }
}